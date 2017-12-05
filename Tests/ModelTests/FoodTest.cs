using System;
using Xunit;

namespace Snake_Game.Tests.ModelTests
{
        public class FoodTest : TestBase<Src.Model.Food>
    {
        public FoodTest()
        {
            var RulesFactory = new Src.Model.rules.RulesFactory();
            _sut = new Src.Model.Food(RulesFactory);
        }

        [Theory]
        [InlineData(20)]
        public void AssertFoodSetsPosition(int maxLimit)
        {
            _sut.NewFood();
            Assert.IsType<Src.Model.Position>(_sut.FoodPosition);
            Assert.NotNull(_sut.FoodPosition.XCoordinate);
            Assert.NotNull(_sut.FoodPosition.YCoordinate);
        }

        [Fact]
        public void AssertFoodThrowsException()
        {
            _sut = new Src.Model.Food(new RulesFactoryStub());
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.NewFood());
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