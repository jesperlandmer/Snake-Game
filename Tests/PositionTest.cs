using System;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    [TestFixture]
    [Category("Model")]
    class PositionUnitTest
    {
        [TestCase(10, 8)]
        public void AssertPositionReturnsCoordinates(int x, int y)
        {
            Src.Model.Position p = new Src.Model.Position(x, y);

            Assert.AreEqual(p.XCoordinate, x);
            Assert.AreEqual(p.YCoordinate, y);
        }

        [TestCase(-6, -3)]
        public void AssertPositionThrowsException(int x, int y)
        {
            Assert.That(() => new Src.Model.Position(x, y), 
            Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}