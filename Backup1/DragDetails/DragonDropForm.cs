using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DragDetails.Properties;
using System.Drawing;
using Oli.Controls;

namespace DragDetails
{
    public partial class DragonDropForm : Form
    {
        private static string CUTANDPASTEFILE;
        private static string FILE_EDITOR;
        private static readonly string FILTER = "txt files (*.txt)|*.txt";

        public DragonDropForm()
        {
            InitializeComponent();
            reposition();
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Console.WriteLine(desktopDir);
            Console.WriteLine(Settings.Default["defaultFile"]);

            //Console.WriteLine(Screen.PrimaryScreen.Bounds.Width);
            //Console.WriteLine(Screen.GetWorkingArea(this).Width);

            saveFileDialog1.Filter = FILTER;
            openFileDialog1.Filter = FILTER;
            openFileDialog1.InitialDirectory = desktopDir;
            CUTANDPASTEFILE = desktopDir + "/" + Settings.Default["defaultFile"];
            FILE_EDITOR = Settings.Default["fileEditor"] as string;
            try
            {
                StreamReader s = File.OpenText(CUTANDPASTEFILE);
                populateListBox(s);
                s.Close();
            }
            catch (Exception)
            {
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        populateListBox(new StreamReader(myStream));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter wText = new StreamWriter(myStream);
                    foreach (object line in listBox1.Items)
                    {
                        wText.WriteLine(line.ToString());
                    }
                    wText.Flush(); // http://zamov.online.fr/EXHTML/CSharp/CSharp_302155.html forgot this
                    myStream.Close();
                }
            }
        }


        private void populateListBox(TextReader s)
        {
            listBox1.Items.Clear();
            string line;
            do
            {
                line = s.ReadLine();
                if (line != null) listBox1.Items.Add(line);
            } while (line != null);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string selectedText = string.Empty; // = listBox1.SelectedItems.ToString();
                foreach (int i in listBox1.SelectedIndices)
                {
                    selectedText += listBox1.Items[i].ToString ().Trim () + Environment.NewLine;
                }
                Console.WriteLine(listBox1.SelectedIndices.Count + " items selected: " + selectedText);

                listBox1.DoDragDrop(selectedText, DragDropEffects.Copy | DragDropEffects.Move);
            } else if (e.Button == MouseButtons.Right)
            {
                //rtbFormattedArticleText.Text, true); 

                // http://forums.msdn.microsoft.com/en/csharpgeneral/thread/8de0c492-adb8-4d79-92bf-90643385925e/
                listBox1.SelectedIndex = (Convert.ToInt32(e.Y) / Convert.ToInt32(listBox1.ItemHeight)) + Convert.ToInt32(listBox1.TopIndex);
                Console.WriteLine("You want to copy " + listBox1.SelectedItem);
                Clipboard.SetDataObject(listBox1.SelectedItem, true);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        /// Move DragonDrop to top left of screen
        /// </summary>
        private void reposition()
        {
            Height = Screen.PrimaryScreen.Bounds.Height;
            OpenWindowGetter.MoveToTopLeft(Handle);
        }

        /// <summary>
        /// Want this window to appear next to another window, e.g. I.E.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileWithParentWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get some system info about which windows are on the screen
            // http://tommycarlier.blogspot.com/2006/05/getting-list-of-all-open-windows.html
            reposition();

            int ieHandle;
            int webYPos = 0;
            // Loop through each open window
            foreach (KeyValuePair<IntPtr, string> lWindow in OpenWindowGetter.GetOpenWindows())
            {
                IntPtr lHandle = lWindow.Key;
                string lTitle = lWindow.Value;

                // Ensure width of the Web browsers goes exactly to the end of the screen
                Console.WriteLine("{0}: {1}", lHandle, lTitle);
                if (lTitle.Contains("Windows Internet Explorer") || lTitle.Contains("Mozilla Firefox"))
                {
                    ieHandle = (int) lHandle;
                    bool isReposition = OpenWindowGetter.SetWindowPos(ieHandle, 
                        OpenWindowGetter.HWND_NOTOPMOST, this.Width, webYPos,
                        Screen.PrimaryScreen.Bounds.Width - this.Width,
                        Screen.PrimaryScreen.Bounds.Height - 20,
                        OpenWindowGetter.SWP_SHOWWINDOW);

                    Console.WriteLine("\tReposition {0}, {1}", lTitle, isReposition);

                    webYPos += 20;
                }
            }
        }

        private void addItem()
        {
            if (!string.IsNullOrEmpty(NewAdditionBox.Text))
            {
                listBox1.Items.Add(NewAdditionBox.Text);
                listBox1.ClearSelected();
                listBox1.SetSelected(listBox1.Items.Count - 1, true);
            }
        }


        private void ListBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            string item = listBox1.Items[e.Index].ToString();

            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;            
            Font fontToUse = e.Font;

            if (item.EndsWith(" "))
            {
                myBrush = Brushes.Purple;
                fontToUse = new Font(fontToUse.FontFamily, fontToUse.Size, FontStyle.Bold);
            }
           
           // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(item, fontToUse, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }



        private void AddButton_Click(object sender, EventArgs e)
        {
            addItem();
        }

        /// <summary>
        /// Want the item that user has clicked on to be deleted. But default is that the item is not selected
        /// http://www.msdner.com/dev-archive/129/2-8-1296442.shtm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("You wanna delete: " + listBox1.SelectedItem + listBox1.SelectedIndex);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    Console.WriteLine("You wanna delete: " + listBox1.SelectedItem);
                    listBox1.Items.RemoveAt(i);
                    if (i < listBox1.Items.Count)
                        listBox1.SetSelected(i, true);
                }
                else if (e.KeyCode == Keys.Up && i > 0)
                {
                    object o = listBox1.Items[i];
                    listBox1.Items.RemoveAt(i);
                    listBox1.Items.Insert(i - 1, o);
                    listBox1.SetSelected(i, true);
                }
                else if (e.KeyCode == Keys.Down && listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    object o = listBox1.Items[i];
                    listBox1.Items.RemoveAt(i);
                    listBox1.Items.Insert(i + 1, o);
                    listBox1.SetSelected(i, true);
                }
            }
        }

        private void NewAdditionBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                addItem();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 b = new AboutBox1();
            b.ShowDialog();
        }

        private void editFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(FILE_EDITOR, CUTANDPASTEFILE);
            //Process.Start(FILE_EDITOR);
            Application.Exit();
        }
    }
}