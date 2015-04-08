using System;
using System.Collections.Generic;
using System.Linq;
using wiercholki.Logic;

namespace wiercholki
{
    public enum Direction { Both, ToFirst, ToSecond };

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

        public static double GetDistance(myPoint from, myPoint to)
        {
            var dX = from.X - to.X;
            var dY = from.Y - to.Y;

            return Math.Sqrt(dX * dX + dY * dY);
        }

        public static myPoint Orthogonal(myPoint vector)
        {
            return new myPoint(-vector.Y, vector.X);
        }

        public static myPoint Normalize(myPoint vector)
        {
            double lenght = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (lenght == 0)
            {
                return vector;
            }

            return new myPoint((float)(vector.X / lenght), (float)(vector.Y / lenght));
        }

        public static myPoint Orthonormal(myPoint vector)
        {
            return Orthogonal(Normalize(vector));
        }

        public static myPoint AddPoint(myPoint x, myPoint y)
        {
            return new myPoint(x.X + y.X, x.Y + y.Y);
        }

        public static myPoint SubtractPoint(myPoint x, myPoint y)
        {
            return new myPoint(x.X - y.X, x.Y - y.Y);
        }

        public static myPoint NegativePoint(myPoint x)
        {
            return new myPoint(-x.X, -x.Y);
        }

        public static myPoint MultiplyPoint(myPoint a, int b)
        {
            return new myPoint((a.X * b), (a.Y * b));
        }

        public static float DotProduct(myPoint pointA, myPoint pointB, myPoint pointC)
        {
            myPoint AB = new myPoint(pointB.X - pointA.X, pointB.Y - pointA.Y);
            myPoint BC = new myPoint(pointC.X - pointB.X, pointC.Y - pointB.Y);

            float dot = AB.X * BC.X + AB.Y * BC.Y;
            return dot;
        }

        public static float CrossProduct(myPoint pointA, myPoint pointB, myPoint pointC)
        {
            myPoint AB = new myPoint(pointB.X - pointA.X, pointB.Y - pointA.Y);
            myPoint AC = new myPoint(pointC.X - pointA.X, pointC.Y - pointA.Y);

            float cross = AB.X * AC.Y - AB.Y * AC.X;

            return cross;
        }

        public static double Distance(myPoint pointA, myPoint pointB)
        {
            double d1 = pointA.X - pointB.X;
            double d2 = pointA.Y - pointB.Y;

            return Math.Sqrt(d1 * d1 + d2 * d2);
        }

        public static double LineToPointDistance2D(Edge edge, myPoint pointC)
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
    }
    
   
}
