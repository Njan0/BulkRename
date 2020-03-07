using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rename
{
    public partial class Main : Form
    {
        const string ErrorName = "?";
        Regex RegexMatch;

        public Main()
        {
            InitializeComponent();
            UpdateRegexMatch();
        }

        private void ListViewIO_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
                e.Effect = DragDropEffects.Copy;
        }

        private void ListViewIO_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (!ContainsFile(file))
                {
                    string fileName = Path.GetFileName(file);
                    ListViewItem item = new ListViewItem(new string[] { fileName, "" })
                    {
                        Tag = file
                    };
                    RefreshIO(item);
                    ListViewIO.Items.Add(item);
                }
            }
        }

        private void ListViewIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem listViewItem in ListViewIO.SelectedItems)
                {
                    listViewItem.Remove();
                }
            }
        }

        /// <summary>
        /// Check if file was already added
        /// </summary>
        /// <param name="file">Full path of file</param>
        /// <returns>true iff file was already added</returns>
        private bool ContainsFile(string file)
        {
            foreach (ListViewItem item in ListViewIO.Items)
            {
                if ((string)item.Tag == file)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes a file from ListViewIO
        /// </summary>
        /// <param name="file">Full path of file</param>
        private void RemoveFile(string file)
        {
            foreach (ListViewItem item in ListViewIO.Items)
            {
                if ((string)item.Tag == file)
                {
                    item.Remove();
                    return;
                }
            }
        }

        /// <summary>
        /// Recalculates the output names of a elements in ListViewIO
        /// </summary>
        private void RefreshIO(ListViewItem item)
        {
            item.SubItems[1].Text = FileRegexReplace(item.SubItems[0].Text);

            if (!CheckFilename(item.SubItems[1].Text))
                item.BackColor = Color.Red;
            else if (item.SubItems[0].Text == item.SubItems[1].Text)
                item.BackColor = Color.Yellow;
            else
                item.BackColor = SystemColors.Window;
        }

        /// <summary>
        /// Recalculates the output names of all elements in ListViewIO
        /// </summary>
        private void RefreshIO()
        {
            foreach(ListViewItem item in ListViewIO.Items)
            {
                RefreshIO(item);
            }
        }

        /// <summary>
        /// Check if given filename is valid
        /// </summary>
        /// <param name="name">Potential file name</param>
        /// <returns>true iff file name is valid</returns>
        private bool CheckFilename(string name)
        {
            if (name.Contains('\\') || name.Contains('/'))
                return false;

            try
            {
                FileInfo fi = new System.IO.FileInfo(name);
                return true;
            }
            catch (ArgumentException) { }
            catch (PathTooLongException) { }
            catch (NotSupportedException) { }

            return false;
        }

        /// <summary>
        /// Apply the expression in TextBoxMatch and TextBoxReplace on Input
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Input replaced using the given regular expressions</returns>
        private string FileRegexReplace(string input)
        {
            if (RegexMatch == null)
                return ErrorName;

            return RegexMatch.Replace(input, TextBoxReplace.Text);
        }
        
        private void TextBoxMatch_TextChanged(object sender, EventArgs e)
        {
            UpdateRegexMatch();
        }

        /// <summary>
        /// Convert text in TextBoxMatch to a Regex object.
        /// Invalid expressions are marked and disables the rename button.
        /// </summary>
        private void UpdateRegexMatch()
        {
            try
            {
                RegexMatch = new Regex(TextBoxMatch.Text);
                TextBoxMatch.ForeColor = SystemColors.WindowText;
                ButtonRename.Enabled = true;
            }
            catch (ArgumentException)
            {
                RegexMatch = null;
                TextBoxMatch.ForeColor = Color.Red;
                ButtonRename.Enabled = false;
            }
            RefreshIO();
        }

        private void TextBoxReplace_TextChanged(object sender, EventArgs e)
        {
            RefreshIO();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ListViewIO.Items.Clear();
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {
            if (RegexMatch == null)
                return;

            Dictionary<string, string> moveDict = new Dictionary<string, string>();
            HashSet<string> usedNames = new HashSet<string>();
            foreach (ListViewItem item in ListViewIO.Items)
            {
                string file = (string)item.Tag;
                string dir = Path.GetDirectoryName(file);
                string oldName = item.SubItems[0].Text;
                string newName = item.SubItems[1].Text;
                string target = Path.Combine(dir, newName);

                if (CheckFilename(newName) && oldName != newName)
                {
                    moveDict[file] = target;

                    // check for collisions
                    if (!usedNames.Add(target))
                    {
                        MessageBox.Show("Can not move file '" + file + "' to '" + target + "'.", "Collision error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                usedNames.Add(file);
            }

            foreach (KeyValuePair<string, string> entry in moveDict)
            {
                if (entry.Key != entry.Value)
                {
                    try
                    {
                        if (Directory.Exists(entry.Key))
                        {
                            Directory.Move(entry.Key, entry.Value);
                        }
                        else
                        {
                            File.Move(entry.Key, entry.Value);
                        }
                        RemoveFile(entry.Key);
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("Can not move '" + entry.Key + "' to '" + entry.Value + "'. " + ex.Message, "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                            return;
                    }
                }
            }
        }

        private void ButtonTemplate_Click(object sender, EventArgs e)
        {
            TemplateForm tf = new TemplateForm();
            tf.ShowDialog();
            if (tf.RegexMatch != null && tf.RegexReplace != null)
            {
                TextBoxMatch.Text = tf.RegexMatch;
                TextBoxReplace.Text = tf.RegexReplace;
            }
        }
    }
}
