using System.Collections.Generic;
using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Models.ColorHelpers
{
    public abstract class ColorInterpolater
    {
        public abstract IEnumerable<Color> InterpolateColors(int startIndex, int endIndex, int length, Color[] colors);
    }
}
