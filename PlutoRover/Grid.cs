namespace PlutoRover

{
    public class Grid
    {
        private readonly int yLimit;
        private readonly int xLimit;
        private int[,] map;

        public Grid(int maxYLimit, int maxXLimit)
        {
            yLimit = maxYLimit;
            xLimit = maxXLimit;

            map = new int[100,100] ;

        }

        public Position North(Position startPosition)
        {
            Position endPosition;

            if (startPosition.Y + 1 == yLimit)
            {
                endPosition = new Position(startPosition.X, 0);
            }
            else
            {
                endPosition = new Position(startPosition.X, startPosition.Y + 1);
            }

            CheckForObstruction(endPosition);

            return endPosition;
        }
       

        public Position East(Position currentPosition)
        {
            Position endPosition;

            if (currentPosition.X + 1 == xLimit)
            {
                endPosition = new Position(0, currentPosition.Y);
            }
            else
            {
                endPosition = new Position(currentPosition.X + 1, currentPosition.Y);
            }

            CheckForObstruction(endPosition);

            return endPosition;
        }

        public Position South(Position postion)
        {
            Position endPosition;

            if (postion.Y == 0)
            {
                endPosition = new Position(postion.X,  yLimit - 1);
            }
            else
            {
                endPosition = new Position(postion.X, postion.Y - 1);
            }

            CheckForObstruction(endPosition);

            return endPosition;

        }

        public Position West(Position currentPostion)
        {
            Position endPosition;

            if (currentPostion.X == 0)
            {
                endPosition = new Position(xLimit - 1, currentPostion.Y);
            }
            else
            {
                endPosition = new Position(currentPostion.X - 1, currentPostion.Y);
            }

            CheckForObstruction(endPosition);

            return endPosition;
        }

        public void SetObstruction(int X, int Y)
        {
            map[Y,X] = 1;
        }

        private void CheckForObstruction(Position current)
        {
            if (map[current.Y, current.X] == 1)
            {
                throw new ObstructionException("Can not move here, obstruction at this postion");
            }
        }
    }
}