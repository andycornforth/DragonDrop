namespace DragDetails.Forms
{
    partial class Formatting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formatting));
            this.fontComboBox = new System.Windows.Forms.ComboBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.fontStringLabel = new System.Windows.Forms.Label();
            this.fontStringComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fontComboBox
            // 
            this.fontComboBox.FormattingEnabled = true;
            this.fontComboBox.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24"});
            this.fontComboBox.Location = new System.Drawing.Point(128, 46);
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(58, 21);
            this.fontComboBox.TabIndex = 0;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.BackColor = System.Drawing.SystemColors.Control;
            this.fontLabel.Location = new System.Drawing.Point(12, 49);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(57, 13);
            this.fontLabel.TabIndex = 1;
            this.fontLabel.Text = "Font Size: ";
            // 
            // button
            // 
            this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button.Location = new System.Drawing.Point(128, 73);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(58, 23);
            this.button.TabIndex = 2;
            this.button.Text = "OK";
            this.button.UseVisualStyleBackColor = true;
            // 
            // fontStringLabel
            // 
            this.fontStringLabel.AutoSize = true;
            this.fontStringLabel.BackColor = System.Drawing.SystemColors.Control;
            this.fontStringLabel.Location = new System.Drawing.Point(12, 18);
            this.fontStringLabel.Name = "fontStringLabel";
            this.fontStringLabel.Size = new System.Drawing.Size(34, 13);
            this.fontStringLabel.TabIndex = 3;
            this.fontStringLabel.Text = "Font: ";
            // 
            // fontStringComboBox
            // 
            this.fontStringComboBox.FormattingEnabled = true;
            this.fontStringComboBox.Items.AddRange(new object[] {
            "Arial",
            "Calibri",
            "Impact",
            "Microsoft Sans Serif",
            "Tahoma",
            "Times New Roman"});
            this.fontStringComboBox.Location = new System.Drawing.Point(87, 12);
            this.fontStringComboBox.Name = "fontStringComboBox";
            this.fontStringComboBox.Size = new System.Drawing.Size(99, 21);
            this.fontStringComboBox.TabIndex = 4;
            // 
            // Formatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 108);
            this.Controls.Add(this.fontStringComboBox);
            this.Controls.Add(this.fontStringLabel);
            this.Controls.Add(this.button);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.fontComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Formatting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formatting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fontComboBox;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label fontStringLabel;
        private System.Windows.Forms.ComboBox fontStringComboBox;
    }
}