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

        public Main()
        {
            InitializeComponent();
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
                    ListViewItem item = new ListViewItem(new string[] { fileName, FileRegexReplace(fileName) })
                    {
                        Tag = file
                    };
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
        /// Recalculates the output names of all elements in ListViewIO
        /// </summary>
        private void RefreshOut()
        {
            foreach(ListViewItem item in ListViewIO.Items)
            {
                item.SubItems[1].Text = FileRegexReplace(item.SubItems[0].Text);
            }
        }

        /// <summary>
        /// Apply the expression in TextBoxMatch and TextBoxReplace on Input
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Input replaced using the given regular expressions</returns>
        private string FileRegexReplace(string input)
        {
            try
            {
                string rgxIn = CheckBoxEntire.Checked ? EncloseRegex(TextBoxMatch.Text) : TextBoxMatch.Text;
                if (Regex.IsMatch(input, rgxIn) || !CheckBoxEntire.Checked)
                {
                    return Regex.Replace(input, rgxIn, TextBoxReplace.Text);
                }
            }
            catch (ArgumentException)
            {

            }
            return ErrorName;
        }

        /// <summary>
        /// Checks for a valid regex match
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>true iff non-entire match or match successfull</returns>
        private bool FileRegexMatch(string input)
        {
            return !CheckBoxEntire.Checked || Regex.IsMatch(input, EncloseRegex(TextBoxMatch.Text));
        }

        /// <summary>
        /// Enclose the regex with a ^ and a $
        /// </summary>
        /// <param name="rgx">Regex to enclose</param>
        /// <returns>^rgx$</returns>
        private string EncloseRegex(string rgx)
        {
            if (!rgx.StartsWith("^"))
                rgx = "^" + rgx;
            if (!rgx.EndsWith("$"))
                rgx += "$";

            return rgx;
        }

        private void TextBoxMatch_TextChanged(object sender, EventArgs e)
        {
            RefreshOut();
        }

        private void TextBoxReplace_TextChanged(object sender, EventArgs e)
        {
            RefreshOut();
        }

        private void CheckBoxEntire_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOut();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ListViewIO.Items.Clear();
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> moveDict = new Dictionary<string, string>();
            HashSet<string> usedNames = new HashSet<string>();
            foreach (ListViewItem item in ListViewIO.Items)
            {
                string file = (string)item.Tag;
                string dir = Path.GetDirectoryName(file);
                string oldName = item.SubItems[0].Text;
                string newName = item.SubItems[1].Text;
                string target = Path.Combine(dir, newName);

                moveDict[file] = target;

                // check for matching error
                if (!FileRegexMatch(oldName))
                {
                    MessageBox.Show("Can not match '" + oldName + "'.", "Matching error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // check for collisions
                if (!usedNames.Add(target))
                {
                    MessageBox.Show("Can not move file '" + file + "' to '" + target + "'.", "Collision error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show("Can not move '" + entry.Key + "' to '" + entry.Value + "'. " + ex.Message, "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                            return;
                    }
                }

                RemoveFile(entry.Key);
            }
        }
    }
}
