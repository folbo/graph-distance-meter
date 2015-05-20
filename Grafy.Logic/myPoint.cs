using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy.Logic
{
    public class myPoint
    {
        public myPoint()
        {
            X = 0;
            Y = 0;
        }
        public myPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }

        public static myPoint operator +(myPoint a, myPoint b)
        {
            return new myPoint(a.X + b.X, a.Y + b.Y);
        }
        public static myPoint operator -(myPoint a, myPoint b)
        {
            return new myPoint(a.X - b.X, a.Y - b.Y);
        }

        public static myPoint operator /(myPoint a, int b)
        {
            return new myPoint(a.X/b, a.Y/b);
        }
        public static myPoint operator *(myPoint a, float b)
        {
            return new myPoint(a.X * b, a.Y * b);
        }
        public static myPoint operator /(myPoint a, double b)
        {
            return new myPoint(a.X / (int)b, a.Y /(int) b);
        }


        public myPoint Rotate(double degrees)
        {
            var res = new myPoint((float)(X*Math.Cos(degrees) - Y*Math.Sin(degrees)), (float)(X*Math.Sin(degrees) + Y*Math.Cos(degrees)));
            return res;
        }
    }
}
