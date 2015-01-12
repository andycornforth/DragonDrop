namespace DragDetails
{
    partial class LoginWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.loginPrompt = new System.Windows.Forms.Label();
            this.pinBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.goStraightLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginPrompt
            // 
            this.loginPrompt.AutoSize = true;
            this.loginPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPrompt.Location = new System.Drawing.Point(12, 18);
            this.loginPrompt.Name = "loginPrompt";
            this.loginPrompt.Size = new System.Drawing.Size(163, 20);
            this.loginPrompt.TabIndex = 0;
            this.loginPrompt.Text = "Enter your secure pin:";
            // 
            // pinBox
            // 
            this.pinBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinBox.Location = new System.Drawing.Point(181, 12);
            this.pinBox.Name = "pinBox";
            this.pinBox.Size = new System.Drawing.Size(91, 26);
            this.pinBox.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loginButton.Location = new System.Drawing.Point(281, 12);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(106, 29);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // goStraightLabel
            // 
            this.goStraightLabel.AutoSize = true;
            this.goStraightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goStraightLabel.Location = new System.Drawing.Point(279, 61);
            this.goStraightLabel.Name = "goStraightLabel";
            this.goStraightLabel.Size = new System.Drawing.Size(115, 12);
            this.goStraightLabel.TabIndex = 4;
            this.goStraightLabel.Text = "Go Straight to Dragon Drop";
            this.goStraightLabel.Click += new System.EventHandler(this.goStraightLabel_MouseDoubleClick);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 79);
            this.Controls.Add(this.goStraightLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pinBox);
            this.Controls.Add(this.loginPrompt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginPrompt;
        private System.Windows.Forms.TextBox pinBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label goStraightLabel;
    }
}