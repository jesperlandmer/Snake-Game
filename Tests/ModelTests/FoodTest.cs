using System;
using NUnit.Framework;

namespace Snake_Game.Tests.ModelTests
{
    [TestFixture]
    [Category("Model")]
    class FoodTest
    {
        private FoodStub _sut;

        [SetUp]
        public void Init()
        {
            _sut = new FoodStub();
        }

        [TestCase(20)]
        public void AssertFoodSetsPosition(int maxLimit)
        {
            _sut.NewFood(maxLimit);
            Assert.IsInstanceOf<Src.Model.Position>(_sut.FoodPosition);
        }

        [TestCase(-20)]
        public void AssertFoodThrowsException(int maxLimit)
        {
            Assert.That(() => _sut.NewFood(maxLimit),
            Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }

    class FoodStub : Src.Model.Food
    {
        public FoodStub() : base(new Src.Model.rules.RulesFactory())
        {
        }
        public void NewFood(int maxLimit)
        {
            FoodPosition = GenerateRandomPosition(maxLimit);
        }
    }
}