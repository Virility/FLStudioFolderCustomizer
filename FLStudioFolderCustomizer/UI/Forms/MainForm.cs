﻿using FLStudioFolderCustomizer.Core.Extensions;
using FLStudioFolderCustomizer.Core.Models.ColorHelpers;
using FLStudioFolderCustomizer.Core.Models.Colors;
using FLStudioFolderCustomizer.Models;
using FLStudioFolderCustomizer.UI.Dialogs;
using FLStudioFolderCustomizer.UI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FLStudioFolderCustomizer.UI.Forms
{
    public partial class MainForm : Form
    {
        private const string DefaultRootPath = "DefaultRootPath.txt";
        private readonly ColorInterpolater[] _interpolaters;

        private List<Color> _colorSceme;

        public MainForm()
        {
            _interpolaters = new ColorInterpolater[]
            {
                new ColorBlend(),
                new ColorSplit()
            };
            _colorSceme = new List<Color>();

            InitializeComponent();

            cbInterpolationModes.Items.AddRange(_interpolaters);
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
                var nfoFilePath = Path.Combine(directory + ".nfo");
                if (File.Exists(nfoFilePath))
                    folder = FLFolder.FromNFO(title, File.ReadAllLines(nfoFilePath));
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
            if (flFolderViewItem.Folder.NFOFileExists(tbRootFolder.Text))
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

            var nfoFilePath = Path.Combine(tbRootFolder.Text, e.OldValue.ToString() + ".nfo");
            if (File.Exists(nfoFilePath))
                File.Delete(nfoFilePath);

            CreateNFOFile(flFolderViewItem.Folder);
            flFolderViewItem.Update();
        }

        private void CreateNFOFile(FLFolder folder)
        {
            var directoryPath = Path.Combine(tbRootFolder.Text, folder.GetSafeTitle());
            var nfoFilePath = Path.Combine(tbRootFolder.Text, folder.GetNFOFileName());

            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(nfoFilePath, folder.ToNFOContent());
        }

        private void tsmiCreateFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRootFolder.Text) || !Directory.Exists(tbRootFolder.Text))
                return;

            var folder = new FLFolder();
            var flFolderViewItems = lvFLFolder.Items.Cast<FLFolderViewItem>();
            for (int i = 0; ; i++)
            {
                var title = folder + (i != 0 ? " #" + (i + 1).ToString() : string.Empty);
                if (!flFolderViewItems.Any(item => item.Folder.FolderName == title))
                {
                    folder.FolderName = title;
                    break;
                }
            }
            CreateNFOFile(folder);
            lvFLFolder.Items.Add(new FLFolderViewItem(tbRootFolder.Text, folder));
        }

        private void tsmiCreateNFOFileForFolder_Click(object sender, EventArgs e)
        {
            lvFLFolder.BeginUpdate();
            foreach (FLFolderViewItem flFolderViewItem in lvFLFolder.SelectedItems)
            {
                flFolderViewItem.Folder.Color = FLFolder.DefaultTextColor;
                CreateNFOFile(flFolderViewItem.Folder);

                flFolderViewItem.Update();
                lvFLFolder_SelectedIndexChanged(sender, null);
            }
            lvFLFolder.EndUpdate();
        }

        private void tsmiDeleteNFOFileForSelectedFolder_Click(object sender, EventArgs e)
        {
            lvFLFolder.BeginUpdate();
            foreach (FLFolderViewItem flFolderViewItem in lvFLFolder.SelectedItems)
            {
                var nfoFilePath = Path.Combine(tbRootFolder.Text, flFolderViewItem.Folder.GetNFOFileName());
                File.Delete(nfoFilePath);

                flFolderViewItem.Update();
                lvFLFolder_SelectedIndexChanged(sender, null);
            }
            lvFLFolder.EndUpdate();
        }

        private void ReplaceColorAndSave(IEnumerable<FLFolderViewItem> fLFolderViewItems,
            IEnumerable<Color> interpolatedColors, int index, int colorOffset)
        {
            var flFolderViewItem = fLFolderViewItems.ElementAt(index);

            flFolderViewItem.Folder.Color = MyColor.FromColor(interpolatedColors.ElementAt(index - colorOffset));
            flFolderViewItem.Update();

            CreateNFOFile(flFolderViewItem.Folder);
        }

        private void InterpolateColors(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;
            if (cbInterpolationModes.SelectedIndex == -1) return;

            var fLFolderViewItems = lvFLFolder.Items.Cast<FLFolderViewItem>()
                .IndexRange(startIndex, endIndex)
                .Where(folder => folder.Folder.NFOFileExists(tbRootFolder.Text));
            // We want at least 3 items. 2 items or less means nothing can be interpolated.
            var count = fLFolderViewItems.Count();
            if (count <= 2) return;

            try
            {
                Color[] colors;
                switch (cbInterpolationModes.SelectedItem.ToString())
                {
                    case ColorBlend.Name:
                        colors = new[] {
                            fLFolderViewItems.First().Folder.Color.ActualColor,
                            fLFolderViewItems.Last().Folder.Color.ActualColor
                        };
                        break;
                    case ColorSplit.Name:
                        if (_colorSceme.Count == 0 ||
                           (_colorSceme.Count > 0 && MessageBox.Show("Would you like to use the last color scheme?", "Use Last Scheme?", MessageBoxButtons.YesNo) != DialogResult.Yes))
                        {
                            using var dialog = new ColorListPickerDialog();
                            dialog.ShowDialog();

                            if (dialog.Colors.Count == 0)
                            {
                                MessageBox.Show("The color list is empty.");
                                return;
                            }

                            _colorSceme = dialog.Colors;
                        }
                        colors = _colorSceme.ToArray();
                        break;
                    default: return;
                }

                var interpolater = _interpolaters[cbInterpolationModes.SelectedIndex];
                var interpolatedColors = interpolater.InterpolateColors(startIndex, endIndex, count, colors);
                lvFLFolder.BeginUpdate();
                for (int i = interpolater.StartIndex; i < count - interpolater.LengthOffset; i++)
                    ReplaceColorAndSave(fLFolderViewItems, interpolatedColors, i, interpolater.ColorOffset);
                lvFLFolder.EndUpdate();
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
