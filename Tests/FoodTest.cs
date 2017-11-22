using System;
using NUnit.Framework;

namespace Snake_Game.Tests
{
    [TestFixture]
    [Category("Model")]
    class FoodTest
    {
        [TestCase(20, 20)]
        public void AssertFoodHasPosition(int WidthLimit, int HeightLimit)
        {
            Src.Model.Food f = new Src.Model.Food(WidthLimit, HeightLimit);

            Assert.IsInstanceOf<Src.Model.Position>(f.FoodPosition);
        }

        [TestCase(-20, 20)]
        public void AssertFoodThrowsException(int WidthLimit, int HeightLimit)
        {
            Assert.That(() => new Src.Model.Food(WidthLimit, HeightLimit), 
            Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}