using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafy.Program
{
    public class GraphPanel : Panel
    {
        public GraphPanel()
        {
            DoubleBuffered = true;
        }

        private Panel panel1;

        private Bitmap _bitmap;
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set
            {
                _bitmap = value;

                if (value == null) AutoScrollMinSize = new Size(0, 0);
                else
                {
                    var size = value.Size;
                    using (var gr = CreateGraphics())
                    {
                        size.Width = (int)(size.Width * gr.DpiX / value.HorizontalResolution);
                        size.Height = (int)(size.Height * gr.DpiY / value.VerticalResolution);
                    }
                }
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                if (_bitmap != null)
                    e.Graphics.DrawImage(_bitmap, 0, 0);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't render plane.");
            }
        }
    }
}
