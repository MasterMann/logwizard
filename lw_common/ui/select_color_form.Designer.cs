﻿namespace lw_common {
    partial class select_color_form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.picker = new ColorPicker.ColorPickerCtrl();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // picker
            // 
            this.picker.BackColor = System.Drawing.Color.Transparent;
            this.picker.Location = new System.Drawing.Point(-1, -7);
            this.picker.Name = "picker";
            this.picker.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.picker.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.picker.Size = new System.Drawing.Size(513, 251);
            this.picker.TabIndex = 0;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(410, 245);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(41, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(451, 245);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(55, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // select_color_form
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(512, 271);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.picker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "select_color_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "select_color_form";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorPicker.ColorPickerCtrl picker;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}