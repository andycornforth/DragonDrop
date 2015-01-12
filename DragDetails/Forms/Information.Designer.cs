namespace DragDetails.Forms
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            this.informationBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // informationBox
            // 
            this.informationBox.Location = new System.Drawing.Point(6, 7);
            this.informationBox.Name = "informationBox";
            this.informationBox.ReadOnly = true;
            this.informationBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.informationBox.Size = new System.Drawing.Size(382, 361);
            this.informationBox.TabIndex = 0;
            this.informationBox.Text = resources.GetString("informationBox.Text");
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 371);
            this.Controls.Add(this.informationBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox informationBox;
    }
}