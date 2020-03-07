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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (ListViewMR.SelectedItems.Count != 1)
                return;

            ListViewItem selection = ListViewMR.SelectedItems[0];

            RegexMatch = selection.SubItems[0].Text;
            RegexReplace = selection.SubItems[1].Text;
            Close();
        }
    }
}
