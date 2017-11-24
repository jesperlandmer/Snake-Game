
using System;

namespace Snake_Game.Src.Model.rules
{
    class RulesFactory : IRulesFactory
    {
        public ISnakeRules GetGameRules()
        {
            return new SnakeRules();
        }

        public ISnakeGameStrategy GetInitSnake()
        {
            return new SnakeGameStrategy();
        }
    }
}