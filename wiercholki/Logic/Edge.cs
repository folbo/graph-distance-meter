using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiercholki.Logic
{
    public class Edge
    {
        public Edge(int weight = 1)
        {
            Weight = weight;
        }
        public Vertex FirstVertex { get; set; }
        public Vertex SecondVertex { get; set; }
        public Direction Direction { get; set; }
        public System.Drawing.Drawing2D.GraphicsPath Path { get; internal set; }
        public int Weight { get; set; }
    }
}
