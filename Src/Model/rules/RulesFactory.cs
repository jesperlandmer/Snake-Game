
using System;

namespace Snake_Game.Src.Model.rules
{
    class RulesFactory
    {
        public ISnakeRules GetGameRules()
        {
            throw new NotImplementedException();
        }

        public ISnakeGameStrategy GetInitSnake()
        {
            return new SnakeGameStrategy();
        }
    }
}