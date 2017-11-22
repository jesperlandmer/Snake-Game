
using System;

namespace Snake_Game.Src.Model
{
    public class Food
    {
        public Position FoodPosition { get; private set; }
        public Food(int WidthLimit, int HeightLimit)
        {
            FoodPosition = GenerateRandomPosition(WidthLimit, HeightLimit);
        }

        private Position GenerateRandomPosition(int x, int y)
        {
            Random random = new Random();
            if (x < 1 || y < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Position(random.Next(1, x), random.Next(1, y));
        }
    }
}