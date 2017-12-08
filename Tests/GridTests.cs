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
    public class GridTests
    {
        private Grid subject;

        [SetUp]
        public void Setup()
        {
            subject = new Grid(100,100);
        }

        [Test]
        public void NorthAt100YWrapsTo0()
        {
            Assert.AreEqual(0, subject.North(99));
        }

        [Test]
        public void SouthAt0Wraps100()
        {
            Assert.AreEqual(100, subject.South(0));
        }

        [Test]
        public void WestAt0WrapsAt100()
        {
            Assert.AreEqual(100, subject.West(0));
        }

        [Test]
        public void EastAt100WrapsTo0()
        {
            Assert.AreEqual(0, subject.East(100));
        }

    }
}
