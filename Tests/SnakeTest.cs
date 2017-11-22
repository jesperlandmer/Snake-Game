using System;
using System.Linq;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    [TestFixture]
    [Category("Model")]
    class SnakeTest
    {
        [Test]
        public void AssertSnakeHasDirection()
        {
            Src.Model.Snake Snake = new Src.Model.Snake();

            Assert.IsInstanceOf<Src.Model.Direction>(Snake.Direction);
        }

        [Test]
        public void AssertSnakeHasBody()
        {
            Src.Model.Snake Snake = new Src.Model.Snake();

            CollectionAssert.AllItemsAreNotNull(Snake.Body);
            CollectionAssert.IsNotEmpty(Snake.Body);
        }

        [Test]
        public void AssertSnakeHeadIsHead()
        {
            Src.Model.Snake Snake = new Src.Model.Snake();
            var result = Snake.GetHead();
            var expected = Snake.Body.Last();

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void AssertSnakeMoves()
        {
            Src.Model.Snake Snake = new Src.Model.Snake();
            var result = Snake.Body.First();
            Snake.UpdatePosition();
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

            // Assert.Greater(x, y) = x is greater than y
            Assert.Greater(expected, result);
        }

        [Test]
        public void AssertSnakeDies()
        {
            // TODO: Implement snake dies test
            Assert.Pass();
        }
    }
}

