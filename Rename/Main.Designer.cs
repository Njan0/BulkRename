namespace Rename
{
    partial class Main
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
            this.LabelMatch = new System.Windows.Forms.Label();
            this.LabelReplace = new System.Windows.Forms.Label();
            this.TextBoxMatch = new System.Windows.Forms.TextBox();
            this.TextBoxReplace = new System.Windows.Forms.TextBox();
            this.ListViewIO = new System.Windows.Forms.ListView();
            this.ColumnOriginal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelMatch
            // 
            this.LabelMatch.AutoSize = true;
            this.LabelMatch.Location = new System.Drawing.Point(12, 9);
            this.LabelMatch.Name = "LabelMatch";
            this.LabelMatch.Size = new System.Drawing.Size(40, 13);
            this.LabelMatch.TabIndex = 0;
            this.LabelMatch.Text = "Match:";
            // 
            // LabelReplace
            // 
            this.LabelReplace.AutoSize = true;
            this.LabelReplace.Location = new System.Drawing.Point(12, 35);
            this.LabelReplace.Name = "LabelReplace";
            this.LabelReplace.Size = new System.Drawing.Size(50, 13);
            this.LabelReplace.TabIndex = 1;
            this.LabelReplace.Text = "Replace:";
            // 
            // TextBoxMatch
            // 
            this.TextBoxMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxMatch.Location = new System.Drawing.Point(68, 6);
            this.TextBoxMatch.Name = "TextBoxMatch";
            this.TextBoxMatch.Size = new System.Drawing.Size(335, 20);
            this.TextBoxMatch.TabIndex = 2;
            this.TextBoxMatch.Text = ".";
            this.TextBoxMatch.TextChanged += new System.EventHandler(this.TextBoxMatch_TextChanged);
            // 
            // TextBoxReplace
            // 
            this.TextBoxReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxReplace.Location = new System.Drawing.Point(68, 32);
            this.TextBoxReplace.Name = "TextBoxReplace";
            this.TextBoxReplace.Size = new System.Drawing.Size(335, 20);
            this.TextBoxReplace.TabIndex = 3;
            this.TextBoxReplace.Text = "$0";
            this.TextBoxReplace.TextChanged += new System.EventHandler(this.TextBoxReplace_TextChanged);
            // 
            // ListViewIO
            // 
            this.ListViewIO.AllowDrop = true;
            this.ListViewIO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnOriginal,
            this.ColumnNew});
            this.ListViewIO.FullRowSelect = true;
            this.ListViewIO.HideSelection = false;
            this.ListViewIO.Location = new System.Drawing.Point(15, 58);
            this.ListViewIO.Name = "ListViewIO";
            this.ListViewIO.Size = new System.Drawing.Size(388, 324);
            this.ListViewIO.TabIndex = 4;
            this.ListViewIO.UseCompatibleStateImageBehavior = false;
            this.ListViewIO.View = System.Windows.Forms.View.Details;
            this.ListViewIO.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListViewIO_DragDrop);
            this.ListViewIO.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListViewIO_DragEnter);
            this.ListViewIO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewIO_KeyDown);
            // 
            // ColumnOriginal
            // 
            this.ColumnOriginal.Text = "Original";
            this.ColumnOriginal.Width = 192;
            // 
            // ColumnNew
            // 
            this.ColumnNew.Text = "New";
            this.ColumnNew.Width = 192;
            // 
            // ButtonClear
            // 
            this.ButtonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonClear.Location = new System.Drawing.Point(15, 388);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 5;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonRename
            // 
            this.ButtonRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRename.Location = new System.Drawing.Point(328, 388);
            this.ButtonRename.Name = "ButtonRename";
            this.ButtonRename.Size = new System.Drawing.Size(75, 23);
            this.ButtonRename.TabIndex = 6;
            this.ButtonRename.Text = "Rename";
            this.ButtonRename.UseVisualStyleBackColor = true;
            this.ButtonRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 423);
            this.Controls.Add(this.ButtonRename);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ListViewIO);
            this.Controls.Add(this.TextBoxReplace);
            this.Controls.Add(this.TextBoxMatch);
            this.Controls.Add(this.LabelReplace);
            this.Controls.Add(this.LabelMatch);
            this.MinimumSize = new System.Drawing.Size(256, 256);
            this.Name = "Main";
            this.Text = "Bulk Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMatch;
        private System.Windows.Forms.Label LabelReplace;
        private System.Windows.Forms.TextBox TextBoxMatch;
        private System.Windows.Forms.TextBox TextBoxReplace;
        private System.Windows.Forms.ListView ListViewIO;
        private System.Windows.Forms.ColumnHeader ColumnOriginal;
        private System.Windows.Forms.ColumnHeader ColumnNew;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonRename;
    }
}

