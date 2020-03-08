using System;
using System.Windows.Forms;

namespace Rename
{
    public partial class TemplateForm : Form
    {
        public string RegexMatch { get; private set; }
        public string RegexReplace { get; private set; }

        public TemplateForm()
        {
            InitializeComponent();
            RegexMatch = null;
            RegexReplace = null;
        }

        private void ListViewMR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonOK.Enabled = ListViewMR.SelectedItems.Count > 0;
        }

        private void ListViewMR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = ListViewMR.HitTest(e.X, e.Y).Item;

            if (item != null)
            {
                Submit(item.SubItems[0].Text, item.SubItems[1].Text);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (ListViewMR.SelectedItems.Count != 1)
                return;

            ListViewItem selection = ListViewMR.SelectedItems[0];
            Submit(selection.SubItems[0].Text, selection.SubItems[1].Text);
        }

        /// <summary>
        /// Store match/replace and close form.
        /// </summary>
        private void Submit(string match, string replace)
        {
            RegexMatch = match;
            RegexReplace = replace;
            Close();
        }
    }
}
