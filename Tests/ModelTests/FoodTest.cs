using System;
using NUnit.Framework;

namespace Snake_Game.Tests.ModelTests
{
    [TestFixture]
    [Category("Model")]
    class FoodTest : TestBase<Src.Model.Food>
    {
        [SetUp]
        public override void Init()
        {
            var RulesFactory = new Src.Model.rules.RulesFactory();
            _sut = new Src.Model.Food(RulesFactory);
        }

        [TestCase(20)]
        public void AssertFoodSetsPosition(int maxLimit)
        {
            _sut.NewFood();
            Assert.IsInstanceOf<Src.Model.Position>(_sut.FoodPosition);
            Assert.IsNotNull(_sut.FoodPosition.XCoordinate);
            Assert.IsNotNull(_sut.FoodPosition.YCoordinate);
        }

        [Test]
        public void AssertFoodThrowsException()
        {
            _sut = new Src.Model.Food(new RulesFactoryStub());

            Assert.That(() => _sut.NewFood(),
            Throws.TypeOf<ArgumentOutOfRangeException>());
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
            public new int GetArenaLimit()
            {
                return -20;
            }
        }
    }
}