using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

using Fonts = System.Windows.Media.Fonts;
using GlyphTypeface = System.Windows.Media.GlyphTypeface;

namespace FLStudioFolderCustomizer.Core.Helpers
{
    // https://edi.wang/post/2017/1/22/windows-10-uwp-get-fonts

    public static class FontHelper
    {
        private static readonly string FLGlyphsExFontPath;
        private static readonly FontFamily _fontFamily;
        private static readonly Font _font;
        private static IDictionary<int, ushort> _pairs;

        static FontHelper()
        {
            FLGlyphsExFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Image-Line\Shared\Artwork\Fonts\ILGlyphsEx.ttf");
            var fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(FLGlyphsExFontPath);
            _fontFamily = fontCollection.Families[0];
            _font = new Font(_fontFamily, 12f);
        }

        private static bool FontHasCharacter(int unicodeValue)
        {
            if (_pairs == null)
            {
                var fontFamily = Fonts.GetFontFamilies(FLGlyphsExFontPath).FirstOrDefault();
                if (fontFamily == null)
                    return false;
                var typefaces = fontFamily.GetTypefaces().FirstOrDefault();
                if (typefaces == null)
                    return false;

                typefaces.TryGetGlyphTypeface(out GlyphTypeface glyph);
                _pairs = glyph.CharacterToGlyphMap;
            }
            return _pairs.Any(pair => pair.Key == unicodeValue);
        }

        public static List<Character> GetCharacters()
        {
            var characters = new List<Character>();
            using (var image = new Bitmap(1, 1))
            using (var drawing = Graphics.FromImage(image))
            {
                for (var i = 0; i < ushort.MaxValue; i++)
                {
                    if (!FontHasCharacter(i))
                        continue;

                    var character = char.ConvertFromUtf32(i);
                    var charTextSize = drawing.MeasureString(character, _font);
                    if (charTextSize.Width > 6)
                        characters.Add(new Character(_font, charTextSize, character, i));
                }
            }
            return characters;
        }
    }
}
