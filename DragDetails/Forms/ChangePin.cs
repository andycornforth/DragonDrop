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
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
            box1.PasswordChar = '-';
            box2.PasswordChar = '-';
            AcceptButton = button1;
        }

        public TextBox Text1
        {
            get
            {
                return box1;
            }
        }

        public TextBox Text2
        {
            get
            {
                return box2;
            }
        }
    }
}
