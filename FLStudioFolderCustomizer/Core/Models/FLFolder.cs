using FLStudioFolderCustomizer.Core.Extensions;
using FLStudioFolderCustomizer.Core.Models.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLStudioFolderCustomizer.Models
{
    public class FLFolder
    {
        public static MyColor DefaultTextColor = MyColor.FromColor(System.Drawing.Color.FromArgb(91, 156, 137));

        [Description("Periods won't work.")]
        public string FolderName { get; set; } = "New Folder";

        public string Tip { get; set; }

        [Editor(typeof(MyColorEditor), typeof(UITypeEditor))]
        [DefaultValue(typeof(MyColor), "0 0 0")]
        public MyColor Color { get; set; } = DefaultTextColor;
        
        // 33 = Audio Wave Icon
        public int IconIndex { get; set; } = 33;

        public int HeightOfs { get; set; } = 4;

        public int SortGroup { get; set; } = -1;

        public bool NFOFileExists(string baseDirectory)
        {
            return File.Exists(Path.Combine(baseDirectory, GetNFOFileName()));
        }

        private static string MakeValidFolderNameSimple(string folderName)
        {
            if (string.IsNullOrEmpty(folderName))
                return folderName;

            foreach (var c in Path.GetInvalidFileNameChars())
                folderName = folderName.Replace(c.ToString(), string.Empty);

            foreach (var c in Path.GetInvalidPathChars())
                folderName = folderName.Replace(c.ToString(), string.Empty);

            return folderName;
        }

        public string GetSafeTitle()
        {
            var safeTitle = MakeValidFolderNameSimple(FolderName);
            if (string.IsNullOrWhiteSpace(safeTitle))
                throw new Exception("Invalid length.");

            return safeTitle;
        }

        public string GetNFOFileName()
        {
            return GetSafeTitle() + ".nfo";
        }

        public static FLFolder FromNFO(string folderName, string[] lines)
        {
            var folder = new FLFolder();
            folder.FolderName = folderName;

            var pairs = new Dictionary<string, string>();
            foreach (var pair in lines
                                .Where(line => line.Contains("="))
                                .Select(line => line.Split('=')))
                pairs.Add(pair[0], pair.Length == 1 ? string.Empty : pair[1]);

            if (pairs.ContainsKey("Tip"))
                folder.Tip = pairs["Tip"];
            if (pairs.ContainsKey("Color"))
            {
                var color = pairs["Color"].Replace("$00", string.Empty);
                var b = color.Substring(0, 2);
                var g = color.Substring(2, 2);
                var r = color.Substring(4, 2);
                folder.Color = MyColor.FromColor(ColorTranslator.FromHtml("#" + r + g + b));
            }
            if (pairs.ContainsKey("IconIndex") && int.TryParse(pairs["IconIndex"], out int iconIndex))
                folder.IconIndex = iconIndex;
            if (pairs.ContainsKey("HeightOfs") && int.TryParse(pairs["HeightOfs"], out int heightOfs))
                folder.HeightOfs = heightOfs;
            if (pairs.ContainsKey("SortGroup") && int.TryParse(pairs["SortGroup"], out int sortGroup))
                folder.SortGroup = sortGroup;

            return folder;
        }

        public string ToNFOContent()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Tip))
                sb.AppendLine("Tip=" + Tip);
            sb.AppendLine("Color=$00" + MyColor.ToColor(Color).ToDelphiHex());
            sb.AppendLine("IconIndex=" + IconIndex);
            sb.AppendLine("HeightOfs=" + HeightOfs);
            if (SortGroup != -1)
                sb.Append("SortGroup=" + SortGroup);
            return sb.ToString();
        }

        public override string ToString()
        {
            return FolderName;
        }
    }
}