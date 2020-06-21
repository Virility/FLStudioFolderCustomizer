using FLStudioFolderCustomizer.Core.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Models.ColorHelpers
{
    public class ColorBlend : ColorInterpolater
    {
        public const string Name = "Color Blending";

        public ColorBlend()
        {

            // Skip first and last items respectively, since those are the 2 base colors where the others are interpolated from.
            StartIndex = 1;
            LengthOffset = 1;
            ColorOffset = 1;
        }

        public override List<Color> InterpolateColors(int startIndex, int endIndex, int length, Color[] colors)
        {
            var startColor = colors[0];
            var endColor = colors[1];

            Debug.WriteLine("Color 1: " + startColor.ToRgbString());
            Debug.WriteLine("Color 2: " + endColor.ToRgbString());

            var blendInterpolationDifference = 1d / length;

            var header = new string('=', 20);
            Debug.WriteLine(header);

            var colorss = new List<Color>();
            for (int i = StartIndex; i < length - LengthOffset; i++)
            {
                Debug.WriteLine("Item #" + i);

                var blendAmount = blendInterpolationDifference * i;
                Debug.WriteLine("Blend Interpolation Amount: " + blendAmount);

                var blendedColor = endColor.Blend(startColor, blendAmount);
                Debug.WriteLine("Color: " + blendedColor.ToRgbString());
                colorss.Add(blendedColor);
            }
            Debug.WriteLine(header);

            return colorss;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
