using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DragDetails.Properties;
using System.Drawing;
using DragDetails.Forms;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace DragDetails
{
    public partial class DragonDropForm : Form
    {
        private static string CUTANDPASTEFILE;
        private int PIN;
        private static string FILE_EDITOR;

        public DragonDropForm()
        {
            InitializeComponent();

            //string currentDir = Environment.CurrentDirectory;
            //string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            CUTANDPASTEFILE = (string)Settings.Default["defaultFile"];//currentDir + "/" + Settings.Default["defaultFile"];
            FILE_EDITOR = Settings.Default["fileEditor"] as string;

            if (File.Exists(CUTANDPASTEFILE))
            {
                PIN = Login();
                PopulateTabs();
            }
        }

        private int Login()
        {
            int pin = 0;
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.DialogResult == DialogResult.OK && loginWindow.Pin != string.Empty)
            {
                try
                {
                    pin = Convert.ToInt32(loginWindow.Pin);
                }
                catch { }
            }
            return pin;
        }

        private void SaveToFile()
        {
            var tabPages = mainTabControl.TabPages;
            string savedFileString = string.Empty;

            foreach (TabPage page in tabPages)
            {
                savedFileString += "#" + page.Text + "\n";

                var innerText = page.Controls[0].Text;
                savedFileString += innerText + "\n";
            }

            savedFileString += "¬¦font=" + tabPages[0].Font.Name + "\n";
            savedFileString += "¬¦fontsize=" + tabPages[0].Font.Size;

            StreamWriter file = new System.IO.StreamWriter(CUTANDPASTEFILE);
            file.WriteLine(Cryptography.EncryptString(savedFileString, PIN));
            file.Close();
        }

        private void PopulateTabs()
        {
            string savedInformation = string.Empty;
            try
            {
                savedInformation = Cryptography.DecryptFile(CUTANDPASTEFILE, PIN);
                DisableOrEnableMenuStripItems(true);
            }
            catch
            {
                if (PIN != 13269565)
                {
                    Message.ShowNewMessage("Your secure PIN was entered incorrectly.", "Login Error");
                }
                DisableOrEnableMenuStripItems(false);
            }
            if (PIN == 13269565)
            {
                PIN = 0;
            }

            var splitSavedInformation = savedInformation.Split(new Char[] { '\n' });

            var fontString = splitSavedInformation[splitSavedInformation.Length - 1].Replace("¬¦fontsize=", string.Empty);
            string font = "Microsoft Sans Serif";
            try { font = splitSavedInformation[splitSavedInformation.Length - 2].Replace("¬¦font=", string.Empty); }
            catch { }
            float fontSize = 8.25f;
            try { fontSize = (float)Convert.ToDouble(fontString); }
            catch { }
            savedInformation = savedInformation.Replace("¬¦fontsize=" + fontString, string.Empty).Replace("¬¦font=" + font, string.Empty);
            splitSavedInformation = savedInformation.Split(new Char[] { '\n' });


            mainTabControl.TabPages.Clear();
            RichTextBox currentTabPageTextBox = new RichTextBox();

            foreach (var line in splitSavedInformation)
            {
                if (line.StartsWith("#"))
                {
                    currentTabPageTextBox = addNewTab(line.Replace("#", string.Empty));
                }
                else
                {
                    currentTabPageTextBox.AppendText(line + "\n");
                }
            }
            ChangeFontSize(font, fontSize);
        }

        private RichTextBox addNewTab(string tabName)
        {
            var newTab = new TabPage(tabName);
            var rtb = new RichTextBox();
            rtb.Click += new System.EventHandler(textBoxOnClick);

            rtb.WordWrap = false;
            rtb.AllowDrop = true;

            rtb.MouseLeave += (sender, e) =>
            {
                rtb.DoDragDrop(rtb.SelectedText, DragDropEffects.Copy | DragDropEffects.Move);
            };

            rtb.Size = mainTabControl.Size;
            rtb.Width = mainTabControl.Width - 5;
            rtb.Height = mainTabControl.Height - 25;

            newTab.Controls.Add(rtb);
            mainTabControl.TabPages.Add(newTab);

            return rtb;
        }

        private void ShowNewTabWindow()
        {
            var popup = new PopUpWindow();
            popup.setFormHeaderText("Add New Tab");
            popup.setPromptLabel("Please enter a title for your new tab");
            popup.ShowDialog();

            string newTabTitleText = popup.EnteredText;
            if (popup.DialogResult == DialogResult.OK)
            {
                addNewTab(newTabTitleText);
            }
            popup.Dispose();
        }

        private void textBoxOnClick(object sender, System.EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            string textToBeCopied;

            if (rtb.Lines.Length > 0)
            {
                if (rtb.SelectedText.Length > 0)
                {
                    System.Windows.Forms.Clipboard.SetText(rtb.SelectedText);
                }
                else
                {
                    int cursorPosition = rtb.SelectionStart;
                    int lineIndex = rtb.GetLineFromCharIndex(cursorPosition);
                    textToBeCopied = rtb.Lines[lineIndex];

                    if (textToBeCopied != string.Empty)
                    {
                        System.Windows.Forms.Clipboard.SetText(textToBeCopied);
                    }

                    int startPoint = rtb.GetFirstCharIndexFromLine(lineIndex);
                    rtb.Select(startPoint, textToBeCopied.Length);
                }
            }
        }



        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            HighlightSearchedText();
        }

        private void HighlightSearchedText()
        {
            var tabPages = mainTabControl.TabPages;

            foreach (TabPage page in tabPages)
            {
                RichTextBox rtb = (RichTextBox)page.Controls[0];

                if (rtb.Text != string.Empty)
                {
                    int index = 0;
                    String temp = rtb.Text;
                    rtb.Text = "";
                    rtb.Text = temp;
                    while (index < rtb.Text.LastIndexOf(searchBox.Text))
                    {
                        rtb.Find(searchBox.Text, index, rtb.TextLength, RichTextBoxFinds.None);
                        rtb.SelectionBackColor = Color.Yellow;
                        index = rtb.Text.IndexOf(searchBox.Text, index) + 1;
                        mainTabControl.SelectTab(page);
                        searchBox.Focus();
                    }
                }
            }
        }

        private void DisableOrEnableMenuStripItems(bool trueOrFalse)
        {
            saveSettingsToolStripMenuItem.Visible = trueOrFalse;
            addNewTabToolStripMenuItem.Visible = trueOrFalse;
            cancelChangesToolStripMenuItem.Visible = trueOrFalse;
            changeSecurePINToolStripMenuItem.Visible = trueOrFalse;
        }

        private void ChangePin()
        {
            var changePinWindow = new ChangePin();
            changePinWindow.ShowDialog();
            if (changePinWindow.DialogResult == DialogResult.OK)
            {
                if (changePinWindow.Text1.Text.Equals(changePinWindow.Text2.Text))
                {
                    if (changePinWindow.Text1.Text != string.Empty)
                    {
                        try
                        {
                            PIN = Convert.ToInt32(changePinWindow.Text1.Text);
                            Message.ShowNewMessage("Your PIN was successfully changed", "PIN");
                        }
                        catch
                        {
                            Message.ShowNewMessage("Your PIN was not changed. It must be numeric.", "Change PIN Error");
                        }
                    }
                    else
                    {
                        PIN = 0;
                        Message.ShowNewMessage("You no longer require a PIN to access Dragon Drop", "PIN");
                    }

                    SaveToFile();
                    DisableOrEnableMenuStripItems(true);
                }
                else
                {
                    Message.ShowNewMessage("Your PIN was not changed. They did not match.", "Change PIN Error");
                }
            }
        }

        private void CreateNewLibrary()
        {
            var createNewLibrary = new CreateNewFile();
            createNewLibrary.ShowDialog();

            if (createNewLibrary.DialogResult == DialogResult.OK)
            {
                PIN = createNewLibrary.NewPin;
                File.WriteAllText(CUTANDPASTEFILE, String.Empty);
                mainTabControl.TabPages.Clear();
                SaveToFile();
                PopulateTabs();
            }
        }

        private void ChangeFontSize(string font, float fontSize)
        {
            foreach (TabPage tab in mainTabControl.TabPages)
            {
                tab.Font = new Font(font, fontSize);
            }
        }

        /*
         * Onclick events
         */

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void addNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewTabWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PIN = Login();
            PopulateTabs();
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }
        private void changeSecurePINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePin();
        }

        private void cancelChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTabControl.TabPages.Clear();
            PopulateTabs();
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewLibrary();
        }

        private void tabControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < mainTabControl.TabCount; i++)
                {
                    Rectangle r = mainTabControl.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        DeleteTab(mainTabControl.TabPages[i]);
                    }
                }
            }
        }

        private void DeleteTab(TabPage currentTab)
        {

            if (Message.ShowNewMessageWwithDialogResult("Are you sure you want to delete the '" + currentTab.Text + "' tab from your library?", "Delete Tab"))
            {
                mainTabControl.TabPages.Remove(currentTab);
            }
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var information = new Information();
            information.ShowDialog();
        }

        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formatting = new Formatting();
            formatting.ShowDialog();
            if (formatting.DialogResult == DialogResult.OK)
            {
                ChangeFontSize(formatting.Font, formatting.FontSize);
            }
            formatting.Dispose();
        }

        private void DragonDropForm_Resize(object sender, EventArgs e)
        {
            foreach (TabPage tab in mainTabControl.TabPages)
            {
                var rtb = tab.Controls[0];
                rtb.Size = tab.Size;
            }
        }
    }
}