using System;
using NUnit.Framework;

namespace Snake_Game.Tests.ModelTests
{
    [TestFixture]
    [Category("Model")]
    class PositionTest
    {

        [TestCase(10, 8)]
        public void AssertPositionReturnsCoordinates(int x, int y)
        {
            Src.Model.Position sut = new Src.Model.Position(x, y);

            Assert.AreEqual(sut.XCoordinate, x);
            Assert.AreEqual(sut.YCoordinate, y);
        }

        [TestCase(-6, -3)]
        public void AssertPositionThrowsException(int x, int y)
        {
            Assert.That(() => new Src.Model.Position(x, y), 
            Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}