namespace FLStudioFolderCustomizer.UI.Dialogs
{
    partial class ColorListPickerDialog
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
            this.components = new System.ComponentModel.Container();
            this.lbColors = new System.Windows.Forms.ListBox();
            this.cmsColorList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddNewColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditSelectedColor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsColorList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbColors
            // 
            this.lbColors.ContextMenuStrip = this.cmsColorList;
            this.lbColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbColors.FormattingEnabled = true;
            this.lbColors.ItemHeight = 15;
            this.lbColors.Location = new System.Drawing.Point(12, 12);
            this.lbColors.Name = "lbColors";
            this.lbColors.Size = new System.Drawing.Size(210, 154);
            this.lbColors.TabIndex = 0;
            this.lbColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbColors_DrawItem);
            // 
            // cmsColorList
            // 
            this.cmsColorList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddNewColor,
            this.tsmiEditSelectedColor});
            this.cmsColorList.Name = "cmsColorList";
            this.cmsColorList.Size = new System.Drawing.Size(174, 48);
            // 
            // tsmiAddNewColor
            // 
            this.tsmiAddNewColor.Name = "tsmiAddNewColor";
            this.tsmiAddNewColor.Size = new System.Drawing.Size(173, 22);
            this.tsmiAddNewColor.Text = "Add New Color";
            this.tsmiAddNewColor.Click += new System.EventHandler(this.tsmiAddNewColor_Click);
            // 
            // tsmiEditSelectedColor
            // 
            this.tsmiEditSelectedColor.Name = "tsmiEditSelectedColor";
            this.tsmiEditSelectedColor.Size = new System.Drawing.Size(173, 22);
            this.tsmiEditSelectedColor.Text = "Edit Selected Color";
            this.tsmiEditSelectedColor.Click += new System.EventHandler(this.tsmiEditSelectedColor_Click);
            // 
            // ColorListPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 181);
            this.Controls.Add(this.lbColors);
            this.Name = "ColorListPickerDialog";
            this.Text = "Color List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorListPickerDialog_FormClosing);
            this.cmsColorList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbColors;
        private System.Windows.Forms.ContextMenuStrip cmsColorList;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewColor;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditSelectedColor;
    }
}