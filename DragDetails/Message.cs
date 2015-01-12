using DragDetails.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragDetails
{
    public static class Message
    {
        public static void ShowNewMessage(string message, string messageTitle)
        {
            var messageBox = new ErrorMessageBox();
            messageBox.Text = messageTitle;
            messageBox.Label.Text = message;
            messageBox.Width = messageBox.Label.Width + 50;
            messageBox.ShowDialog();
        }

        public static bool ShowNewMessageWwithDialogResult(string message, string messageTitle)
        {

            var messageBox = new ErrorMessageBox();
            messageBox.Text = messageTitle;
            messageBox.Label.Text = message;
            messageBox.Width = messageBox.Label.Width + 50;

            messageBox.Button.Visible = true;

            messageBox.ShowDialog();

            if (messageBox.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }
            return false;
        }
    }
}
