﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lw_common.ui.format.column_formatters.helper {
    /* 
    Syntax:
        
    // base to write on - default=10
    base=value

    // padding, similar to string.format, such as "0.00" or stuff
    pad=value

    // the color to show the numbers on - default = red
    // '-' - means no color
    color=value

    // if true, we look for hexa values - i will just write them with the given color, won't tranform them into any base or something
    look_for_hex=0 or 1 (1 by default)

    */
    class format_number : column_formatter_base {
        private int base_ = 10;
        private string pad_ = "";
        private string color_ = "";
        private bool look_for_hex_ = true;

        // 1.8.14+ highly improved - also, looks for XXX-XXX-XX GUIDss
        // 1.7.12 - limit the possibility of false positives - search only for only capital letters (a-f)
        private Regex regex_hex_ = new Regex(@"(?<=(\W|^))([0-9]|[A-F]){4,}([0-9]|[A-F]|-)*(?=(\W|$))");

        // 1.8.14+ highly improved
        private Regex regex_decimal_ = new Regex(@"(?<=(\W|^))-?\d+[,.]?\d*(?=(\W|$))");

        private int overridden_base_ = -1;

        public int number_base {
            get { return overridden_base_ >= 0 ? overridden_base_ : base_; }
        }

        internal override void load_syntax(settings_as_string sett, ref string error) {
            base.load_syntax(sett, ref error);
            base_ = int.Parse(sett.get("base", "10"));
            pad_ = sett.get("pad");
            color_ = sett.get("color", "red");
            if (color_ == "-")
                color_ = "";
            look_for_hex_ = sett.get("look_for_hex", "1") == "1";
        }

        // we know the number **can** be hex. I want to know that it is hex, and not decimal
        private static bool double_check_is_hex(string s) {
            return s.Any(x => !Char.IsDigit(x) && x != '-');
        }

        // returning "" means we could not convert
        private string convert_number(string str) {
            long n;
            double d;
            bool ok1 = long.TryParse(str, out n);
            bool ok2 = double.TryParse(str, out d);

            if (!ok1 && !ok2)
                // either this was a double (which we don't transorm into another base), or we could just not interpret it as a number
                return "";

            try {
                if ( !ok1)
                    // in this case, it's a double - we can only perform padding
                    return pad_ != "" ? String.Format("{0:" + pad_ + "}", d) : "";

                // here, it's a decimal
                if ( number_base == 10)
                    // perform padding, if any
                    return pad_ != "" ? String.Format("{0:" + pad_ + "}", n) : "";

                // here, it's in a different base. Note: we can't have both base and padding. Base overrides padding
                return Convert.ToString(n, number_base).ToUpper();
            } catch {
                return "";
            }
        }

        private bool is_cell_type_ok(info_type type) {
            switch (type) {
            case info_type.date:
            case info_type.time:
            case info_type.level:
            case info_type.thread:
            case info_type.file:
            case info_type.func:
            case info_type.class_:
            case info_type.view:
            case info_type.line:
                return false;
            }
            return true;
        }

        internal override void toggle_number_base() {
            if (overridden_base_ < 0)
                overridden_base_ = base_;

            switch (overridden_base_) {
            case 10:
                overridden_base_ = 16;
                break;
            case 16:
                overridden_base_ = 8;
                break;
            case 8:
                overridden_base_ = 2;
                break;
            case 2:
                overridden_base_ = 10;
                break;
            default:
                overridden_base_ = 10;
                break;
            }
        }

        private bool is_number_char(char ch) {
            if (ch >= '0' && ch <= '9')
                return true;
            if (number_base > 10) {
                // hexa decimal numbers - only uppercase
                if (ch >= 'A' && ch <= 'F')
                    return true;
            }
            return false;
        }

        // can throw!
        long to_number(string s) {
            // find out if hex
            bool is_hex = s.Any(c => !Char.IsDigit(c));
            if (is_hex)
                return long.Parse(s, NumberStyles.HexNumber);

            long result = 0;
            foreach (char c in s) {
                result *= number_base;
                result += c - '0';
            }
            return result;
        }

        internal override void get_tooltip(format_cell cell, int char_index, ref string tooltip) {
            if (!is_cell_type_ok(cell.col_type))
                return;
            var text = cell.format_text.text;
            if (text == "")
                return;

            int start = char_index, end = char_index;
            while (start >= 0 && is_number_char(text[start]))
                --start;
            if (start < 0)
                start = 0;
            if (!is_number_char(text[start]))
                ++start;
            while (end < text.Length && is_number_char(text[end]))
                ++end;

            if (end > start) {
                string number = text.Substring(start, end - start);
                try {
                    long n = to_number(number);
                    tooltip = String.Format("D {0}\r\nH {1}\r\nO {2}\r\nB {3}",
                        Convert.ToString(n, 10), Convert.ToString(n, 16), Convert.ToString(n, 8), Convert.ToString(n, 2));
                } catch {
                    // invalid number
                }
            }
        }

        private bool already_formatted(format_cell cell, int start, int len) {
            var text = cell.format_text.text;
            for (int idx = start; idx < start + len; ++idx) {
                var part = cell.format_text.part_at_index(idx);
                if ( part != null)
                    // in this case, we consider "formatted" only if the part found is less than then whole text
                    if (part.len < text.Length)
                        return true;

            }
            return false;
        }

        internal override void format_before(format_cell cell) {
            if (!is_cell_type_ok(cell.col_type))
                return;
            if (color_ == "" && number_base == 10 && pad_ == "" && !look_for_hex_)
                // we don't need to do anything
                return;

            // if number too big, don't do anything
            // also, doubles -> don't care about base
            var text = cell.format_text.text;

            Color col = parse_color(color_, cell.fg_color);
            if (look_for_hex_) {
                // ... note: we don't want the delimeters included
                var hex_numbers = util.regex_matches(regex_hex_, text).Where(
                    // note: if the number is already formatted in some way, don't format it again
                    x => double_check_is_hex(text.Substring(x.Item1, x.Item2)) && !already_formatted(cell, x.Item1, x.Item2) )
                    .ToList();
                cell.format_text.add_parts(hex_numbers.Select(x => new text_part(x.Item1, x.Item2) {fg = col}).ToList());
            }

            /* IMPORTANT: we have the following assumption: the hexa numbers NEVER interfere with the decimal numbers.

                Here's the rationale: the decimal numbers can be transformed, while the hex numbers will NEVER be transformed. In other words, we can transform
                something like "Number 255 is awesome." into "Number FF is awesome". Thus, we're replacing sub-text in a a text that also has formatting.

                Normally, that should work ok (formatted_text.replace_text), but if texts got to be imbricated one another, things could get ugly 
            */
            var dec_numbers = util.regex_matches(regex_decimal_, text)
                // note: if the number is already formatted in some way, don't format it again
                .Where(x => !already_formatted(cell, x.Item1, x.Item2)) .OrderBy(x => x.Item1).ToList();
            // see if i need to replace with written in another base
            cell.format_text.add_parts(dec_numbers.Select(x => new text_part(x.Item1, x.Item2) {fg = col}).ToList());

            int start_offset = 0;
            foreach (var cur_number_offset in dec_numbers) {
                int start = cur_number_offset.Item1 + start_offset, len = cur_number_offset.Item2;
                var new_number = convert_number(cell.format_text.text.Substring(start, len));
                if (new_number != "") {
                    cell.format_text.replace_text(start, len, new_number);
                    int diff = new_number.Length - len;
                    start_offset += diff;
                }
            }
        }

        internal override void format_after(format_cell cell) {
        }
    }
}
