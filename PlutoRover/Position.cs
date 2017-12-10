namespace PlutoRover
{
    public struct Position
    {
        private int x;
        private int y;


        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        
        }

        public int X { get => x; internal set => x = value; }
        public int Y { get => y; internal set => y = value; }
    }
}