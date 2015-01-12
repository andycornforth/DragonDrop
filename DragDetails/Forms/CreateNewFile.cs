using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragDetails.Forms
{
    public partial class CreateNewFile : Form
    {
        public CreateNewFile()
        {
            InitializeComponent();
        }

        public int NewPin;

        private void okButton_Click(object sender, EventArgs e)
        {
            displayEnterPinWindow();
        }

        private void displayEnterPinWindow()
        {
            var changePinWindow = new ChangePin();
            changePinWindow.ShowDialog();
            if (changePinWindow.DialogResult == DialogResult.OK)
            {
                if (changePinWindow.Text1.Text.Equals(changePinWindow.Text2.Text))
                {
                    if (changePinWindow.Text1.Text != string.Empty)
                    {
                        NewPin = Convert.ToInt32(changePinWindow.Text1.Text);
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    var messageBox = new ErrorMessageBox();
                    messageBox.Text = "Error";
                    messageBox.Label.Text = "Your PIN was not changed. They did not match";
                    messageBox.ShowDialog();
                }
            }
        }
    }
}
