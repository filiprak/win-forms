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
            
            /*int normalX = (e.Bounds.Width / 2); int normalY = (e.Bounds.Height / 2);
            // Fill background and ellipse and center point.
            e.Graphics.FillRectangle(new SolidBrush(Color.DarkBlue), e.Bounds.X, e.Bounds.Y,
            e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), e.Bounds.X + 1, e.Bounds.Y + 1,
            e.Bounds.Width - 3, e.Bounds.Height - 3);
            e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), normalX + e.Bounds.X - 1,
            normalY + e.Bounds.Y - 1, 3, 3);
            // Draw line along the current angle.
            double radians = ((double)e.Value * Math.PI) / (double)180;
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red), 1),
            normalX + e.Bounds.X, normalY + e.Bounds.Y,
            e.Bounds.X + (normalX + (int)((double)normalX * Math.Cos(radians))),
            e.Bounds.Y + (normalY + (int)((double)normalY * Math.Sin(radians)))
            );*/
        }
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext
        context)
        { return true; }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        { return UITypeEditorEditStyle.DropDown; }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc =
            (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
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
