using System;
using System.Linq;
using Moq;
using Xunit;

namespace Snake_Game.Tests.ModelTests
{
    public class GameTest : TestBase<Src.Model.Game>
    {
        public GameTest()
        {
            _sut = new Src.Model.Game();
            _sut.NewGame();
        }

        [Fact]
        public void AssertSnakeIsCreatedOnNewGame()
        {
            Assert.NotNull(_sut.Snake.Body);
        }

        [Fact]
        public void AssertGetArenaLimitsReturnLimits()
        {
            var RulesFactory = new Src.Model.rules.RulesFactory();
            int expected = RulesFactory.GetGameRules().GetArenaLimit();
            int result = _sut.GetArenaLimits();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(Src.Model.Direction.Up)]
        [InlineData(Src.Model.Direction.Down)]
        [InlineData(Src.Model.Direction.Left)]
        [InlineData(Src.Model.Direction.Right)]
        public void AssertSnakeDirectionIsSet(Src.Model.Direction dir)
        {
            _sut.SetDirection(dir);
            Assert.True(_sut.Snake.Direction == dir);
        }
        [Fact]
        public void AssertSnakePositionIsUpdated()
        {
            Src.Model.Position expected = _sut.Snake.GetHead();
            _sut.SetDirection(Src.Model.Direction.Up);
            _sut.UpdateSnake();
            Src.Model.Position result = _sut.Snake.GetHead();

            Assert.True(result.YCoordinate < expected.YCoordinate);
        }

        [Fact]
        public void AssertGetGameSpeedReturnsSpeed()
        {
            var RulesFactory = new Src.Model.rules.RulesFactory();
            int expected = RulesFactory.GetGameRules().GetSpeedLimit();
            int result = _sut.Speed;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void AssertGameSpeedIncreaseOnSnakeFed()
        {
            SetSnakeHeadWhereFoodIs(new SnakeStub());
            _sut.FeedSnake();
            int result = _sut.Speed;

            var RulesFactory = new Src.Model.rules.RulesFactory();
            int initSpeed = RulesFactory.GetGameRules().GetSpeedLimit();
            int speedIncrease = RulesFactory.GetGameRules().GetSpeedIncrease();
            int expected = initSpeed + speedIncrease;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AssertFoodIsCreatedOnNewGame()
        {
            Assert.NotNull(_sut.Food.FoodPosition);
        }
        [Fact]
        public void AssertSnakeIsNotFedWhenNotOnFood()
        {
            int expected = _sut.Snake.Body.Count;
            _sut.FeedSnake();
            int result = _sut.Snake.Body.Count;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void AssertSnakeGrowsWhenFed()
        {
            SetSnakeHeadWhereFoodIs(new SnakeStub());
            _sut.FeedSnake();
            int result = _sut.Snake.Body.Count;

            var game = new Src.Model.Game();
            game.NewGame();
            int expected = game.Snake.Body.Count + 1;

            Assert.Equal(expected, result);
        }
        [Fact]
        public void AssertFoodSpawnsOnNewLocationWhenEaten()
        {
            SetSnakeHeadWhereFoodIs(new SnakeStub());
            Src.Model.Position expected = _sut.Food.FoodPosition;
            _sut.FeedSnake();

            // WARNING: This test could fail in the unlikely event that food is regenerated on same position
            // TODO: Do test 2-4 more times if Food-position happens to be same
            Src.Model.Position result = _sut.Food.FoodPosition;
            Assert.False(expected.IsPositionEqualTo(result));
        }
        private void SetSnakeHeadWhereFoodIs(SnakeStub snakeStub)
        {
            _sut = new GameStub(snakeStub);
            _sut.NewGame();
            snakeStub.SetHead(_sut.Food.FoodPosition.XCoordinate, _sut.Food.FoodPosition.YCoordinate);
        }
        [Fact]
        public void AssertNotGameOver()
        {
            Assert.False(_sut.IsGameOver());
        }

        internal class GameStub : Src.Model.Game
        {
            public GameStub(Src.Model.Snake snake)
            {
                Snake = snake;
            }
        }

        internal class SnakeStub : Src.Model.Snake
        {
            public SnakeStub() : base(new Src.Model.rules.RulesFactory())
            {
            }

            public void SetHead(int x, int y)
            {
                MoveLastTail();
                Body.Add(new Src.Model.Position(x, y));
            }
        }
    }
}