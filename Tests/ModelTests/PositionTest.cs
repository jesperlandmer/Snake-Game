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

        [Fact]
        public void AssertPositionsAreEqual()
        {
            var pos1 = new Src.Model.Position(10, 10);
            var pos2 = new Src.Model.Position(10, 10);
            Assert.True(pos1.IsPositionEqualTo(pos2));
        }
        [Fact]
        public void AssertPositionsAreNotEqual()
        {
            var pos1 = new Src.Model.Position(10, 10);
            var pos2 = new Src.Model.Position(0, 0);
            Assert.False(pos1.IsPositionEqualTo(pos2));
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
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void AssertPositionThrowsException(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Src.Model.Position(x, y));
        }
    }
}