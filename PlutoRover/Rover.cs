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
    }
}