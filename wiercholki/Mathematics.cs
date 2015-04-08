using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiercholki
{
    internal static class Mathematics
    {
        public static double GetDistance(this Point from, Point to)
        {
            var dX = from.X - to.X;
            var dY = from.Y - to.Y;

            return Math.Sqrt(dX * dX + dY * dY);
        }

        public static Point Orthogonal(this Point vector)
        {
            return new Point(-vector.Y, vector.X);
        }

        public static Point Normalize(this Point vector)
        {
            double lenght = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (lenght == 0)
            {
                return vector;
            }

            return new Point((float)(vector.X / lenght), (float)(vector.Y / lenght));
        }

        public static Point Orthonormal(this Point vector)
        {
            return Orthogonal(Normalize(vector));
        }

        public static Point AddPoint(this Point x, Point y)
        {
            return new Point(x.X + y.X, x.Y + y.Y);
        }

        public static Point SubtractPoint(this Point x, Point y)
        {
            return new Point(x.X - y.X, x.Y - y.Y);
        }

        public static Point NegativePoint(this Point x)
        {
            return new Point(-x.X, -x.Y);
        }

        public static Point MultiplyPoint(this Point a, int b)
        {
            return new Point((a.X * b), (a.Y * b));
        }

        public static float DotProduct(Point pointA, Point pointB, Point pointC)
        {
            Point AB = new Point(pointB.X - pointA.X, pointB.Y - pointA.Y);
            Point BC = new Point(pointC.X - pointB.X, pointC.Y - pointB.Y);

            float dot = AB.X * BC.X + AB.Y * BC.Y;
            return dot;
        }

        //Compute the cross product AB x AC
        public static float CrossProduct(Point pointA, Point pointB, Point pointC)
        {
            Point AB = new Point(pointB.X - pointA.X, pointB.Y - pointA.Y);
            Point AC = new Point(pointC.X - pointA.X, pointC.Y - pointA.Y);

            float cross = AB.X * AC.Y - AB.Y * AC.X;

            return cross;
        }

        //Compute the distance from A to B
        public static double Distance(Point pointA, Point pointB)
        {
            double d1 = pointA.X - pointB.X;
            double d2 = pointA.Y - pointB.Y;

            return Math.Sqrt(d1 * d1 + d2 * d2);
        }

        public static double LineToPointDistance2D(this Edge edge, Point pointC)
        {
            double dist = CrossProduct(edge.FirstVertex, edge.SecondVertex, pointC) / Distance(edge.FirstVertex, edge.SecondVertex);
            double dot1 = DotProduct(edge.FirstVertex, edge.SecondVertex, pointC);
            if (dot1 > 0)
                return Distance(edge.SecondVertex, pointC);

            double dot2 = DotProduct(edge.SecondVertex, edge.FirstVertex, pointC);
            if (dot2 > 0)
                return Distance(edge.FirstVertex, pointC);

            return Math.Abs(dist);
        }

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
