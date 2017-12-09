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

            Position expectedPosition = new Position(0, 0);

            Assert.That(subject.GetPosition().X, Is.EqualTo(expectedPosition.X));
            Assert.That(subject.GetPosition().Y, Is.EqualTo(expectedPosition.Y));
            Assert.That(subject.Direction, Is.EqualTo(Compass.North));
        }

        [Test]
        public void RoverMovesForwardWhenCommanded()
        {

            Position expectedPosistion = new Position(0, 1);

            Assert.AreNotEqual(subject.GetPosition().Y, expectedPosistion.Y);


            subject.Forwards();


            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.Direction, Compass.North);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
        }

        [Test]
        public void RoverMovesBackwardsWhenCommanded()
        {

            Position expectedPosistion = new Position(0, 0);

            subject.Forwards();
            Assert.AreEqual(subject.GetPosition().Y, 1);

            subject.Back();

            Assert.AreEqual(subject.GetPosition().X, expectedPosistion.X);
            Assert.AreEqual(subject.Direction, Compass.North);
            Assert.AreEqual(subject.GetPosition().Y, expectedPosistion.Y);
        }


        [TestCase(Compass.North, 0)]
        [TestCase(Compass.East, 1)]
        [TestCase(Compass.South, 2)]
        [TestCase(Compass.West, 3)]
        [TestCase(Compass.North, 4)]
        public void RightTurnTests(Compass expected, int rightturnCount)
        {

            for (int i = 0; i < rightturnCount; i++)
            {
                subject.RightTurn();
            }

            Assert.AreEqual(subject.Direction, expected);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.GetPosition().Y, 0);
        }


        [TestCase(Compass.North, 0)]
        [TestCase(Compass.West, 1)]
        [TestCase(Compass.South, 2)]
        [TestCase(Compass.East, 3)]
        [TestCase(Compass.North, 4)]
        public void LeftTurnTests(Compass expected, int leftTurnCount)
        {

            for(int i = 0; i< leftTurnCount; i++)
            {
                subject.LeftTurn();
            }

            Assert.AreEqual(subject.Direction, expected);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.GetPosition().Y, 0);
        }



        [TestCase(Compass.North, 0, 0)]
        [TestCase(Compass.North, 1, 1)]
        [TestCase(Compass.East, 1, 2)]
        [TestCase(Compass.South, 1, 3)]
        [TestCase(Compass.West, 1, 4)]
        public void TurnsTests(Compass expectedDirection, int leftTurnCount, int rightTurnCount)
        {

            for (int i = 0; i < leftTurnCount; i++)
            {
                subject.LeftTurn();
            }

            for (int i = 0; i < rightTurnCount; i++)
            {
                subject.RightTurn();
            }

            Assert.AreEqual(subject.Direction, expectedDirection);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.GetPosition().Y, 0);
        }

        [Test]
        public void MovementTests()
        {
            //FFRFF
            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();
            subject.Forwards();
            subject.Forwards();

            Assert.AreEqual(subject.GetPosition().X, 2);
            Assert.AreEqual(subject.GetPosition().Y, 2);
            Assert.AreEqual(subject.Direction, Compass.East);
        }

        [Test]
        public void CanMoveForwardsInASquareAllDirectionsTurningRight()
        {
            //FFR FFR FFRFFRF

            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().X, 2);
            Assert.AreEqual(subject.GetPosition().Y, 2);
            Assert.AreEqual(subject.Direction, Compass.South);

            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().Y, 0);
            Assert.AreEqual(subject.GetPosition().X, 2);
            Assert.AreEqual(subject.Direction, Compass.West);

            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().Y, 0);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.Direction, Compass.North);

        }


        [Test]
        public void CanMoveForwardsInASquareAllDirectionsTurningLeft()
        {
            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            subject.Forwards();
            subject.Forwards();
            
            Assert.AreEqual(2, subject.GetPosition().X);
            Assert.AreEqual(2, subject.GetPosition().Y);
            Assert.AreEqual(Compass.East, subject.Direction);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();

            Assert.AreEqual(2, subject.GetPosition().Y);
            Assert.AreEqual(4, subject.GetPosition().X);
            Assert.AreEqual(Compass.North, subject.Direction);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();

            Assert.AreEqual(4, subject.GetPosition().Y);
            Assert.AreEqual(4, subject.GetPosition().X);
            Assert.AreEqual(Compass.West, subject.Direction);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();

            Assert.AreEqual(4, subject.GetPosition().Y);
            Assert.AreEqual(2, subject.GetPosition().X);
            Assert.AreEqual(Compass.South, subject.Direction);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();
            subject.LeftTurn();

            Assert.AreEqual(2, subject.GetPosition().Y);
            Assert.AreEqual(2, subject.GetPosition().X);
            Assert.AreEqual(Compass.North, subject.Direction);

        }

        [Test]
        public void BackwardsTests()
        {

            subject.LeftTurn();
            subject.Back();

            Assert.AreEqual(0, subject.GetPosition().Y);
            Assert.AreEqual(1, subject.GetPosition().X);

            subject.LeftTurn();
            subject.Back();

            Assert.AreEqual(1, subject.GetPosition().Y);
            Assert.AreEqual(1, subject.GetPosition().X);

            subject.LeftTurn();
            subject.Back();

            Assert.AreEqual(1, subject.GetPosition().Y);
            Assert.AreEqual(0, subject.GetPosition().X);

            subject.LeftTurn();
            subject.Back();

            Assert.AreEqual(0, subject.GetPosition().Y);
            Assert.AreEqual(0, subject.GetPosition().X);


        }


        [Test]
        public void GridWrapsYAxisWhenMovingOffTheEdge()
        {

            subject.Back();

            Assert.AreEqual(99, subject.GetPosition().Y);

            subject.Forwards();

            Assert.AreEqual(0, subject.GetPosition().Y);

            subject.Back();
            subject.Back();

            Assert.AreEqual(98, subject.GetPosition().Y);

            subject.RightTurn();
            subject.RightTurn();

            //reverse over the 0 Y line
            subject.Back();
            subject.Back();

            Assert.AreEqual(0, subject.GetPosition().Y);
            Assert.AreEqual(0, subject.GetPosition().X);

            subject.LeftTurn();
            subject.LeftTurn();

            Assert.AreEqual(Compass.North, subject.Direction);


            subject.RightTurn();
            subject.RightTurn();

            Assert.AreEqual(Compass.South, subject.Direction);

            subject.Forwards();

            Assert.AreEqual(99, subject.GetPosition().Y);



        }

        [Test]
        public void GridWrapsXAxis()
        {

            //test back and fowards over X axis

            subject.LeftTurn();

            subject.Forwards();
            //can go forward over the 0 X from East to West
            Assert.AreEqual(99, subject.GetPosition().X);

            //go backwards over x axis from West to East
            subject.Back();

            Assert.AreEqual(0, subject.GetPosition().X);

            subject.Forwards();
            //can go forward over the 0 X
            Assert.AreEqual(99, subject.GetPosition().X);

            subject.RightTurn();
            subject.RightTurn();

            //cross forwards over X axis from West to East
            subject.Forwards();


            Assert.AreEqual(0, subject.GetPosition().X);
            Assert.AreEqual(Compass.East, subject.Direction);

            //can reverse over X axis and wrap from 0 to 99

            subject.Back();


            Assert.AreEqual(99, subject.GetPosition().X);

        }

        
    }
}