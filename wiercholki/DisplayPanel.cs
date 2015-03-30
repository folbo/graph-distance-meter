using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiercholki
{
    class DisplayPanel : Panel
    {
        public DisplayPanel()
        {
            DoubleBuffered = true;
        }

        private Bitmap bitmap;
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                if (value == null) this.AutoScrollMinSize = new Size(0, 0);
                else
                {
                    var size = value.Size;
                    using (var gr = this.CreateGraphics())
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
                if (bitmap != null)
                    e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception)
            {
                MessageBox.Show("Can't render plane.");
            }
        }
    }
}
