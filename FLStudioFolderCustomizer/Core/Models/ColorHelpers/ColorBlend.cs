using FLStudioFolderCustomizer.Core.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Models.ColorHelpers
{
    public class ColorBlend : ColorInterpolater
    {
        public const string Name = "Color Blending";

        public override IEnumerable<Color> InterpolateColors(int startIndex, int endIndex, int length, Color[] colors)
        {
            var startColor = colors[0];
            var endColor = colors[1];

            Debug.WriteLine("Color 1: " + startColor.ToRgbString());
            Debug.WriteLine("Color 2: " + endColor.ToRgbString());

            var blendInterpolationDifference = 1d / length;

            var header = new string('=', 20);
            Debug.WriteLine(header);

            for (int i = 1; i < length - 1; i++)
            {
                Debug.WriteLine("Item #" + i);

                var blendAmount = blendInterpolationDifference * i;
                Debug.WriteLine("Blend Interpolation Amount: " + blendAmount);

                var blendedColor = endColor.Blend(startColor, blendAmount);
                Debug.WriteLine("Color: " + blendedColor.ToRgbString());
                yield return blendedColor;
            }
            Debug.WriteLine(header);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
