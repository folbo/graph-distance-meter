using System;
using System.Drawing;

namespace wiercholki
{
    internal static class Mathematics
    {
        public static int Blend(int a, int b, float alpha)
        {
            return Convert.ToInt16((1.0 - alpha) * a + alpha * b);
        }

        public static Color ColorBlend(Color col1, Color col2, float alpha)
        {
            Color ret;
            int a = 255;
            int r = Blend(col1.R, col2.R, alpha);
            int g = Blend(col1.G, col2.G, alpha);
            int b = Blend(col1.B, col2.B, alpha);

            ret = Color.FromArgb(a, r, g, b);

            return ret;
        }
    }
}
