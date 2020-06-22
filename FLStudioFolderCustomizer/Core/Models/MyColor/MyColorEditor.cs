using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FLStudioFolderCustomizer.Core.Models.Colors
{
    public class MyColorEditor : UITypeEditor
    {
        private IWindowsFormsEditorService service;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
                service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (service != null)
            {
                var color = (MyColor)value;

                using (var dialog = new ColorDialog())
                {
                    dialog.Color = Color.FromArgb(color.GetARGB());
                    dialog.ShowDialog();

                    value = new MyColor(dialog.Color.ToArgb());
                }
            }

            return value;
        }
    }
}
