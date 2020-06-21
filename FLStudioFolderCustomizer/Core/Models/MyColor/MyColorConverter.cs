using System;
using System.ComponentModel;
using System.Globalization;

namespace FLStudioFolderCustomizer.Core.Models.Colors
{
    public class MyColorConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
                return new MyColor((string)value);
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is MyColor color1)
            {
                MyColor color = color1;
                return color.ToString();
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
