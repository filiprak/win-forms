using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;


namespace win_forms
{
    class GenreEditor : System.Drawing.Design.UITypeEditor
    {
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            if (e.Value == null)
                return;
            if (e.Value.Equals("rock"))
                e.Graphics.DrawImage(Properties.Resources.rock, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            else if (e.Value.Equals("pop"))
                e.Graphics.DrawImage(Properties.Resources.pop, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            else if (e.Value.Equals("jazz"))
                e.Graphics.DrawImage(Properties.Resources.jazz, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            
        }
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext
        context)
        { return true; }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        { return UITypeEditorEditStyle.DropDown; }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                GenreControl genControl = new GenreControl();
                genControl.Genre = value as string;
                edSvc.DropDownControl(genControl);
                return genControl.Genre;
            }
            return value;
        }
    }
}
