using System;
using System.Linq;
using Moq;
using Xunit;

namespace Snake_Game.Tests.ModelTests
{
    public class SnakeTest : TestBase<Src.Model.Snake>
    {
        public SnakeTest()
        {
            _sut = new Src.Model.Snake(new Src.Model.rules.RulesFactory());
            _sut.NewGame();
        }

        [Fact]
        public void AssertInitialSnakeIsCreated()
        {
            Assert.True(_sut.Body.Count > 0);
        }

        [Fact]
        public void AssertInitialSnakeIsCreatedFromRule()
        {
            var mockFactory = new Mock<Src.Model.rules.IRulesFactory>();
            var mockStrategy = new Mock<Src.Model.rules.SnakeGameStrategy>();
            mockFactory.Setup(t => t.GetSnakeGameStrategy()).Returns(mockStrategy.Object);

            _sut = new Src.Model.Snake(mockFactory.Object);
            _sut.NewGame();

            mockStrategy.Verify(s => s.GetInitSnake(), Times.Once());
        }

        [Fact]
        public void AssertSnakeHasDirection()
        {
            Assert.IsType<Src.Model.Direction>(_sut.Direction);
        }

        [Fact]
        public void AssertSnakeHasBody()
        {
            Assert.NotEmpty(_sut.Body);
        }

        [Fact]
        public void AssertSnakeHeadIsHead()
        {
            var result = _sut.GetHead();
            var expected = _sut.Body.Last();

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(Src.Model.Direction.Up)]
        [InlineData(Src.Model.Direction.Down)]
        [InlineData(Src.Model.Direction.Left)]
        [InlineData(Src.Model.Direction.Right)]
        public void AssertSnakeUpdatesDirection(Src.Model.Direction dir)
        {
            _sut.UpdateDirection(dir);
            Assert.Equal(dir, _sut.Direction);
        }

        [Fact]
        public void AssertSnakeMoves()
        {
            var result = _sut.Body.First();
            _sut.UpdatePosition();
            var expected = _sut.Body.First();

            Assert.NotEqual(result, expected);
        }
        [Theory]
        [InlineData(Src.Model.Direction.Up)]
        [InlineData(Src.Model.Direction.Down)]
        [InlineData(Src.Model.Direction.Right)]
        [InlineData(Src.Model.Direction.Left)]
        public void AssertSnakeMovesInRightDirection(Src.Model.Direction dir)
        {
            var expected = _sut.GetHead();
            _sut.UpdateDirection(dir);
            _sut.UpdatePosition();
            var result = _sut.GetHead();

            switch (dir)
            {
                case Src.Model.Direction.Up:
                    Assert.True(expected.YCoordinate > result.YCoordinate);
                    break;
                case Src.Model.Direction.Down:
                    Assert.True(expected.YCoordinate < result.YCoordinate);
                    break;
                case Src.Model.Direction.Right:
                    Assert.True(expected.XCoordinate < result.XCoordinate);
                    break;
                case Src.Model.Direction.Left:
                    Assert.True(expected.XCoordinate > result.XCoordinate);
                    break;
            }
        }

        [Fact]
        public void AssertSnakeGrows()
        {
            var result = _sut.Body.Count;
            _sut.Grow();
            var expected = _sut.Body.Count;

            Assert.True(expected > result);
        }

        [Fact]
        public void AssertSnakeIsNotDead()
        {
            Assert.False(_sut.Dead());
        }

        [Fact]
        public void AssertSnakeCanDie()
        {
            _sut = new Src.Model.Snake(new RulesFactoryStub());
            Assert.True(_sut.Dead());
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        public void AssertSnakeDiesFromHittingWall(int x, int y)
        {
            SnakeStub snakeStub = new SnakeStub(new Src.Model.rules.RulesFactory());
            snakeStub.NewGame();
            snakeStub.SetHead(x, y);

            Assert.True(snakeStub.Dead());
        }

        internal class SnakeStub : Src.Model.Snake
        {
            public SnakeStub(Src.Model.rules.IRulesFactory r_rules) : base(r_rules)
            {
            }

            public void SetHead(int x, int y)
            {
                MoveLastTail();
                Body.Add(new Src.Model.Position(x, y));
            }
        }
        internal class RulesFactoryStub : Src.Model.rules.RulesFactory, Src.Model.rules.IRulesFactory
        {
            public new Src.Model.rules.ISnakeRules GetGameRules()
            {
                return new SnakeRulesStub();
            }
        }
        internal class SnakeRulesStub : Src.Model.rules.SnakeRules, Src.Model.rules.ISnakeRules
        {
            public new bool IsGameOver(Src.Model.Snake s)
            {
                return true;
            }
        }
    }
}

