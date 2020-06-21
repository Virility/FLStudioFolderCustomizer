namespace FLStudioFolderCustomizer.UI.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmsFLFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateNFOForSelectedFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteNFOForSelectedFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInterpolateColorsFromBeginningToSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInterpolateColorsFromBeginningToEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.pgFLFolder = new System.Windows.Forms.PropertyGrid();
            this.lbRootFolder = new System.Windows.Forms.Label();
            this.tbRootFolder = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvFLFolder = new System.Windows.Forms.ListView();
            this.chDirectoryName = new System.Windows.Forms.ColumnHeader();
            this.chNFOFileExists = new System.Windows.Forms.ColumnHeader();
            this.cbInterpolationModes = new System.Windows.Forms.ComboBox();
            this.lbInterpolatorMode = new System.Windows.Forms.Label();
            this.cmsFLFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsFLFolder
            // 
            this.cmsFLFolder.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsFLFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateFolder,
            this.tsmiCreateNFOForSelectedFolder,
            this.tsmiDeleteNFOForSelectedFolder,
            this.tsmiInterpolateColorsFromBeginningToSelection,
            this.tsmiInterpolateColorsFromBeginningToEnd});
            this.cmsFLFolder.Name = "cmsFLFolder";
            this.cmsFLFolder.Size = new System.Drawing.Size(430, 114);
            // 
            // tsmiCreateFolder
            // 
            this.tsmiCreateFolder.Name = "tsmiCreateFolder";
            this.tsmiCreateFolder.Size = new System.Drawing.Size(429, 22);
            this.tsmiCreateFolder.Text = "Create Folder";
            this.tsmiCreateFolder.Click += new System.EventHandler(this.tsmiCreateFolder_Click);
            // 
            // tsmiCreateNFOForSelectedFolder
            // 
            this.tsmiCreateNFOForSelectedFolder.Name = "tsmiCreateNFOForSelectedFolder";
            this.tsmiCreateNFOForSelectedFolder.Size = new System.Drawing.Size(429, 22);
            this.tsmiCreateNFOForSelectedFolder.Text = "Create NFO For Selected Folder";
            this.tsmiCreateNFOForSelectedFolder.Click += new System.EventHandler(this.tsmiCreateNFOForFolder_Click);
            // 
            // tsmiDeleteNFOForSelectedFolder
            // 
            this.tsmiDeleteNFOForSelectedFolder.Name = "tsmiDeleteNFOForSelectedFolder";
            this.tsmiDeleteNFOForSelectedFolder.Size = new System.Drawing.Size(429, 22);
            this.tsmiDeleteNFOForSelectedFolder.Text = "Delete NFO For Selected Folder";
            this.tsmiDeleteNFOForSelectedFolder.Click += new System.EventHandler(this.tsmiDeleteNFOForSelectedFolder_Click);
            // 
            // tsmiInterpolateColorsFromBeginningToSelection
            // 
            this.tsmiInterpolateColorsFromBeginningToSelection.Name = "tsmiInterpolateColorsFromBeginningToSelection";
            this.tsmiInterpolateColorsFromBeginningToSelection.Size = new System.Drawing.Size(429, 22);
            this.tsmiInterpolateColorsFromBeginningToSelection.Text = "Interpolate Colors (from Beginning of Selection to End of Selection)";
            this.tsmiInterpolateColorsFromBeginningToSelection.Click += new System.EventHandler(this.tsmiInterpolateColorsFromBeginningToSelection_Click);
            // 
            // tsmiInterpolateColorsFromBeginningToEnd
            // 
            this.tsmiInterpolateColorsFromBeginningToEnd.Name = "tsmiInterpolateColorsFromBeginningToEnd";
            this.tsmiInterpolateColorsFromBeginningToEnd.Size = new System.Drawing.Size(429, 22);
            this.tsmiInterpolateColorsFromBeginningToEnd.Text = "Interpolate Colors (from Beginning to End)";
            this.tsmiInterpolateColorsFromBeginningToEnd.Click += new System.EventHandler(this.tsmiInterpolateColorsFromBeginningToEnd_Click);
            // 
            // pgFLFolder
            // 
            this.pgFLFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgFLFolder.Location = new System.Drawing.Point(0, 0);
            this.pgFLFolder.Name = "pgFLFolder";
            this.pgFLFolder.Size = new System.Drawing.Size(486, 196);
            this.pgFLFolder.TabIndex = 2;
            this.pgFLFolder.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgFLFolder_PropertyValueChanged);
            // 
            // lbRootFolder
            // 
            this.lbRootFolder.AutoSize = true;
            this.lbRootFolder.Location = new System.Drawing.Point(12, 9);
            this.lbRootFolder.Name = "lbRootFolder";
            this.lbRootFolder.Size = new System.Drawing.Size(192, 15);
            this.lbRootFolder.TabIndex = 3;
            this.lbRootFolder.Text = "Root Folder (Double Click to Open)";
            // 
            // tbRootFolder
            // 
            this.tbRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootFolder.Location = new System.Drawing.Point(12, 27);
            this.tbRootFolder.Name = "tbRootFolder";
            this.tbRootFolder.Size = new System.Drawing.Size(486, 23);
            this.tbRootFolder.TabIndex = 4;
            this.tbRootFolder.DoubleClick += new System.EventHandler(this.tbRootFolder_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 96);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvFLFolder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgFLFolder);
            this.splitContainer1.Size = new System.Drawing.Size(486, 333);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // lvFLFolder
            // 
            this.lvFLFolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDirectoryName,
            this.chNFOFileExists});
            this.lvFLFolder.ContextMenuStrip = this.cmsFLFolder;
            this.lvFLFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFLFolder.FullRowSelect = true;
            this.lvFLFolder.HideSelection = false;
            this.lvFLFolder.Location = new System.Drawing.Point(0, 0);
            this.lvFLFolder.Name = "lvFLFolder";
            this.lvFLFolder.Size = new System.Drawing.Size(486, 133);
            this.lvFLFolder.TabIndex = 0;
            this.lvFLFolder.UseCompatibleStateImageBehavior = false;
            this.lvFLFolder.View = System.Windows.Forms.View.Details;
            this.lvFLFolder.SelectedIndexChanged += new System.EventHandler(this.lvFLFolder_SelectedIndexChanged);
            this.lvFLFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFLFolder_KeyDown);
            // 
            // chDirectoryName
            // 
            this.chDirectoryName.Text = "Directory Name";
            this.chDirectoryName.Width = 230;
            // 
            // chNFOFileExists
            // 
            this.chNFOFileExists.Text = "NFO File Exists";
            this.chNFOFileExists.Width = 230;
            // 
            // cbInterpolationModes
            // 
            this.cbInterpolationModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterpolationModes.FormattingEnabled = true;
            this.cbInterpolationModes.Location = new System.Drawing.Point(12, 69);
            this.cbInterpolationModes.Margin = new System.Windows.Forms.Padding(1);
            this.cbInterpolationModes.Name = "cbInterpolationModes";
            this.cbInterpolationModes.Size = new System.Drawing.Size(248, 23);
            this.cbInterpolationModes.TabIndex = 6;
            // 
            // lbInterpolatorMode
            // 
            this.lbInterpolatorMode.AutoSize = true;
            this.lbInterpolatorMode.Location = new System.Drawing.Point(12, 53);
            this.lbInterpolatorMode.Name = "lbInterpolatorMode";
            this.lbInterpolatorMode.Size = new System.Drawing.Size(103, 15);
            this.lbInterpolatorMode.TabIndex = 3;
            this.lbInterpolatorMode.Text = "Interpolator Mode";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 441);
            this.Controls.Add(this.cbInterpolationModes);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tbRootFolder);
            this.Controls.Add(this.lbInterpolatorMode);
            this.Controls.Add(this.lbRootFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FL Studio Folder Customizer";
            this.cmsFLFolder.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PropertyGrid pgFLFolder;
        private System.Windows.Forms.ContextMenuStrip cmsFLFolder;
        private System.Windows.Forms.Label lbRootFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiInterpolateColorsFromBeginningToEnd;
        private System.Windows.Forms.ToolStripMenuItem tsmiInterpolateColorsFromBeginningToSelection;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateNFOForSelectedFolder;
        private System.Windows.Forms.TextBox tbRootFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvFLFolder;
        private System.Windows.Forms.ColumnHeader chDirectoryName;
        private System.Windows.Forms.ColumnHeader chNFOFileExists;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteNFOForSelectedFolder;
        private System.Windows.Forms.ComboBox cbInterpolationModes;
        private System.Windows.Forms.Label lbInterpolatorMode;
    }
}

