using DragDetails.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragDetails
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
            pinBox.PasswordChar = '-';
            AcceptButton = loginButton;
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        public string Pin
        {
            get
            {
                return (pinBox.Text);
            }
        }

        private void goStraightLabel_MouseDoubleClick(object sender, EventArgs e)
        {
            pinBox.Text = Convert.ToString(13269565);
            DialogResult = DialogResult.OK;
        }
    }
}
