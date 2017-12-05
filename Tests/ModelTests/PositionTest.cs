using System;
using Xunit;

namespace Snake_Game.Tests.ModelTests
{
    public class PositionTest : TestBase<Src.Model.Position>
    {
        public PositionTest()
        {
            _sut = new Src.Model.Position(0, 0);
        }

        [Theory]
        [InlineData(10, 8)]
        public void AssertPositionReturnsCoordinates(int x, int y)
        {
            _sut = new Src.Model.Position(x, y);

            Assert.Equal(_sut.XCoordinate, x);
            Assert.Equal(_sut.YCoordinate, y);
        }

        [Theory]
        [InlineData(-6, -3)]
        public void AssertPositionThrowsException(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Src.Model.Position(x, y));
        }
    }
}