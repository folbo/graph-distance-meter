using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace wiercholki
{
    public class Point
    {
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        public float X { get; set; }
        public float Y { get; set; }
    }
    interface IGraf
    {
        void AddVertex(Vertex elem);
        void RemoveVertex(Vertex elem);
        void AddEdge(Edge elem);
        void RemoveEdge(Edge elem);

        Vertex FindNearestVertex(int x, int y, int range);
    }
    
    public enum Direction { Both, ToFirst, ToSecond };

    public class Vertex : Point
    {
        public int Size { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class Edge
    {
        public Vertex FirstVertex { get; set; }
        public Vertex SecondVertex { get; set; }
        public Direction direction { get; set; }
        public System.Drawing.Drawing2D.GraphicsPath Path { get; internal set; }
    }

    public class Graf : IGraf
    {
        public List<Vertex> wierzcholki;
        public List<Edge> krawedzie;

        private Matrix matrix;

        public Matrix Matrix { get { return matrix; } }
        public Graf()
        {
            wierzcholki = new List<Vertex>();
            krawedzie = new List<Edge>();

            matrix = new Matrix();
        }
        public void AddVertex(Vertex elem)
        {
            wierzcholki.Add(elem);
            matrix.AddVerticle();
            UpdateVertexId();
        }

        public void UpdateVertexId()
        {
            for (int i =0; i < wierzcholki.Count; i++)
            {
                wierzcholki[i].Id = i;
            }
        }
        public void RemoveVertex(Vertex elem)
        {
            var relatedEdges = krawedzie.Where(x => (x.FirstVertex == elem || x.SecondVertex == elem));
            var list = relatedEdges.ToList();
            foreach (var edge in list)
            {
                RemoveEdge(edge);
            }


            if (wierzcholki.Contains(elem))
                wierzcholki.Remove(elem);

            matrix.RemoveVerticle(elem.Id);

            UpdateVertexId();
        }

        public void UpdatePaths(Edge elem)
        {
            Edge[] edges =
                krawedzie.Where(
                    edge =>
                        (edge.FirstVertex == elem.FirstVertex && edge.SecondVertex == elem.SecondVertex) ||
                        (edge.FirstVertex == elem.SecondVertex && edge.SecondVertex == elem.FirstVertex)).ToArray();

            if (elem.FirstVertex == elem.SecondVertex)
            {
                float stepAngle = 2 * (float)Math.PI / edges.Length;

                for (int i = 0; i < edges.Length; i++)
                {
                    var edge = edges[i];
                    edge.Path = new System.Drawing.Drawing2D.GraphicsPath();

                    var bezierPoints = new System.Drawing.PointF[4]
                    {
                        new System.Drawing.PointF(edge.FirstVertex.X, edge.FirstVertex.Y),
                        new System.Drawing.PointF(edge.FirstVertex.X + 50*(float)Math.Sin((i*stepAngle) - 10), edge.FirstVertex.Y + 50*(float)Math.Cos((i*stepAngle) - 10)),
                        new System.Drawing.PointF(edge.FirstVertex.X + 50*(float)Math.Sin((i*stepAngle) + 10), edge.FirstVertex.Y + 50*(float)Math.Cos((i*stepAngle) + 10)),
                        new System.Drawing.PointF(edge.SecondVertex.X, edge.SecondVertex.Y)
                    };
                    edge.Path.AddBeziers(bezierPoints);
                }
            }
            else
            {
              

                var vector = elem.SecondVertex.SubtractPoint(elem.FirstVertex);

                vector = vector.Orthonormal().MultiplyPoint(10);
                var startVector = vector.MultiplyPoint(((edges.Length - 1) / 2));

                foreach (var edge in edges)
                {
                    edge.Path = new System.Drawing.Drawing2D.GraphicsPath();
                    
                    var bezierPoints = new System.Drawing.PointF[4]
                    {
                        new System.Drawing.PointF(edge.FirstVertex.X, edge.FirstVertex.Y),
                        new System.Drawing.PointF(edge.FirstVertex.X - startVector.X, edge.FirstVertex.Y - startVector.Y),
                        //new System.Drawing.PointF(edge.FirstVertex.X - startVector.X, edge.FirstVertex.Y - startVector.Y),
                        new System.Drawing.PointF(-startVector.X + (edge.FirstVertex.X + edge.SecondVertex.X)/2, -startVector.Y + (edge.FirstVertex.Y + edge.SecondVertex.Y)/2),
                       // new System.Drawing.PointF(edge.SecondVertex.X - startVector.X, edge.SecondVertex.Y - startVector.Y),
                        //new System.Drawing.PointF(edge.SecondVertex.X - startVector.X, edge.SecondVertex.Y - startVector.Y),
                        new System.Drawing.PointF(edge.SecondVertex.X, edge.SecondVertex.Y)
                    };
                    
                    edge.Path.AddBeziers(bezierPoints);

                    startVector = startVector.SubtractPoint(vector);
                }
            }
        }

        public void AddEdge(Edge elem)
        {
            krawedzie.Add(elem);
            UpdatePaths(elem);

            if (elem.direction == Direction.Both)
            {
                if (elem.FirstVertex != elem.SecondVertex)
                {
                    matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
                    matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] += 1;
                }
                else
                {
                    matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
                }
            }
            if (elem.direction == Direction.ToFirst)
            {
                matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
            }
            if (elem.direction == Direction.ToSecond)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] += 1;
            }

            matrix.Show();
        }

        public void RemoveEdge(Edge elem)
        {
            if (krawedzie.Contains(elem))
                krawedzie.Remove(elem);

            if (elem.FirstVertex == elem.SecondVertex)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                return;
            }

            if (elem.direction == Direction.Both)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
            }
            if (elem.direction == Direction.ToFirst)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                //matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
            }
            if (elem.direction == Direction.ToSecond)
            {
                matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
                //matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
            }


           
        }

        public Vertex FindNearestVertex(int x, int y, int range)
        {
            Vertex nearest = null;
            int distance = range;
            foreach (var vertex in wierzcholki)
            {
                if (Math.Pow(x - vertex.X, 2) + Math.Pow(y - vertex.Y, 2) < distance)
                    nearest = vertex;
            }
            return nearest;
        }

        public void ChangeDirection(Edge edge, Direction dir)
        {
            if (dir == Direction.Both && edge.direction != Direction.Both)
            {
                if (edge.direction == Direction.ToSecond)
                {
                    matrix[edge.SecondVertex.Id, edge.FirstVertex.Id] += 1;
                }
                else
                {
                    matrix[edge.FirstVertex.Id, edge.SecondVertex.Id] += 1;
                }

            }
            if (dir == Direction.ToFirst && edge.direction != Direction.ToFirst)
            {
                if (edge.direction == Direction.ToSecond)
                {
                    matrix[edge.SecondVertex.Id, edge.FirstVertex.Id] += 1;
                }
                matrix[edge.FirstVertex.Id, edge.SecondVertex.Id] -= 1;
            }
            if (dir == Direction.ToSecond && edge.direction != Direction.ToSecond)
            {
                if (edge.direction == Direction.ToFirst)
                {
                    matrix[edge.FirstVertex.Id, edge.SecondVertex.Id] += 1;
                }
                matrix[edge.SecondVertex.Id, edge.FirstVertex.Id] -= 1;
            }
            edge.direction = dir;

            matrix.Show();
        }

        public Edge FindNearestEdge(int x, int y, int range)
        {
            /*
            Edge nearest = null;
            int distance = range;
            foreach (var edge in krawedzie)
            {
                Vertex mouse = new Vertex();
                mouse.X = x;
                mouse.Y = y;

                if ( edge.LineToPointDistance2D(mouse) < distance)
                    nearest = edge;
            }
            return nearest; 
            */
            var mouse = new System.Drawing.Point(x, y);
            return krawedzie.FirstOrDefault(edge => edge.Path.IsOutlineVisible(mouse, new System.Drawing.Pen(System.Drawing.Color.Black, range)));
        }
        public static System.Drawing.PointF GetPointOnCircle(System.Drawing.PointF p1, System.Drawing.PointF p2, Int32 radius)
        {
            System.Drawing.PointF pointref = System.Drawing.PointF.Subtract(p2, new System.Drawing.SizeF(p1));
            double degrees = Math.Atan2(pointref.Y, pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);

            double cosx2 = Math.Cos(degrees + Math.PI);
            double siny2 = Math.Sin(degrees + Math.PI);

            Console.WriteLine("origin X: " + p1.X + " Y: " +p1.Y);
            Console.WriteLine("X: " + (int)(cosx1 * (float)(radius) + (float)p1.X) + " Y: " +  (int)(siny1 * (float)(radius) + (float)p1.Y));
            return new System.Drawing.PointF((int)(cosx1 * (float)(radius) + (float)p1.X), (int)(siny1 * (float)(radius) + (float)p1.Y));
        }
    }
}
