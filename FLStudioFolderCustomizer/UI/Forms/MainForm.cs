using FLStudioFolderCustomizer.Core.Extensions;
using FLStudioFolderCustomizer.Core.Models.ColorHelpers;
using FLStudioFolderCustomizer.Core.Models.Colors;
using FLStudioFolderCustomizer.Models;
using FLStudioFolderCustomizer.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FLStudioFolderCustomizer.UI.Forms
{
    public partial class MainForm : Form
    {
        private const string DefaultRootPath = "DefaultRootPath.txt";
        private readonly Dictionary<string, ColorInterpolater> _interpolaters;

        public MainForm()
        {
            _interpolaters = new Dictionary<string, ColorInterpolater>
            {
                { ColorBlend.Name, new ColorBlend() },
                { ColorSplit.Name, new ColorSplit() }
            };

            InitializeComponent();

            var interpolationStrings = _interpolaters
                .Select(interpolater => interpolater.Value.ToString())
                .ToArray();
            cbInterpolationModes.Items.AddRange(interpolationStrings);
            cbInterpolationModes.SelectedIndex = 0;

            LoadFromDirectory(string.Empty);
        }

        private void LoadFromDirectory(string rootFolder)
        {
            if (string.IsNullOrWhiteSpace(rootFolder)) {
                if (File.Exists(DefaultRootPath))
                {
                    rootFolder = File.ReadAllText(DefaultRootPath);
                    if (string.IsNullOrWhiteSpace(rootFolder))
                        return;
                }
                else
                    return;
            }

            tbRootFolder.Text = rootFolder;
            File.WriteAllText(DefaultRootPath, rootFolder);

            lvFLFolder.BeginUpdate();
            foreach (var directory in Directory.GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly))
            {
                var title = directory.Replace(rootFolder + "\\", string.Empty);
                FLFolder folder;
                var nfoPath = Path.Combine(directory + ".nfo");
                if (File.Exists(nfoPath))
                    folder = FLFolder.FromNFO(title, File.ReadAllLines(nfoPath));
                else
                    folder = new FLFolder() { FolderName = title };
                lvFLFolder.Items.Add(new FLFolderViewItem(rootFolder, folder));
            }
            lvFLFolder.EndUpdate();
        }

        private void tbRootFolder_DoubleClick(object sender, EventArgs e)
        {
            lvFLFolder.Items.Clear();

            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                LoadFromDirectory(dialog.SelectedPath);
        }

        private void lvFLFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.A || !e.Control)
                return;

            foreach (ListViewItem item in lvFLFolder.Items)
                item.Selected = true;
            e.SuppressKeyPress = true;
        }

        private void lvFLFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFLFolder.SelectedItems.Count == 0)
                return;

            var flFolderViewItem = lvFLFolder.SelectedItems[0] as FLFolderViewItem;
            if (flFolderViewItem.Folder.NFOExists(tbRootFolder.Text))
                pgFLFolder.SelectedObject = flFolderViewItem.Folder;
            else
                pgFLFolder.SelectedObject = null;
        }

        private void pgFLFolder_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var flFolderViewItem = lvFLFolder.SelectedItems[0] as FLFolderViewItem;
            flFolderViewItem.Folder = pgFLFolder.SelectedObject as FLFolder;

            var directoryPath = Path.Combine(tbRootFolder.Text, e.OldValue.ToString());
            if (Directory.Exists(directoryPath) && Directory.GetFiles(directoryPath).Length == 0)
                Directory.Delete(directoryPath);

            var nfoPath = Path.Combine(tbRootFolder.Text, e.OldValue.ToString() + ".nfo");
            if (File.Exists(nfoPath))
                File.Delete(nfoPath);

            CreateOrRenameNFO(flFolderViewItem.Folder);
            flFolderViewItem.Update();
        }

        private void CreateOrRenameNFO(FLFolder folder)
        {
            var directoryPath = Path.Combine(tbRootFolder.Text, folder.GetSafeTitle());
            var nfoPath = Path.Combine(tbRootFolder.Text, folder.GetNFOFileName());

            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(nfoPath, folder.ToNFO());
        }

        private void tsmiCreateFolder_Click(object sender, EventArgs e)
        {
            var folder = new FLFolder();
            var flFolderViewItems = lvFLFolder.Items.Cast<FLFolderViewItem>();
            for (int i = 0; true; i++)
            {
                var title = folder + (i != 0 ? " #" + (i + 1).ToString() : string.Empty);
                if (!flFolderViewItems.Any(item => item.Folder.FolderName == title))
                {
                    folder.FolderName = title;
                    break;
                }
            }
            CreateOrRenameNFO(folder);
            lvFLFolder.Items.Add(new FLFolderViewItem(tbRootFolder.Text, folder));
        }

        private void tsmiCreateNFOForFolder_Click(object sender, EventArgs e)
        {
            lvFLFolder.BeginUpdate();
            foreach (FLFolderViewItem flFolderViewItem in lvFLFolder.SelectedItems)
            {
                flFolderViewItem.Folder.Color = FLFolder.DefaultTextColor;
                CreateOrRenameNFO(flFolderViewItem.Folder);

                flFolderViewItem.Update();
                lvFLFolder_SelectedIndexChanged(sender, null);
            }
            lvFLFolder.EndUpdate();
        }

        private void tsmiDeleteNFOForSelectedFolder_Click(object sender, EventArgs e)
        {
            lvFLFolder.BeginUpdate();
            foreach (FLFolderViewItem flFolderViewItem in lvFLFolder.SelectedItems)
            {
                var nfoPath = Path.Combine(tbRootFolder.Text, flFolderViewItem.Folder.GetNFOFileName());
                File.Delete(nfoPath);

                flFolderViewItem.Update();
                lvFLFolder_SelectedIndexChanged(sender, null);
            }
            lvFLFolder.EndUpdate();
        }

        private void ReplaceColorAndSave(IEnumerable<FLFolderViewItem> fLFolderViewItems, 
            IEnumerable<Color> interpolated, int index, int offset = 0)
        {
            var flFolderViewItem = fLFolderViewItems.ElementAt(index);

            var color = MyColor.FromColor(interpolated.ElementAt(index + offset));
            flFolderViewItem.Folder.Color = color;
            flFolderViewItem.Update();

            CreateOrRenameNFO(flFolderViewItem.Folder);
        }

        private void InterpolateColors(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;
            if (cbInterpolationModes.SelectedIndex == -1) return;

            var fLFolderViewItems = lvFLFolder.Items.Cast<FLFolderViewItem>()
                .IndexRange(startIndex, endIndex)
                .Where(folder => folder.Folder.NFOExists(tbRootFolder.Text));
            // We want at least 3 items.
            var count = fLFolderViewItems.Count();
            if (count <= 2) return;

            try
            {
                switch (cbInterpolationModes.SelectedItem.ToString())
                {
                    case ColorBlend.Name:
                        var colors = new[] {
                            MyColor.ToColor(fLFolderViewItems.First().Folder.Color),
                            MyColor.ToColor(fLFolderViewItems.Last().Folder.Color)
                        };
                        var interpolated = _interpolaters[ColorBlend.Name].InterpolateColors(startIndex, endIndex, count, colors);

                        lvFLFolder.BeginUpdate();
                        for (int i = 1; i < count - 1; i++)
                            ReplaceColorAndSave(fLFolderViewItems, interpolated, i, -1);
                        lvFLFolder.EndUpdate();
                        break;
                    case ColorSplit.Name:
                        colors = new[] { Color.Red, Color.Pink };
                        interpolated = _interpolaters[ColorSplit.Name].InterpolateColors(startIndex, endIndex, count, colors);

                        lvFLFolder.BeginUpdate();
                        for (int i = 0; i < count; i++)
                            ReplaceColorAndSave(fLFolderViewItems, interpolated, i);
                        lvFLFolder.EndUpdate();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tsmiInterpolateColorsFromBeginningToSelection_Click(object sender, EventArgs e)
        {
            if (lvFLFolder.SelectedItems.Count == 0)
                return;

            var selectedItems = lvFLFolder.SelectedIndices;
            InterpolateColors(selectedItems[0], selectedItems[selectedItems.Count - 1]);
        }

        private void tsmiInterpolateColorsFromBeginningToEnd_Click(object sender, EventArgs e)
        {
            if (lvFLFolder.SelectedItems.Count != 0)
                InterpolateColors(0, lvFLFolder.Items.Count - 1);
        }
    }
}
