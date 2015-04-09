using System.IO;

namespace wiercholki.Logic
{
    public enum Direction { Both, ToFirst, ToSecond };

    public class Edge
    {
        public Edge(int weight = 1)
        {
            Weight = weight;
        }

        public Edge(Vertex firstVertex, Vertex secondVertex, Direction dir, int weight = 1)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
            Direction = dir;
            Weight = weight;
        }
        public Vertex FirstVertex { get; set; }
        public Vertex SecondVertex { get; set; }
        public Direction Direction { get; set; }
        public System.Drawing.Drawing2D.GraphicsPath Path { get; internal set; }
        public int Weight { get; set; }
    }
}
