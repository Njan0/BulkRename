namespace Rename
{
    partial class TemplateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "^(.*)\\.(.*)$",
            "$1.$2",
            "Name+Extension"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "\\s+(\\s)",
            "$1",
            "Extra spaces"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "^(.*?)\\s+\\.(.*)$",
            "$1.$2",
            "Space after name"}, -1);
            this.ListViewMR = new System.Windows.Forms.ListView();
            this.ColumnMatch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnReplace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ColumnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ListViewMR
            // 
            this.ListViewMR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewMR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnMatch,
            this.ColumnReplace,
            this.ColumnDescription});
            this.ListViewMR.FullRowSelect = true;
            this.ListViewMR.HideSelection = false;
            this.ListViewMR.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.ListViewMR.Location = new System.Drawing.Point(9, 10);
            this.ListViewMR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ListViewMR.MultiSelect = false;
            this.ListViewMR.Name = "ListViewMR";
            this.ListViewMR.Size = new System.Drawing.Size(260, 264);
            this.ListViewMR.TabIndex = 0;
            this.ListViewMR.UseCompatibleStateImageBehavior = false;
            this.ListViewMR.View = System.Windows.Forms.View.Details;
            this.ListViewMR.SelectedIndexChanged += new System.EventHandler(this.ListViewMR_SelectedIndexChanged);
            // 
            // ColumnMatch
            // 
            this.ColumnMatch.Text = "Match";
            this.ColumnMatch.Width = 96;
            // 
            // ColumnReplace
            // 
            this.ColumnReplace.Text = "Replace";
            this.ColumnReplace.Width = 64;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Enabled = false;
            this.ButtonOK.Location = new System.Drawing.Point(192, 279);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 7;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(9, 279);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.Text = "Description";
            this.ColumnDescription.Width = 96;
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 312);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.ListViewMR);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TemplateForm";
            this.Text = "Templates";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewMR;
        private System.Windows.Forms.ColumnHeader ColumnMatch;
        private System.Windows.Forms.ColumnHeader ColumnReplace;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.ColumnHeader ColumnDescription;
    }
}