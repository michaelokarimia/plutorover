using System;

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

        public int North(Position currentYPosition)
        {
            var yCoOrd = -1;

            if (currentYPosition.Y + 1 == yLimit)
            {
                yCoOrd = 0;
            }
            else
            {
                yCoOrd = currentYPosition.Y + 1;
            }

            if(map[yCoOrd,currentYPosition.X] == 1)
            {
            
                throw new ObstructionException("Can not move here, obstruction at this postion");
            }

            return yCoOrd;
        }

        public int East(int currentXPostion)
        {
            if (currentXPostion + 1 == xLimit)
                return 0;

            return currentXPostion + 1;
        }

        public int South(int currentYPosition)
        {
            if(currentYPosition == 0)
            {
                return yLimit - 1;
            }

            return currentYPosition - 1;
        }

        public int West(int currentXPosition)
        {
            if(currentXPosition == 0)
            {
                return xLimit - 1;
            }
            return currentXPosition - 1;
        }

        public void SetObstruction(int X, int Y)
        {
            map[Y,X] = 1;
        }
    }
}