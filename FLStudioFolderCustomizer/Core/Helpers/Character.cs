using System.Drawing;

namespace FLStudioFolderCustomizer.Core.Helpers
{
    public class Character
    {
        private const int ZeroReference = 61696;
        private readonly Font _font;
        private readonly SizeF _charTextSize;

        public string Char { get; set; }

        public int UnicodeIndex { get; set; }

        public Character(Font font, SizeF charTextSize, string character, int unicodeIndex)
        {
            _font = font;
            _charTextSize = charTextSize;
            Char = character;
            UnicodeIndex = unicodeIndex;
        }

        public int GetImageIndex()
        {
            return UnicodeIndex - ZeroReference;
        }

        public Image GetImage()
        {
            var image = new Bitmap((int)_charTextSize.Width, (int)_charTextSize.Height);
            using (var drawing = Graphics.FromImage(image))
            {
                drawing.Clear(Config.FLBackColor);

                drawing.DrawString(Char, _font, Brushes.White, 0, 0);
                drawing.Save();
            }
            return image;
        }
    }
}
