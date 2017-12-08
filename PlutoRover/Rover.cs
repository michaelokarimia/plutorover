using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position position;
        private Grid grid;

        public Rover()
        {
            position = new Position(0, 0, Compass.North);
            grid = new Grid(100, 100);
        }

        public Position GetPosition()
        {
            return position;
        }

        public void Forwards()
        {
            switch (position.CardinalPoint)
            {
                case Compass.North:
                    position.Y = grid.North(position.Y);
                    break;
                case Compass.East:
                    position.X = position.X + 1;
                    break;
                case Compass.South:
                    position.Y = grid.South(position.Y);
                    break;
                case Compass.West:
                    position.X = grid.West(position.X);
                    break;
            }
            
        }

        public void Back()
        {
            switch (position.CardinalPoint)
            {
                case Compass.North:
                    position.Y = grid.South(position.Y);
                    break;
                case Compass.East:
                    position.X = position.X - 1;
                    break;
                case Compass.South:
                    position.Y = grid.North(position.Y);
                    break;
                case Compass.West:
                    position.X = grid.East(position.X);
                    break;
            }

        }

        public void RightTurn()
        {
            switch(position.CardinalPoint)
            {
                case Compass.North:
                    position.CardinalPoint = Compass.East;
                    break;
                case Compass.East:
                    position.CardinalPoint = Compass.South;
                    break;
                case Compass.South:
                    position.CardinalPoint = Compass.West;
                    break;
                case Compass.West:
                    position.CardinalPoint = Compass.North;
                    break;

            }
        }

        public void LeftTurn()
        {
            switch(position.CardinalPoint)
            {
                case Compass.North:
                    position.CardinalPoint = Compass.West;
                    break;
                case Compass.West:
                    position.CardinalPoint = Compass.South;
                    break;
                case Compass.South:
                    position.CardinalPoint = Compass.East;
                    break;
                case Compass.East:
                    position.CardinalPoint = Compass.North;
                    break;
            }
        }
    }
}