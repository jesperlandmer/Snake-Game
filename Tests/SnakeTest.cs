using System;
using System.Linq;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    [TestFixture]
    [Category("Model")]
    class SnakeTest
    {
        private Src.Model.Snake _sut;
        [SetUp] public void Init()
        {
            _sut = new Src.Model.Snake();
        }

        [Test]
        public void AssertSnakeHasDirection()
        {
            Assert.IsInstanceOf<Src.Model.Direction>(_sut.Direction);
        }

        [Test]
        public void AssertSnakeHasBody()
        {
            CollectionAssert.AllItemsAreNotNull(_sut.Body);
            CollectionAssert.IsNotEmpty(_sut.Body);
        }

        [Test]
        public void AssertSnakeHeadIsHead()
        {
            var result = _sut.GetHead();
            var expected = _sut.Body.Last();

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void AssertSnakeMoves()
        {
            var result = _sut.Body.First();
            _sut.UpdatePosition();
            var expected = _sut.Body.First();

            Assert.AreNotEqual(result, expected);
        }

        [Test]
        public void AssertSnakeGrows()
        {
            var result = _sut.Body.Count;
            _sut.Grow();
            var expected = _sut.Body.Count;

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

