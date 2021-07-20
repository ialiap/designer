namespace Designer.Common.ValueObject
{
    public class Spot
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Spot(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
