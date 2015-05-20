using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy.Logic
{
    public class Vertex : myPoint
    {
        public Vertex(float x, float y, float size, string name)
            : base(x, y)
        {
            Size = size;
            Name = name;
        }

        public int Id { get; set; }
        public float Size { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
