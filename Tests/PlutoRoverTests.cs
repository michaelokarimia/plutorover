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
        public void RoverReturnsPositionInDefaultStartPoint()
        {

            Position expectedPosition = new Position(0, 0, Compass.North);

            Assert.That(subject.GetPosition().X, Is.EqualTo(expectedPosition.X));
            Assert.That(subject.GetPosition().Y, Is.EqualTo(expectedPosition.Y));
            Assert.That(subject.GetPosition().CardinalPoint, Is.EqualTo(expectedPosition.CardinalPoint));
        }

        [Test]
        public void RoverMovesForwardWhenCommanded()
        {

            Position expectedPosistion = new Position(0, 1, Compass.North);

            Assert.AreNotEqual(subject.GetPosition().Y, expectedPosistion.Y);


            subject.Forwards();


            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, expectedPosistion.CardinalPoint);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
        }

        [Test]
        public void RoverMovesBackwardsWhenCommanded()
        {

            Position expectedPosistion = new Position(0, 0, Compass.North);

            subject.Forwards();
            Assert.AreEqual(subject.GetPosition().Y, 1);

            subject.Back();



            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, expectedPosistion.CardinalPoint);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
        }


        [Test]
        public void RightCommandTurnsRover90DegreesToTheRight()
        {
            Position expectedPosistion = new Position(0, 0, Compass.East);

            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.North);

            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, expectedPosistion.CardinalPoint);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
        }

        [Test]
        public void TwoRightTurnsPointTheRoverToTheSouth()
        {
            Position expectedPosistion = new Position(0, 0, Compass.South);

            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.North);

            subject.RightTurn();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, expectedPosistion.CardinalPoint);

        }

        [Test]
        public void ThreeRightTurnsPointTheRoverToTheWest()
        {
            Position expectedPosistion = new Position(0, 0, Compass.West);

            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.North);

            subject.RightTurn();
            subject.RightTurn();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, expectedPosistion.CardinalPoint);

        }

        [Test]
        public void FourTurnsRightPointRoverBackToNorth()
        {
            Position expectedPosistion = new Position(0, 0, Compass.North);

            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.North);

            subject.RightTurn();
            subject.RightTurn();
            subject.RightTurn();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, expectedPosistion.CardinalPoint);
        }

        [TestCase(Compass.North, 0)]
        [TestCase(Compass.West, 1)]
        [TestCase(Compass.South, 2)]
        [TestCase(Compass.East, 3)]
        [TestCase(Compass.North, 4)]
        public void LeftTurnTests(Compass expected, int timeToTurnLeft)
        {

            for(int i = 0; i< timeToTurnLeft; i++)
            {
                subject.LeftTurn();
            }

            Assert.AreEqual(subject.GetPosition().CardinalPoint, expected);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.GetPosition().Y, 0);
        }
    }
}