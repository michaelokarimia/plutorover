using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position position;
        private Grid grid;
        private Compass cardinalPoint;
        public Compass CardinalPoint { get => cardinalPoint; internal set => cardinalPoint = value; }


        public Rover()
        {
            cardinalPoint = Compass.North;
            position = new Position(0, 0);
            grid = new Grid(100, 100);
        }

        public Position GetPosition()
        {
            return position;
        }

        public void Forwards()
        {
            switch (cardinalPoint)
            {
                case Compass.North:
                    position.Y = grid.North(position);
                    break;
                case Compass.East:
                    position.X = grid.East(position.X);
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
            switch (cardinalPoint)
            {
                case Compass.North:
                    position.Y = grid.South(position.Y);
                    break;
                case Compass.East:
                    position.X = grid.West(position.X);
                    break;
                case Compass.South:
                    position.Y = grid.North(position);
                    break;
                case Compass.West:
                    position.X = grid.East(position.X);
                    break;
            }

        }

        public void RightTurn()
        {
            switch(cardinalPoint)
            {
                case Compass.North:
                    cardinalPoint = Compass.East;
                    break;
                case Compass.East:
                    cardinalPoint= Compass.South;
                    break;
                case Compass.South:
                    cardinalPoint = Compass.West;
                    break;
                case Compass.West:
                    cardinalPoint = Compass.North;
                    break;

            }
        }

        public void LeftTurn()
        {
            switch(cardinalPoint)
            {
                case Compass.North:
                    cardinalPoint = Compass.West;
                    break;
                case Compass.West:
                    cardinalPoint = Compass.South;
                    break;
                case Compass.South:
                    cardinalPoint = Compass.East;
                    break;
                case Compass.East:
                    cardinalPoint = Compass.North;
                    break;
            }
        }
    }
}