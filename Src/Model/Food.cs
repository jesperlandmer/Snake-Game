
using System;

namespace Snake_Game.Src.Model
{
    class Food
    {
        private rules.ISnakeRules _gameRules;
        private Random _random = new Random();
        public Position FoodPosition { get; protected set; }
        public Food(rules.IRulesFactory rules)
        {
            _gameRules = rules.GetGameRules();
        }

        public virtual void NewFood()
        {
            FoodPosition = GenerateRandomPosition(_gameRules.GetArenaLimit());
        }

        protected Position GenerateRandomPosition(int maxLimit)
        {
            int minLimit = 1;
            if (maxLimit < minLimit)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            return new Position(_random.Next(minLimit, maxLimit), _random.Next(minLimit, maxLimit));
        }
    }
}