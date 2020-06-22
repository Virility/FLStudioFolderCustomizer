using FLStudioFolderCustomizer.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Helpers.ColorHelpers
{
    public class ColorSplit : ColorInterpolater
    {
        public const string Name = "Color Splitting";

        public ColorSplit()
        {
            StartIndex = 0;
            LengthOffset = 0;
            ColorOffset = 0;
        }

        public override List<Color> InterpolateColors(int startIndex, int endIndex, int length, Color[] colors)
        {
            for (int i = 0; i < colors.Length; i++)
                Debug.WriteLine($"Color {i + 1}: " + colors[i].ToRgbString());

            var blockIndex = 0;
            var blockCount = 0;
            var numberPerBlock = Math.Ceiling((double)length / colors.Length);
            Debug.WriteLine("Number Per Block: " + numberPerBlock);

            var header = new string('=', 20);
            Debug.WriteLine(header);

            var interpolatedColors = new List<Color>();
            for (int i = StartIndex; i < length; i++)
            {
                Debug.WriteLine("Item #" + (i + 1));
                blockCount++;
                Debug.WriteLine($"Block Count: {blockCount}/{numberPerBlock}");

                var color = colors[blockIndex];
                Debug.WriteLine("Color: " + color.ToRgbString());
                if (blockCount == numberPerBlock)
                {
                    blockIndex++;
                    if (blockIndex == colors.Length)
                    {
                        blockIndex--;
                        Debug.WriteLine($"Can't split evenly. We'll reuse {color.ToRgbString()}.");
                    }
                    Debug.WriteLine("Block Index" + blockIndex);
                    blockCount = 0;
                }
                interpolatedColors.Add(color);
            }

            Debug.WriteLine(header);
            return interpolatedColors;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
