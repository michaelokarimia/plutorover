namespace PlutoRover
{
    public class Position
    {
        private int x;
        private int y;
        private Compass cardinalPoint;

        public Position(int x, int y, Compass cardinalPoint)
        {
            this.x = x;
            this.y = y;
            this.cardinalPoint = cardinalPoint;
        }

        public int X { get => x; }
        public int Y { get => y; internal set => y = value; }
        public Compass CardinalPoint { get => cardinalPoint; internal set => cardinalPoint = value; }
    }
}