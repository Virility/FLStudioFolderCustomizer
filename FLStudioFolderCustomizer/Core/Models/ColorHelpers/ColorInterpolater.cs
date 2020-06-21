using System.Collections.Generic;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Models.ColorHelpers
{
    public abstract class ColorInterpolater
    {
        public int StartIndex;
        public int LengthOffset;
        public int ColorOffset;

        public abstract List<Color> InterpolateColors(int startIndex, int endIndex, int length, Color[] colors);
    }
}
