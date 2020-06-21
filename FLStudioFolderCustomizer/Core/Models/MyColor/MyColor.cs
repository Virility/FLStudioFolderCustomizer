using System;
using System.ComponentModel;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Models.Colors
{
    // This like tells it to use our custom type converter instead of the default.
    [TypeConverter(typeof(MyColorConverter))]
    public class MyColor
    {
        #region " The color channel variables w/ accessors/mutators. "
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }
        #endregion

        #region " Constructors "
        public MyColor()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }
        public MyColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
        public MyColor(byte[] rgb)
        {
            if (rgb.Length != 3)
                throw new Exception("Array must have a length of 3.");
            Red = rgb[0];
            Green = rgb[1];
            Blue = rgb[2];
        }
        public MyColor(int argb)
        {
            byte[] bytes = BitConverter.GetBytes(argb);
            Red = bytes[2];
            Green = bytes[1];
            Blue = bytes[0];
        }
        public MyColor(string rgb)
        {
            string[] parts = rgb.Split(' ');
            if (parts.Length != 3)
                throw new Exception("Array must have a length of 3.");
            Red = Convert.ToByte(parts[0]);
            Green = Convert.ToByte(parts[1]);
            Blue = Convert.ToByte(parts[2]);
        }
        #endregion

        #region " Methods "
        public new string ToString()
        {
            return string.Format("{0} {1} {2}", Red, Green, Blue); ;
        }
        public byte[] GetRGB()
        {
            return new byte[] { Red, Green, Blue };
        }
        public int GetARGB()
        {
            byte[] temp = new byte[] { Blue, Green, Red, 255 };
            return BitConverter.ToInt32(temp, 0);
        }

        public static MyColor FromColor(Color color)
        {
            return new MyColor() { Red = color.R, Green = color.G, Blue = color.B };
        }
        public static Color ToColor(MyColor color)
        {
            return Color.FromArgb(color.Red, color.Green, color.Blue);
        }

        public Color ActualColor
        { 
            get => ToColor(this);
        }
        #endregion
    }
}
