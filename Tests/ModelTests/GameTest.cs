using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Snake_Game.Tests.ModelTests
{
    [TestFixture]
    [Category("Model")]
    class GameTest : TestBase<Src.Model.Game>
    {
        [SetUp]
        public override void Init()
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


        [Test]
        public void AssertGetArenaLimitsReturnLimits()
        {
            var RulesFactory = new Src.Model.rules.RulesFactory();
            int expected = RulesFactory.GetGameRules().GetArenaLimit();
            int result = _sut.GetArenaLimits();

            Assert.AreEqual(expected, result);
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
            SetSnakeHeadWhereFoodIs(new SnakeStub());
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