using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Snake_Game.Tests.ModelTests
{
    [TestFixture]
    [Category("Model")]
    class GameTest
    {
        private Src.Model.Game _sut;

        [SetUp]
        public void Init()
        {
            _sut = new Src.Model.Game();
            _sut.NewGame();
        }

        [Test]
        public void AssertSnakeIsCreatedOnNewGame()
        {
            Assert.IsNotNull(_sut.Snake.Body);
        }

        [Test]
        public void AssertFoodIsCreatedOnNewGame()
        {
            Assert.IsNotNull(_sut.Food.FoodPosition);
        }

        [TestCase(Src.Model.Direction.Up)]
        [TestCase(Src.Model.Direction.Down)]
        [TestCase(Src.Model.Direction.Left)]
        [TestCase(Src.Model.Direction.Right)]
        public void AssertSnakeDirectionIsSet(Src.Model.Direction dir)
        {
            _sut.SetDirection(dir);
            Assert.True(_sut.Snake.Direction == dir);
        }

        [Test]
        public void AssertSnakeGrowsWhenFed()
        {
            SetSnakeHeadWhereFoodIs(new SnakeInstanceStub());
            _sut.FeedSnake();
            int result = _sut.Snake.Body.Count;

            var game = new Src.Model.Game();
            game.NewGame();
            int expected = game.Snake.Body.Count + 1;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AssertFoodSpawnsOnNewLocationWhenEaten()
        {
            SetSnakeHeadWhereFoodIs(new SnakeInstanceStub());
            Src.Model.Position expected = _sut.Food.FoodPosition;
            _sut.FeedSnake();

            // WARNING: This test could fail in the unlikely event that food is regenerated on same position
            // TODO: Do test 2-4 more times if Food-position happens to be same
            Src.Model.Position result = _sut.Food.FoodPosition;
            Assert.False(expected.IsPositionEqualTo(result));
        }

        private void SetSnakeHeadWhereFoodIs(SnakeInstanceStub snakeStub)
        {
            _sut = new GameStub(snakeStub);
            _sut.NewGame();
            snakeStub.SetHead(_sut.Food.FoodPosition.XCoordinate, _sut.Food.FoodPosition.YCoordinate);
        }
    }

    class GameStub : Src.Model.Game
    {
        public GameStub(Src.Model.Snake snake)
        {
            Snake = snake;
        }
    }

    class SnakeInstanceStub : SnakeStub
    {
        public SnakeInstanceStub() : base(new Src.Model.rules.RulesFactory())
        {
        }
    }
}