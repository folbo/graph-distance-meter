using System;
using System.Collections.Generic;
using System.Linq;

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
    interface IGraph
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
        public Direction Direction { get; set; }
        public System.Drawing.Drawing2D.GraphicsPath Path { get; internal set; }
    }

    public class Graph : IGraph
    {
        public List<Vertex> verticles;
        public List<Edge> edges;

        private Matrix matrix;
        public Matrix Matrix { get { return matrix; } }

        public Graph()
        {
            verticles = new List<Vertex>();
            edges = new List<Edge>();

            matrix = new Matrix();
        }
        public void AddVertex(Vertex elem)
        {
            verticles.Add(elem);
            matrix.AddVerticle();
            UpdateVertexId();
        }

        public void UpdateVertexId()
        {
            for (int i =0; i < verticles.Count; i++)
            {
                verticles[i].Id = i;
            }
        }
        public void RemoveVertex(Vertex elem)
        {
            var relatedEdges = edges.Where(x => (x.FirstVertex == elem || x.SecondVertex == elem));
            var list = relatedEdges.ToList();
            foreach (var edge in list)
            {
                RemoveEdge(edge);
            }


            if (verticles.Contains(elem))
                verticles.Remove(elem);

            matrix.RemoveVerticle(elem.Id);

            UpdateVertexId();
        }

        public void UpdatePaths(Edge elem)
        {
            Edge[] edges =
                this.edges.Where(
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
                        new System.Drawing.PointF(edge.SecondVertex.X - startVector.X, edge.SecondVertex.Y - startVector.Y),
                        new System.Drawing.PointF(edge.SecondVertex.X, edge.SecondVertex.Y)
                    };

                    edge.Path.AddBeziers(bezierPoints);

                    startVector = startVector.SubtractPoint(vector);
                }
            }
        }

        public void AddEdge(Edge elem)
        {
            edges.Add(elem);
            UpdatePaths(elem);

            if (elem.Direction == Direction.Both)
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
            if (elem.Direction == Direction.ToFirst)
            {
                matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
            }
            if (elem.Direction == Direction.ToSecond)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] += 1;
            }

            //matrix.Show();
        }

        public void RemoveEdge(Edge elem)
        {
            if (edges.Contains(elem))
                edges.Remove(elem);

            if (elem.FirstVertex == elem.SecondVertex)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                return;
            }

            if (elem.Direction == Direction.Both)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
            }
            if (elem.Direction == Direction.ToFirst)
            {
                matrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                //matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
            }
            if (elem.Direction == Direction.ToSecond)
            {
                matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
                //matrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
            }


           
        }

        public Vertex FindNearestVertex(int x, int y, int range)
        {
            Vertex nearest = null;
            int distance = range;
            foreach (var vertex in verticles)
            {
                if (Math.Pow(x - vertex.X, 2) + Math.Pow(y - vertex.Y, 2) < distance)
                    nearest = vertex;
            }
            return nearest;
        }

        public void ChangeDirection(Edge edge, Direction dir)
        {
            if (dir == Direction.Both && edge.Direction != Direction.Both)
            {
                if (edge.Direction == Direction.ToSecond)
                {
                    matrix[edge.SecondVertex.Id, edge.FirstVertex.Id] += 1;
                }
                else
                {
                    matrix[edge.FirstVertex.Id, edge.SecondVertex.Id] += 1;
                }

            }
            if (dir == Direction.ToFirst && edge.Direction != Direction.ToFirst)
            {
                if (edge.Direction == Direction.ToSecond)
                {
                    matrix[edge.SecondVertex.Id, edge.FirstVertex.Id] += 1;
                }
                matrix[edge.FirstVertex.Id, edge.SecondVertex.Id] -= 1;
            }
            if (dir == Direction.ToSecond && edge.Direction != Direction.ToSecond)
            {
                if (edge.Direction == Direction.ToFirst)
                {
                    matrix[edge.FirstVertex.Id, edge.SecondVertex.Id] += 1;
                }
                matrix[edge.SecondVertex.Id, edge.FirstVertex.Id] -= 1;
            }
            edge.Direction = dir;

            //matrix.Show();
        }

        public Edge FindNearestEdge(int x, int y, int range)
        {
            /*
            Edge nearest = null;
            int distance = range;
            foreach (var edge in edges)
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
            return edges.FirstOrDefault(edge => edge.Path.IsOutlineVisible(mouse, new System.Drawing.Pen(System.Drawing.Color.Black, range)));
        }
    }
}
