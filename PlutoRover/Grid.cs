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

        public int North(Position currentPosition)
        {
            if (currentPosition.Y + 1 == yLimit)
            {
                currentPosition.Y = 0;
            }
            else
            {
                currentPosition.Y = currentPosition.Y + 1;
            }

            CheckForObstruction(currentPosition);

            return currentPosition.Y;
        }
       

        public int East(Position position)
        {
            if (position.X + 1 == xLimit)
            {
                position.X = 0;
            }
            else
            {
                position.X = position.X + 1;
            }

            return position.X;
        }

        public int South(Position postion)
        {
            if (postion.Y == 0)
            {
                postion.Y = yLimit - 1;
            }
            else
            {
                postion.Y = postion.Y - 1;
            }

            return postion.Y;
        }

        public int West(Position position)
        {
            if (position.X == 0)
            {
                position.X = xLimit - 1;
            }
            else
            {
                position.X = position.X - 1;
            }

            return position.X;
        }

        public void SetObstruction(int X, int Y)
        {
            map[Y,X] = 1;
        }

        private void CheckForObstruction(Position currentPos)
        {
            if (map[currentPos.Y, currentPos.X] == 1)
            {

                throw new ObstructionException("Can not move here, obstruction at this postion");
            }
        }
    }
}