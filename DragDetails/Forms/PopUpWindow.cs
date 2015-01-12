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
    public partial class PopUpWindow : Form
    {
        public PopUpWindow()
        {
            InitializeComponent();
            AcceptButton = button1;
        }

        public string EnteredText
        {
            get
            {
                return (inputBox.Text);
            }
        }

        public void setPromptLabel(string text)
        {
            promptLabel.Text = text;
        }

        public void setFormHeaderText(string text)
        {
            this.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
