using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    [TestFixture]
    [Category("Model")]
    class GameTest
    {
        private Src.Model.Game _sut;
        private Mock<Src.Model.Snake> _snakeMock;
        private Mock<Src.Model.Food> _foodMock;
        private Src.Model.rules.IRulesFactory _rules = new Src.Model.rules.RulesFactory();

        [SetUp]
        public void Init()
        {
            _snakeMock = new Mock<Src.Model.Snake>(_rules);
            _foodMock = new Mock<Src.Model.Food>(_rules);
            _sut = new GameStub(_snakeMock.Object, _foodMock.Object);

            _sut.NewGame();
        }

        [Test]
        public void AssertSnakeIsCreatedOnNewGame()
        {
            _snakeMock.Verify(s => s.NewGame(), Times.Once());
            Assert.IsNotNull(_sut.Snake);
        }

        [Test]
        public void AssertFoodIsCreatedOnNewGame()
        {
            _foodMock.Verify(s => s.NewFood(), Times.Once());
            Assert.IsNotNull(_sut.Food);
        }

        [TestCase(Src.Model.Direction.Up)]
        [TestCase(Src.Model.Direction.Down)]
        [TestCase(Src.Model.Direction.Left)]
        [TestCase(Src.Model.Direction.Right)]
        public void AssertSnakeDirectionIsSet(Src.Model.Direction dir)
        {
            _sut.SetDirection(dir);
            _snakeMock.Verify(s => s.UpdatePosition(), Times.Once());
        }

        [Test]
        public void AssertSnakeGrowsWhenFed(Src.Model.Direction dir)
        {
            SnakeStub snakeStub = new SnakeStub(_rules);
            int expected = snakeStub.Body.Count + 1;
            FeedSnakeStub(snakeStub);
            int result = _sut.Snake.Body.Count;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AssertFoodRespawnsWhenEaten(Src.Model.Direction dir)
        {
            _sut = new Src.Model.Game();
            int expectedX = _sut.Food.FoodPosition.XCoordinate;
            int expectedY = _sut.Food.FoodPosition.YCoordinate;
            FeedSnakeStub(new SnakeStub(_rules));

            int resultX = _sut.Food.FoodPosition.XCoordinate;
            int resultY = _sut.Food.FoodPosition.YCoordinate;

            Assert.AreNotEqual(expectedX, resultX);
            Assert.AreNotEqual(expectedY, resultY);
        }

        private void FeedSnakeStub(SnakeStub snakeStub)
        {
            _sut = new GameStubSnakeInject(snakeStub);
            snakeStub.SetHead(_sut.Food.FoodPosition.XCoordinate, _sut.Food.FoodPosition.YCoordinate);
            _sut.FeedSnake();
        }

        [Test]
        public void AssertSnakeReturnsDeadOrNot(Src.Model.Direction dir)
        {
            _sut.IsGameOver();
            _snakeMock.Verify(s => s.Dead(), Times.Once());
        }
    }

    class GameStub : Src.Model.Game
    {
        public GameStub(Src.Model.Snake snake, Src.Model.Food food)
        {
            Snake = snake;
            Food = food;
        }
    }

    class GameStubSnakeInject : Src.Model.Game
    {
        public GameStubSnakeInject(Src.Model.Snake snake)
        {
            Snake = snake;
        }
    }
}

