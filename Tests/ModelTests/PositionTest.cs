using System;
using NUnit.Framework;

namespace Snake_Game.Tests.ModelTests
{
    [TestFixture]
    [Category("Model")]
    class PositionTest : TestBase<Src.Model.Position>
    {
        [SetUp]
        public override void Init()
        {
            _sut = new Src.Model.Position(0,0);
        }

        [TestCase(10, 8)]
        public void AssertPositionReturnsCoordinates(int x, int y)
        {
            _sut = new Src.Model.Position(x, y);

            Assert.AreEqual(_sut.XCoordinate, x);
            Assert.AreEqual(_sut.YCoordinate, y);
        }

        [TestCase(-6, -3)]
        public void AssertPositionThrowsException(int x, int y)
        {
            Assert.That(() => new Src.Model.Position(x, y),
            Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}