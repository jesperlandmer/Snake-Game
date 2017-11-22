using System;
using System.Linq;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    [TestFixture]
    [Category("Model")]
    class SnakeTest
    {
        private Src.Model.Snake _snake;

        [SetUp]
        public void SetUp()
        {
            _snake = new Src.Model.Snake();
        }

        [Test]
        public void AssertSnakeHasDirection()
        {
            Assert.IsInstanceOf<object>(_snake.Direction);
        }

        [Test]
        public void AssertSnakeHasBody()
        {
            CollectionAssert.AllItemsAreNotNull(_snake.Body);
            CollectionAssert.IsNotEmpty(_snake.Body);
        }

        [Test]
        public void AssertSnakeHeadIsHead()
        {
            var result = _snake.GetHead();
            var expected = _snake.Body.Last();

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void AssertSnakeMoves()
        {
            Src.Model.Snake Snake = new Src.Model.Snake();
            var result = Snake.Body.First();
            Snake.UpdatePosition();
            Snake.MoveTail();
            var expected = Snake.Body.First();

            Assert.AreNotEqual(result, expected);
        }

        [Test]
        public void AssertSnakeGrows()
        {
            Src.Model.Snake Snake = new Src.Model.Snake();
            var result = Snake.Body.Count;
            Snake.Grow();
            var expected = Snake.Body.Count;

            Assert.Greater(result, expected);
        }

        [Test]
        public void AssertSnakeDies()
        {
            Assert.Fail();
        }
    }
}

