using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace wiercholki.Logic
{
    public class Graph
    {
        public List<Vertex> verticles;
        public List<Edge> edges;

        private Matrix matrix;
        public Matrix Matrix { get { return matrix; } }

        public int maxWeight;

        public Edge edgeInBuild;

        public Vertex HoveredVertex;
        public Edge HoveredEdge;

        public Vertex SelectedVertex;
        public Edge SelectedEdge;

        public Graph()
        {
            verticles = new List<Vertex>();
            edges = new List<Edge>();

            matrix = new Matrix();
            maxWeight = 10;

            edgeInBuild = null;
        }
        public void AddVertex(Vertex elem)
        {
            verticles.Add(elem);
            matrix.AddVerticle();
            UpdateVertexId();
        }

        public void UpdateVertexId()
        {
            for (int i = 0; i < verticles.Count; i++)
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
                var vector = myPoint.SubtractPoint(elem.SecondVertex, elem.FirstVertex);

                vector = myPoint.Orthonormal(vector);
                vector = myPoint.MultiplyPoint(vector, 10);

                var startVector = myPoint.MultiplyPoint(vector, (edges.Length - 1) / 2);

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

                    startVector = myPoint.SubtractPoint(startVector, vector);
                }
            }
        }

        public void AddEdge(Edge elem, bool increaseInMatrix = true)
        {
            edges.Add(elem);
            UpdatePaths(elem);

            if (increaseInMatrix)
            {
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
            }
        }

        public void RemoveEdge(Edge elem, bool decreaseInMatrix = true)
        {
            if (edges.Contains(elem))
                edges.Remove(elem);

            if (decreaseInMatrix)
            {

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


        void PaintVerticles(Graphics graphics)
        {
            foreach (var vertex in verticles)
            {
                var X = vertex.X - vertex.Size / 2;
                var Y = vertex.Y - vertex.Size / 2;

                graphics.DrawEllipse(System.Drawing.Pens.Indigo, X, Y, vertex.Size, vertex.Size);
                FontFamily fontFamily = new FontFamily("Times New Roman");
                Font font = new Font(
                   fontFamily,
                   12,
                   FontStyle.Regular,
                   GraphicsUnit.Pixel);

                graphics.DrawString(vertex.Name, font, Brushes.Black, new PointF(vertex.X - 20, vertex.Y - 20));

                //najpierw pokoloruj zaznaczony, potem obsłuż hover
                if (vertex == SelectedVertex)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(200, 200, 60, 40)))
                    {
                        // graphics.FillRectangle(brush, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2,
                        //vertex.Size + 1, vertex.Size + 1);
                        graphics.FillEllipse(brush, X, Y, vertex.Size, vertex.Size);
                    }
                }
                //as vertex
                if (vertex == HoveredVertex)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(100, 20, 60, 200)))
                    {
                        // graphics.FillRectangle(brush, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2,
                        //vertex.Size + 1, vertex.Size + 1);
                        graphics.FillEllipse(brush, X, Y, vertex.Size, vertex.Size);
                    }
                }
            }
        }

        void PaintEdges(Graphics graphics)
        {
            foreach (var edge in edges)
            {

                using (var pen = new System.Drawing.Pen(Mathematics.ColorBlend(Color.Blue, Color.Red, (float)edge.Weight / maxWeight), 1))
                {
                    if (edge.Direction == Direction.ToFirst)
                    {
                        AdjustableArrowCap cap = new AdjustableArrowCap(3, 7);
                        cap.Filled = true;
                        pen.CustomStartCap = cap;
                    }
                    if (edge.Direction == Direction.ToSecond)
                    {
                        AdjustableArrowCap cap = new AdjustableArrowCap(3, 7);
                        cap.Filled = true;
                        pen.CustomEndCap = cap;
                    }

                    graphics.DrawPath(pen, edge.Path);
                }
                //as edge
                if (edge == HoveredEdge && edgeInBuild == null)
                {
                    using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 4))
                    {
                        graphics.DrawPath(pen, edge.Path);
                    }
                }
                if (edge == SelectedEdge)
                {
                    using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 4))
                    {
                        graphics.DrawPath(pen, edge.Path);
                    }
                }
            }
        }

        public void PaintGraph(Graphics graphics, myPoint mouse)
        {
            PaintVerticles(graphics);
            PaintEdges(graphics);

            if (edgeInBuild != null)
            {
                //magnetic
                if ((HoveredVertex) != null)
                {
                    using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 4))
                    {
                        graphics.DrawLine(pen, edgeInBuild.FirstVertex.X, edgeInBuild.FirstVertex.Y,
                            (HoveredVertex).X, (HoveredVertex).Y);
                    }
                }
                //free move
                else
                {
                    using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 1))
                    {
                        graphics.DrawLine(pen, edgeInBuild.FirstVertex.X, edgeInBuild.FirstVertex.Y,
                            mouse.X, mouse.Y);
                    }
                }
            }
        }

    }
}
