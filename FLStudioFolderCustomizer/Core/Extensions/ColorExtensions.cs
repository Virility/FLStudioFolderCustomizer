using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Extensions
{

    public static class ColorExtensions
    {
        public static string ToHex(this Color color) =>
            $"{color.R:X2}{color.G:X2}{color.B:X2}".ToUpper();

        public static string ToDelphiHex(this Color color) =>
            $"{color.B:X2}{color.G:X2}{color.R:X2}".ToUpper();

        public static string ToRgbString(this Color c) =>
            $"RGB({c.R}, {c.G}, {c.B})";

        public static Color Blend(this Color color, Color backColor, double amount)
        {
            var r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            var g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            var b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
    }
}