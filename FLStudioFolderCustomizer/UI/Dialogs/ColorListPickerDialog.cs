using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FLStudioFolderCustomizer.UI.Dialogs
{
    public partial class ColorListPickerDialog : Form
    {
        public List<Color> Colors { get; }

        public ColorListPickerDialog()
        {
            Colors = new List<Color>();
            InitializeComponent();
        }

        private Color GetColor(Color oldColor)
        {
            using (var dialog = oldColor == Color.Empty ? new ColorDialog() : new ColorDialog() { Color = oldColor })
                return dialog.ShowDialog() == DialogResult.OK ? dialog.Color : Color.Empty;
        }


        private void tsmiAddNewColor_Click(object sender, EventArgs e)
        {
            var newColor = GetColor(Color.Empty);
            if (newColor == Color.Empty)
                return;

            Colors.Add(newColor);
            lbColors.Items.Add(string.Empty);
        }

        private void tsmiEditSelectedColor_Click(object sender, EventArgs e)
        {
            if (lbColors.SelectedItems.Count == 0)
                return;
            var newColor = GetColor(Colors[lbColors.SelectedIndex]);
            if (newColor == Color.Empty)
                return;
            Colors[lbColors.SelectedIndex] = newColor;
        }

        private void lbColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, 0, e.ForeColor, Colors[e.Index]);
            e.DrawBackground();
            e.Graphics.DrawString(lbColors.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void ColorListPickerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
