
using System;

namespace Snake_Game.Src.Model
{
    public class Food
    {
        private Random _random = new Random();
        public Position FoodPosition { get; private set; }
        public Food(int WidthLimit, int HeightLimit)
        {
            FoodPosition = GenerateRandomPosition(WidthLimit, HeightLimit);
        }

        private Position GenerateRandomPosition(int x, int y)
        {
            int minLimit = 1;
            if (x < minLimit || y < minLimit)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Position(_random.Next(minLimit, x), _random.Next(minLimit, y));
        }
    }
}