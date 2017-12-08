using System;

namespace PlutoRover

{
    public class Grid
    {
        private readonly int yLimit;
        private readonly int xLimit;

        public Grid(int maxYLimit, int maxXLimit)
        {
            yLimit = maxYLimit;
            xLimit = maxXLimit;
        }

        public int North(int currentYPosition)
        {
            if(currentYPosition + 1 >= yLimit)
            {
                return 0;
            }

            return currentYPosition + 1;
        }

        public int East(int currentXPostion)
        {
            if (currentXPostion + 1 >= xLimit)
                return 0;

            return currentXPostion + 1;
        }

        public int South(int currentYPosition)
        {
            if(currentYPosition - 1 == -1)
            {
                return yLimit;
            }

            return currentYPosition - 1;
        }

        public int West(int currentXPosition)
        {
            if(currentXPosition - 1 == -1)
            {
                return xLimit;
            }
            return currentXPosition - 1;
        }

       
    }
}