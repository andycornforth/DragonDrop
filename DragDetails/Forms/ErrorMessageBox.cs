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
    public partial class ErrorMessageBox : Form
    {
        public ErrorMessageBox()
        {
            InitializeComponent();
            button.Visible = false;
            AcceptButton = button;
        }

        public Label Label
        {
            get
            {
                return label;
            }
        }

        public Button Button
        {
            get
            {
                return button;
            }
        }

        private void ErrorMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
