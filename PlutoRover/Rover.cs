using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position position;

        public Rover()
        {
            position = new Position(0, 0, Compass.North);
        }

        public Position GetPosition()
        {
            return position;
        }

        public void Forwards()
        {
            position.Y = position.Y + 1;
        }

        public void Back()
        {
            position.Y = position.Y - 1;
        }

        public void RightTurn()
        {
            switch(position.CardinalPoint)
            {
                case Compass.North:
                    position.CardinalPoint = Compass.East;
                    break;
            }
        }
    }
}