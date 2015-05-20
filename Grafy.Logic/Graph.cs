using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy.Logic
{
    public class Graph
    {
        private AdjacencyMatrix _adjacencyMatrix;
        public AdjacencyMatrix AdjacencyMatrix { get { return _adjacencyMatrix; } }

        private List<Vertex> _verticles;
        private List<Edge> _edges;

        public List<Vertex> Verticles { get { return _verticles; } }
        public List<Edge> Edges { get { return _edges; } }

        public Vertex SelectedVertex;
        public Edge SelectedEdge;

        public Vertex HoveredVertex;
        public Edge HoveredEdge;

        public Edge EdgeInBuild;

        public int maxWeight;

        public Graph()
        {
            _adjacencyMatrix = new AdjacencyMatrix();

            _verticles = new List<Vertex>();
            _edges = new List<Edge>();

            EdgeInBuild = null;
            HoveredEdge = null;
            HoveredVertex = null;
            SelectedEdge = null;
            SelectedVertex = null;

            maxWeight = 10;
        }

        public void UpdateVertexId()
        {
            for (int i = 0; i < _verticles.Count; i++)
            {
                _verticles[i].Id = i;
            }
        }

        public void AddVertex(Vertex elem)
        {
            _verticles.Add(elem);
            _adjacencyMatrix.AddVerticle();

            UpdateVertexId();
        }

        public void RemoveVertex(Vertex elem)
        {
            if (_verticles.Contains(elem))
            {
                var relatedEdges = _edges.Where(x => (x.FirstVertex == elem || x.SecondVertex == elem)).ToList();
                foreach (var edge in relatedEdges)
                {
                    RemoveEdge(edge);
                }

                _verticles.Remove(elem);

                _adjacencyMatrix.RemoveVerticle(elem.Id);
            }

            UpdateVertexId();
        }

        public void AddEdge(Edge elem, bool updateAdjacencyMatrix = true)
        {
            _edges.Add(elem);
            UpdateRelatedPaths(elem);

            if (updateAdjacencyMatrix)
            {
                if (elem.Direction == Direction.Both)
                {
                    if (elem.FirstVertex != elem.SecondVertex)
                    {
                        _adjacencyMatrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
                        _adjacencyMatrix[elem.SecondVertex.Id, elem.FirstVertex.Id] += 1;
                    }
                    else
                    {
                        _adjacencyMatrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
                    }
                }
                if (elem.Direction == Direction.ToFirst)
                {
                    _adjacencyMatrix[elem.FirstVertex.Id, elem.SecondVertex.Id] += 1;
                }
                if (elem.Direction == Direction.ToSecond)
                {
                    _adjacencyMatrix[elem.SecondVertex.Id, elem.FirstVertex.Id] += 1;
                }
            }
        }

        public void RemoveEdge(Edge elem, bool updateAdjacencyMatrix = true)
        {
            if (_edges.Contains(elem))
                _edges.Remove(elem);

            if (updateAdjacencyMatrix)
            {

                if (elem.FirstVertex == elem.SecondVertex)
                {
                    _adjacencyMatrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                    return;
                }

                if (elem.Direction == Direction.Both)
                {
                    _adjacencyMatrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                    _adjacencyMatrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
                }
                if (elem.Direction == Direction.ToFirst)
                {
                    _adjacencyMatrix[elem.SecondVertex.Id, elem.FirstVertex.Id] -= 1;
                }
                if (elem.Direction == Direction.ToSecond)
                {
                    _adjacencyMatrix[elem.FirstVertex.Id, elem.SecondVertex.Id] -= 1;
                }
            }
        }

        public void ChangeDirection(Edge edge, Direction direction)
        {
            if (direction == Direction.Both && edge.Direction != Direction.Both)
            {
                if (edge.Direction == Direction.ToSecond)
                {
                    _adjacencyMatrix[edge.SecondVertex.Id, edge.FirstVertex.Id] += 1;
                }
                else
                {
                    _adjacencyMatrix[edge.FirstVertex.Id, edge.SecondVertex.Id] += 1;
                }
            }

            if (direction == Direction.ToFirst && edge.Direction != Direction.ToFirst)
            {
                if (edge.Direction == Direction.ToSecond)
                {
                    _adjacencyMatrix[edge.SecondVertex.Id, edge.FirstVertex.Id] += 1;
                }

                _adjacencyMatrix[edge.FirstVertex.Id, edge.SecondVertex.Id] -= 1;
            }

            if (direction == Direction.ToSecond && edge.Direction != Direction.ToSecond)
            {
                if (edge.Direction == Direction.ToFirst)
                {
                    _adjacencyMatrix[edge.FirstVertex.Id, edge.SecondVertex.Id] += 1;
                }

                _adjacencyMatrix[edge.SecondVertex.Id, edge.FirstVertex.Id] -= 1;
            }

            edge.Direction = direction;
        }

        public Vertex FindNearestVertex(float x, float y, int range)
        {
            Vertex nearest = null;
            int distance = range;
            foreach (var vertex in _verticles)
            {
                if (Math.Pow(x - vertex.X, 2) + Math.Pow(y - vertex.Y, 2) < distance)
                    nearest = vertex;
            }
            return nearest;
        }

        public Edge FindNearestEdge(float x, float y, float range)
        {
            var mouse = new PointF(x, y);
            var ret = _edges.FirstOrDefault(edge => edge.Path.IsOutlineVisible(mouse, new Pen(Color.Black, range)));

            return ret;
        }

        private void PaintVerticles(Graphics graphics)
        {
            foreach (var vertex in _verticles)
            {
                var X = vertex.X - vertex.Size / 2;
                var Y = vertex.Y - vertex.Size / 2;

                graphics.DrawEllipse(Pens.Indigo, X, Y, vertex.Size, vertex.Size);
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
                        graphics.FillEllipse(brush, X, Y, vertex.Size, vertex.Size);
                    }
                }
                if (vertex == HoveredVertex)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(100, 20, 60, 200)))
                    {
                        graphics.FillEllipse(brush, X, Y, vertex.Size, vertex.Size);
                    }
                }
            }
        }

        private void PaintEdges(Graphics graphics)
        {
            foreach (var edge in _edges)
            {
                using (var pen = new System.Drawing.Pen(ColorBlend(Color.Blue, Color.Red, (float)edge.Weight / maxWeight), 1))
                {
                    if (edge.Direction == Direction.ToFirst)
                    {
                        AdjustableArrowCap cap = new AdjustableArrowCap(3, 7) {Filled = true};
                        pen.CustomStartCap = cap;
                    }
                    if (edge.Direction == Direction.ToSecond)
                    {
                        AdjustableArrowCap cap = new AdjustableArrowCap(3, 7) { Filled = true };
                        pen.CustomEndCap = cap;
                    }

                    graphics.DrawPath(pen, edge.Path);
                }
                
                if (edge == HoveredEdge && EdgeInBuild == null)
                {
                    using (var pen = new Pen(Color.FromArgb(100, 20, 60, 200), 4))
                    {
                        graphics.DrawPath(pen, edge.Path);
                    }
                } 
                if (edge == SelectedEdge)
                {
                    using (var pen = new Pen(Color.FromArgb(100, 20, 60, 200), 4))
                    {
                        graphics.DrawPath(pen, edge.Path);
                    }
                }
            }
        }

        public void UpdateRelatedPaths(Edge elem)
        {
            Edge[] edges =
                _edges.Where(
                    edge =>
                        (edge.FirstVertex == elem.FirstVertex && edge.SecondVertex == elem.SecondVertex) ||
                        (edge.FirstVertex == elem.SecondVertex && edge.SecondVertex == elem.FirstVertex)).ToArray();

            //rysuj kwiatki
            if (elem.FirstVertex == elem.SecondVertex)
            {
                float stepAngle = 2 * (float)Math.PI / edges.Length;

                for (int i = 0; i < edges.Length; i++)
                {
                    var edge = edges[i];
                    edge.Path = new GraphicsPath();

                    var bezierPoints = new PointF[4]
                    {
                        new PointF(edge.FirstVertex.X, edge.FirstVertex.Y),
                        new PointF(edge.FirstVertex.X + 50*(float)Math.Sin((i*stepAngle) - 10), 
                            edge.FirstVertex.Y + 50*(float)Math.Cos((i*stepAngle) - 10)),
                        new PointF(edge.FirstVertex.X + 50*(float)Math.Sin((i*stepAngle) + 10),
                            edge.FirstVertex.Y + 50*(float)Math.Cos((i*stepAngle) + 10)),
                        new PointF(edge.SecondVertex.X, edge.SecondVertex.Y)
                    };
                    edge.Path.AddBeziers(bezierPoints);
                }
            }
            else //rysuj łuki
            {
                double alfa = 0; //15 stopni
                double alfaStep = 2*(Math.PI/4/edges.Length);
                int i = 0; //licznik pętli
                int changeSide = 1;
                foreach (var edge in edges)
                {
                    edge.Path = new GraphicsPath();

                    //zdefiniuj wektor między wierzcholkami
                    var vector = new myPoint(edge.SecondVertex.X - edge.FirstVertex.X, edge.SecondVertex.Y - edge.FirstVertex.Y);
                    double vectorLength = Math.Sqrt(vector.X*vector.X + vector.Y*vector.Y);
                    //wektor krawedzi pierwszego wierzcholka

                    var tangentFirst = vector / vectorLength; //dlugosc 1
                    var tangentSecond =  vector / (vectorLength * -1); //dlugosc 1 i przeciwny kierunek
                        changeSide *= -1;
                    if (i%2 != 0)
                        alfa = changeSide*alfaStep*i;
                    else
                        alfa *= -1;
                    tangentFirst = tangentFirst.Rotate(alfa) * edge.FirstVertex.Size / 2;
                    tangentSecond = tangentSecond.Rotate((-alfa)) * edge.FirstVertex.Size / 2;

                    var bezierPoints = new PointF[]
                    {
                        new PointF(edge.FirstVertex.X + tangentFirst.X, edge.FirstVertex.Y + tangentFirst.Y),
                        new PointF(edge.FirstVertex.X+ tangentFirst.X*(float)5, edge.FirstVertex.Y+ tangentFirst.Y*(float)5),
                        new PointF(edge.SecondVertex.X+tangentSecond.X*(float)5, edge.SecondVertex.Y+tangentSecond.Y*(float)5),
                        new PointF(edge.SecondVertex.X + tangentSecond.X, edge.SecondVertex.Y  + tangentSecond.Y)
                    };

                    edge.Path.AddBeziers(bezierPoints);

                    i++;
                }
            }
        }

        public void PaintGraph(Graphics graphics, myPoint mouse)
        {
            PaintVerticles(graphics);
            PaintEdges(graphics);

            if (EdgeInBuild != null)
            {
                //magnetic
                if ((HoveredVertex) != null)
                {
                    using (var pen = new Pen(Color.FromArgb(100, 20, 60, 200), 4))
                    {
                        graphics.DrawLine(pen, EdgeInBuild.FirstVertex.X, EdgeInBuild.FirstVertex.Y,
                            (HoveredVertex).X, (HoveredVertex).Y);
                    }
                }
                //free move
                else
                {
                    using (var pen = new Pen(Color.FromArgb(100, 20, 60, 200), 1))
                    {
                        graphics.DrawLine(pen, EdgeInBuild.FirstVertex.X, EdgeInBuild.FirstVertex.Y,
                            mouse.X, mouse.Y);
                    }
                }
            }
        }

        private static int Blend(int a, int b, float alpha)
        {
            return Convert.ToInt16((1.0 - alpha) * a + alpha * b);
        }
        private static Color ColorBlend(Color col1, Color col2, float alpha)
        {
            int a = 255;
            int r = Blend(col1.R, col2.R, alpha);
            int g = Blend(col1.G, col2.G, alpha);
            int b = Blend(col1.B, col2.B, alpha);

            return Color.FromArgb(a, r, g, b);
        }

    }
}
