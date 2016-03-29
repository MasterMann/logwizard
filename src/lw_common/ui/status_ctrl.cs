﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lw_common.ui {
    public static class status_type_io {
        public static bool is_error_or_above(this status_ctrl.status_type status) {
            return status == status_ctrl.status_type.err ;
        }
        public static bool is_warn_or_above(this status_ctrl.status_type status) {
            return status == status_ctrl.status_type.err || status == status_ctrl.status_type.warn;
        }
    }

    public partial class status_ctrl : rich_label_ctrl {
        // the status(es) to be shown
        public enum status_type {
            msg, warn, err
        }

        private List< Tuple<string, status_type, DateTime>> statuses_ = new List<Tuple<string, status_type, DateTime>>();
        // what to be shown behind ALL statuses
        private string status_prefix_ = "";

        public status_ctrl() {
            InitializeComponent();
        }

        private void refresh_Tick(object sender, EventArgs e) {
            update_status_text();
        }

        // sets the status for a given period - after that ends, the previous status is shown
        // if < 0, it's forever
        public void set_status(string msg, status_type type = status_type.msg, int set_status_for_ms = 7500) {
            bool was_showing_error = is_showing_error;
            if (set_status_for_ms <= 0)
                statuses_.Clear();

            if (type == status_type.err)
                // show errors longer
                set_status_for_ms = Math.Max(set_status_for_ms, 15000);

            // 1.5.6+ special case - if the status is the same
            bool same_status = false;
            if ( statuses_.Count > 0)
                if (statuses_.Last().Item1 == msg && statuses_.Last().Item2 == type) {
                    // same message
                    statuses_.RemoveAt( statuses_.Count - 1);
                    same_status = true;
                }

            statuses_.Add(new Tuple<string, status_type, DateTime>(msg, type, set_status_for_ms > 0 ? DateTime.Now.AddMilliseconds(set_status_for_ms) : DateTime.MaxValue));
            if (same_status)
                return;
            show_last_status();

            // 1.8.6+ (if showing a new error, no need to beep again)
            if (type == status_type.err && !was_showing_error)
                util.beep(util.beep_type.err);
        }

        public bool is_showing_error {
            get {
                if (statuses_.Count > 0)
                    return (statuses_.Last().Item2 == status_type.err);
                return false;
            }
        }

        public string shown_msg {
            get { return statuses_.Count > 0 ? statuses_.Last().Item1 : ""; }
        }

        private void show_last_status() {
            if (statuses_.Count < 1) 
                return;
            var last = statuses_.Last();
            var type = last.Item2;
            var msg = last.Item1;

            string color_prefix = "";
            if (status_color(type) != util.transparent)
                color_prefix += " <fg " + util.color_to_str(status_color(type)) + "> ";
            if (status_bg_color(type) != util.transparent)
                color_prefix += " <bg " + util.color_to_str(status_bg_color(type)) + "> ";
            set_text( color_prefix + status_prefix_ + msg);
        }

        public void set_status_forever(string msg) {
            set_status(msg, status_type.msg, -1);
        }

        public void set_prefix(string prefix) {
            status_prefix_ = prefix != "" ? prefix + " " : "";
            update_status_text(true);
        }

        public status_type update_status_text(bool force = false) {
            bool needs_update = false;
            while (statuses_.Count > 0 && statuses_.Last().Item3 < DateTime.Now) {
                statuses_.RemoveAt(statuses_.Count - 1);
                needs_update = true;
            }

            if (needs_update || force) 
                show_last_status();

            return (statuses_.Count > 0) ? statuses_.Last().Item2 : status_type.msg;
        }

        private Color status_color(status_type type) {
            return type == status_type.err ? Color.DarkRed : util.transparent;
        }

        private Color status_bg_color(status_type type) {
            return type == status_type.err ? Color.Yellow : util.transparent;
        }

    }
}
