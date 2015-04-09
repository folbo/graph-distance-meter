namespace wiercholki.Logic
{
    public class Vertex : myPoint
    {
        public Vertex()
        {
            Size = 10;
            Name = "";
            X = 0;
            Y = 0;
        }

        public Vertex(int x, int y, int size, string name) : base(x, y)
        {
            Size = size;
            Name = name;
        }
        public int Size { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
