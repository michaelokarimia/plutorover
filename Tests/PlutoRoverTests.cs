using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlutoRover;

namespace Tests
{
    [TestFixture]
    public class PlutoRoverTests
    {
        private Rover subject;

        [SetUp]
        public void SetUp()
        {
            subject = new Rover();
        }

        [Test]
        public void RoverReturnsPosition()
        {

            Position expectedPosition = new Position(0, 0, Compass.North);

            Assert.That(subject.GetPosition().X, Is.EqualTo(expectedPosition.X));
            Assert.That(subject.GetPosition().Y, Is.EqualTo(expectedPosition.Y));
            Assert.That(subject.GetPosition().CardinalPoint, Is.EqualTo(expectedPosition.CardinalPoint));
        }
    }
}
