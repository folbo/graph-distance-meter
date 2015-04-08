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
