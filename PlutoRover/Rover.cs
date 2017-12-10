using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position position;
        private Grid grid;
        private Compass direction;
        public Compass Direction { get => direction; internal set => direction = value; }


        public Rover()
        {
            direction = Compass.North;
            position = new Position(0, 0);
            grid = new Grid(100, 100);
        }

        public Position GetPosition()
        {
            return position;
        }

        public void Forwards()
        {
            switch (direction)
            {
                case Compass.North:
                    position = grid.North(position);
                    break;
                case Compass.East:
                    position = grid.East(position);
                    break;
                case Compass.South:
                    position = grid.South(position);
                    break;
                case Compass.West:
                    position = grid.West(position);
                    break;
            }
            
        }

        public void Back()
        {
            switch (direction)
            {
                case Compass.North:
                    position = grid.South(position);
                    break;
                case Compass.East:
                    position = grid.West(position);
                    break;
                case Compass.South:
                    position = grid.North(position);
                    break;
                case Compass.West:
                    position = grid.East(position);
                    break;
            }

        }

        public void RightTurn()
        {
            switch(direction)
            {
                case Compass.North:
                    direction = Compass.East;
                    break;
                case Compass.East:
                    direction= Compass.South;
                    break;
                case Compass.South:
                    direction = Compass.West;
                    break;
                case Compass.West:
                    direction = Compass.North;
                    break;

            }
        }

        public void LeftTurn()
        {
            switch(direction)
            {
                case Compass.North:
                    direction = Compass.West;
                    break;
                case Compass.West:
                    direction = Compass.South;
                    break;
                case Compass.South:
                    direction = Compass.East;
                    break;
                case Compass.East:
                    direction = Compass.North;
                    break;
            }
        }
    }
}