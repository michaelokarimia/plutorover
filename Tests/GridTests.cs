using NUnit.Framework;
using PlutoRover;
using System;

namespace Tests
{
    [TestFixture]
    public class GridTests
    {
        private Grid subject;

        [SetUp]
        public void Setup()
        {
            subject = new Grid(100,100);
        }

        [Test]
        public void NorthAt99YAxisWrapsTo0()
        {
            Assert.AreEqual(0, subject.North(new Position(0,99,Compass.North)));
        }

        [Test]
        public void SouthAt0YAxisWrapsTo99()
        {
            Assert.AreEqual(99, subject.South(0));
        }

        [Test]
        public void WestAt0XAxisWrapsAt99()
        {
            Assert.AreEqual(99, subject.West(0));
        }

        [Test]
        public void EastAt99XAxisWrapsTo0()
        {
            Assert.AreEqual(0, subject.East(99));
        }

        [Test]
        public void ThrowsExceptionWhenRoverAttemptsToMovesOverAnObstruction()
        {
            subject.SetObstruction(0, 1);

            Assert.Throws<ObstructionException>(() => subject.North(new Position(0,0,Compass.North)));

        }

    }
}
