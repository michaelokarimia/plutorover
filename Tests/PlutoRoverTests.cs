﻿using System;
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

            Assert.AreEqual(subject.GetPosition().CardinalPoint, expected);
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

            Assert.AreEqual(subject.GetPosition().CardinalPoint, expected);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.GetPosition().Y, 0);
        }



        [TestCase(Compass.North, 0, 0)]
        [TestCase(Compass.North, 1, 1)]
        [TestCase(Compass.East, 1, 2)]
        [TestCase(Compass.South, 1, 3)]
        [TestCase(Compass.West, 1, 4)]
        public void TurnsTests(Compass expected, int leftTurnCount, int rightTurnCount)
        {

            for (int i = 0; i < leftTurnCount; i++)
            {
                subject.LeftTurn();
            }

            for (int i = 0; i < rightTurnCount; i++)
            {
                subject.RightTurn();
            }

            Assert.AreEqual(subject.GetPosition().CardinalPoint, expected);
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
            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.East);
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
            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.South);

            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().Y, 0);
            Assert.AreEqual(subject.GetPosition().X, 2);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.West);

            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            Assert.AreEqual(subject.GetPosition().Y, 0);
            Assert.AreEqual(subject.GetPosition().X, 0);
            Assert.AreEqual(subject.GetPosition().CardinalPoint, Compass.North);

        }


        [Test]
        public void CanMoveForwardsInASquareAllDirectionsTurningLeft()
        {
            subject.Forwards();
            subject.Forwards();
            subject.RightTurn();

            subject.Forwards();
            subject.Forwards();
            
            //should be


            Assert.AreEqual(2, subject.GetPosition().X);
            Assert.AreEqual(2, subject.GetPosition().Y);
            Assert.AreEqual(Compass.East, subject.GetPosition().CardinalPoint);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();

            Assert.AreEqual(2, subject.GetPosition().Y);
            Assert.AreEqual(4, subject.GetPosition().X);
            Assert.AreEqual(Compass.North, subject.GetPosition().CardinalPoint);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();

            Assert.AreEqual(4, subject.GetPosition().Y);
            Assert.AreEqual(4, subject.GetPosition().X);
            Assert.AreEqual(Compass.West, subject.GetPosition().CardinalPoint);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();

            Assert.AreEqual(4, subject.GetPosition().Y);
            Assert.AreEqual(2, subject.GetPosition().X);
            Assert.AreEqual(Compass.South, subject.GetPosition().CardinalPoint);

            subject.Forwards();
            subject.Forwards();
            subject.LeftTurn();
            subject.LeftTurn();

            Assert.AreEqual(2, subject.GetPosition().Y);
            Assert.AreEqual(2, subject.GetPosition().X);
            Assert.AreEqual(Compass.North, subject.GetPosition().CardinalPoint);

        }

    }
}