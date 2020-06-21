using FLStudioFolderCustomizer.Core.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Models.ColorHelpers
{
    public class ColorSplit : ColorInterpolater
    {
        public const string Name = "Color Splitting";

        public override IEnumerable<Color> InterpolateColors(int startIndex, int endIndex, int length, Color[] colors)
        {
            for (int i = 0; i < length; i++)
                Debug.WriteLine($"Color {i + 1}: " + colors[i].ToRgbString());

            var blockIndex = 0;
            var blockCount = 0;
            var numberPerBlock = length / colors.Length;

            var header = new string('=', 20);
            Debug.WriteLine(header);

            for (int i = 0; i < length; i++)
            {
                Debug.WriteLine("Item #" + (i + 1));
                blockCount++;
                Debug.WriteLine("Block Count: " + blockCount);

                var color = colors[blockIndex];
                Debug.WriteLine("Color: " + color.ToRgbString());
                if (blockCount == numberPerBlock - 1)
                {
                    blockIndex++;
                    if (blockIndex == colors.Length)
                        blockIndex--;
                    Debug.WriteLine(blockIndex);

                    blockCount = 0;
                }
                yield return color;
            }
            Debug.WriteLine(header);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
