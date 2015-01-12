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
    public partial class Formatting : Form
    {
        public Formatting()
        {
            InitializeComponent();
            AcceptButton = button;
        }

        public float FontSize
        {
            get
            {
                float fontSize;
                try
                {
                    fontSize = (float)Convert.ToDouble(fontComboBox.Text);
                }
                catch
                {
                    fontSize = 8.25f;
                }
                return fontSize;
            }
        }

        public string Font
        {
            get
            {
                return fontStringComboBox.Text;
            }
        }
    }
}
