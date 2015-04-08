using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiercholki.Logic
{
    public class Vertex : myPoint
    {
        public int Size { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
