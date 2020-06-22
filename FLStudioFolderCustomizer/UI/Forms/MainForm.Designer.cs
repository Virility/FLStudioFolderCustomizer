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
            this.tsmiCreateNFOFileForSelectedFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteNFOFileForSelectedFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInterpolateColorsFromBeginningToSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInterpolateColorsFromBeginningToEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.pgFLFolder = new System.Windows.Forms.PropertyGrid();
            this.lbRootFolder = new System.Windows.Forms.Label();
            this.tbRootFolder = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvFLFolder = new System.Windows.Forms.ListView();
            this.chDirectoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNFOFileExists = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNameIsCompliant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbInterpolationModes = new System.Windows.Forms.ComboBox();
            this.lbInterpolatorMode = new System.Windows.Forms.Label();
            this.bDecrementGlyphImageIndex = new System.Windows.Forms.Button();
            this.pGlyph = new System.Windows.Forms.Panel();
            this.tbImageIndex = new System.Windows.Forms.TextBox();
            this.bEncrementGlyphImageIndex = new System.Windows.Forms.Button();
            this.bSetImageToCurrentDirectory = new System.Windows.Forms.Button();
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
            this.tsmiCreateNFOFileForSelectedFolder,
            this.tsmiDeleteNFOFileForSelectedFolder,
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
            // tsmiCreateNFOFileForSelectedFolder
            // 
            this.tsmiCreateNFOFileForSelectedFolder.Name = "tsmiCreateNFOFileForSelectedFolder";
            this.tsmiCreateNFOFileForSelectedFolder.Size = new System.Drawing.Size(429, 22);
            this.tsmiCreateNFOFileForSelectedFolder.Text = "Create NFO File For Selected Folder";
            this.tsmiCreateNFOFileForSelectedFolder.Click += new System.EventHandler(this.tsmiCreateNFOFileForFolder_Click);
            // 
            // tsmiDeleteNFOFileForSelectedFolder
            // 
            this.tsmiDeleteNFOFileForSelectedFolder.Name = "tsmiDeleteNFOFileForSelectedFolder";
            this.tsmiDeleteNFOFileForSelectedFolder.Size = new System.Drawing.Size(429, 22);
            this.tsmiDeleteNFOFileForSelectedFolder.Text = "Delete NFO File For Selected Folder";
            this.tsmiDeleteNFOFileForSelectedFolder.Click += new System.EventHandler(this.tsmiDeleteNFOFileForSelectedFolder_Click);
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
            this.pgFLFolder.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pgFLFolder.Name = "pgFLFolder";
            this.pgFLFolder.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgFLFolder.Size = new System.Drawing.Size(2104, 584);
            this.pgFLFolder.TabIndex = 2;
            this.pgFLFolder.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PgFLFolder_PropertyValueChanged);
            // 
            // lbRootFolder
            // 
            this.lbRootFolder.AutoSize = true;
            this.lbRootFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(103)))));
            this.lbRootFolder.Location = new System.Drawing.Point(27, 19);
            this.lbRootFolder.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbRootFolder.Name = "lbRootFolder";
            this.lbRootFolder.Size = new System.Drawing.Size(437, 31);
            this.lbRootFolder.TabIndex = 3;
            this.lbRootFolder.Text = "Root Folder (Double Click to Open)";
            // 
            // tbRootFolder
            // 
            this.tbRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootFolder.Location = new System.Drawing.Point(27, 55);
            this.tbRootFolder.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbRootFolder.Name = "tbRootFolder";
            this.tbRootFolder.Size = new System.Drawing.Size(2097, 38);
            this.tbRootFolder.TabIndex = 4;
            this.tbRootFolder.DoubleClick += new System.EventHandler(this.tbRootFolder_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(27, 196);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
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
            this.splitContainer1.Size = new System.Drawing.Size(2104, 980);
            this.splitContainer1.SplitterDistance = 389;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // lvFLFolder
            // 
            this.lvFLFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.lvFLFolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDirectoryName,
            this.chNFOFileExists,
            this.chNameIsCompliant});
            this.lvFLFolder.ContextMenuStrip = this.cmsFLFolder;
            this.lvFLFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFLFolder.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvFLFolder.FullRowSelect = true;
            this.lvFLFolder.HideSelection = false;
            this.lvFLFolder.Location = new System.Drawing.Point(0, 0);
            this.lvFLFolder.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lvFLFolder.Name = "lvFLFolder";
            this.lvFLFolder.OwnerDraw = true;
            this.lvFLFolder.Size = new System.Drawing.Size(2104, 389);
            this.lvFLFolder.TabIndex = 0;
            this.lvFLFolder.UseCompatibleStateImageBehavior = false;
            this.lvFLFolder.View = System.Windows.Forms.View.Details;
            this.lvFLFolder.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvFLFolder_DrawColumnHeader);
            this.lvFLFolder.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvFLFolder_DrawItem);
            this.lvFLFolder.SelectedIndexChanged += new System.EventHandler(this.lvFLFolder_SelectedIndexChanged);
            this.lvFLFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFLFolder_KeyDown);
            // 
            // chDirectoryName
            // 
            this.chDirectoryName.Text = "Directory Name";
            this.chDirectoryName.Width = 282;
            // 
            // chNFOFileExists
            // 
            this.chNFOFileExists.Text = "NFO File Exists";
            this.chNFOFileExists.Width = 156;
            // 
            // chNameIsCompliant
            // 
            this.chNameIsCompliant.Text = "Name is Compliant";
            this.chNameIsCompliant.Width = 180;
            // 
            // cbInterpolationModes
            // 
            this.cbInterpolationModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterpolationModes.FormattingEnabled = true;
            this.cbInterpolationModes.Location = new System.Drawing.Point(27, 143);
            this.cbInterpolationModes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbInterpolationModes.Name = "cbInterpolationModes";
            this.cbInterpolationModes.Size = new System.Drawing.Size(561, 39);
            this.cbInterpolationModes.TabIndex = 6;
            // 
            // lbInterpolatorMode
            // 
            this.lbInterpolatorMode.AutoSize = true;
            this.lbInterpolatorMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(152)))), ((int)(((byte)(103)))));
            this.lbInterpolatorMode.Location = new System.Drawing.Point(27, 110);
            this.lbInterpolatorMode.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbInterpolatorMode.Name = "lbInterpolatorMode";
            this.lbInterpolatorMode.Size = new System.Drawing.Size(226, 31);
            this.lbInterpolatorMode.TabIndex = 3;
            this.lbInterpolatorMode.Text = "Interpolator Mode";
            // 
            // bDecrementGlyphImageIndex
            // 
            this.bDecrementGlyphImageIndex.Location = new System.Drawing.Point(1174, 107);
            this.bDecrementGlyphImageIndex.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bDecrementGlyphImageIndex.Name = "bDecrementGlyphImageIndex";
            this.bDecrementGlyphImageIndex.Size = new System.Drawing.Size(62, 75);
            this.bDecrementGlyphImageIndex.TabIndex = 7;
            this.bDecrementGlyphImageIndex.Text = "<";
            this.bDecrementGlyphImageIndex.UseVisualStyleBackColor = true;
            this.bDecrementGlyphImageIndex.Click += new System.EventHandler(this.bDecrementGlyphImageIndex_Click);
            // 
            // pGlyph
            // 
            this.pGlyph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pGlyph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGlyph.Location = new System.Drawing.Point(1248, 107);
            this.pGlyph.Name = "pGlyph";
            this.pGlyph.Size = new System.Drawing.Size(99, 75);
            this.pGlyph.TabIndex = 8;
            // 
            // tbImageIndex
            // 
            this.tbImageIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImageIndex.Location = new System.Drawing.Point(1432, 107);
            this.tbImageIndex.MinimumSize = new System.Drawing.Size(4, 75);
            this.tbImageIndex.Multiline = true;
            this.tbImageIndex.Name = "tbImageIndex";
            this.tbImageIndex.ReadOnly = true;
            this.tbImageIndex.Size = new System.Drawing.Size(249, 75);
            this.tbImageIndex.TabIndex = 9;
            // 
            // bEncrementGlyphImageIndex
            // 
            this.bEncrementGlyphImageIndex.Location = new System.Drawing.Point(1359, 107);
            this.bEncrementGlyphImageIndex.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bEncrementGlyphImageIndex.Name = "bEncrementGlyphImageIndex";
            this.bEncrementGlyphImageIndex.Size = new System.Drawing.Size(62, 75);
            this.bEncrementGlyphImageIndex.TabIndex = 7;
            this.bEncrementGlyphImageIndex.Text = ">";
            this.bEncrementGlyphImageIndex.UseVisualStyleBackColor = true;
            this.bEncrementGlyphImageIndex.Click += new System.EventHandler(this.bEncrementGlyphImageIndex_Click);
            // 
            // bSetImageToCurrentDirectory
            // 
            this.bSetImageToCurrentDirectory.Location = new System.Drawing.Point(1689, 107);
            this.bSetImageToCurrentDirectory.Name = "bSetImageToCurrentDirectory";
            this.bSetImageToCurrentDirectory.Size = new System.Drawing.Size(435, 75);
            this.bSetImageToCurrentDirectory.TabIndex = 10;
            this.bSetImageToCurrentDirectory.Text = "Set Image to Current Directory";
            this.bSetImageToCurrentDirectory.UseVisualStyleBackColor = true;
            this.bSetImageToCurrentDirectory.Click += new System.EventHandler(this.bSetImageToCurrentDirectory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(2160, 1196);
            this.Controls.Add(this.bSetImageToCurrentDirectory);
            this.Controls.Add(this.tbImageIndex);
            this.Controls.Add(this.pGlyph);
            this.Controls.Add(this.bEncrementGlyphImageIndex);
            this.Controls.Add(this.bDecrementGlyphImageIndex);
            this.Controls.Add(this.cbInterpolationModes);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tbRootFolder);
            this.Controls.Add(this.lbInterpolatorMode);
            this.Controls.Add(this.lbRootFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateNFOFileForSelectedFolder;
        private System.Windows.Forms.TextBox tbRootFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvFLFolder;
        private System.Windows.Forms.ColumnHeader chDirectoryName;
        private System.Windows.Forms.ColumnHeader chNFOFileExists;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteNFOFileForSelectedFolder;
        private System.Windows.Forms.ComboBox cbInterpolationModes;
        private System.Windows.Forms.Label lbInterpolatorMode;
        private System.Windows.Forms.ColumnHeader chNameIsCompliant;
        private System.Windows.Forms.Button bDecrementGlyphImageIndex;
        private System.Windows.Forms.Panel pGlyph;
        private System.Windows.Forms.TextBox tbImageIndex;
        private System.Windows.Forms.Button bEncrementGlyphImageIndex;
        private System.Windows.Forms.Button bSetImageToCurrentDirectory;
    }
}

