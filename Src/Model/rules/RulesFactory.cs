
using System;

namespace Snake_Game.Src.Model.rules
{
    class RulesFactory : IRulesFactory
    {
        public virtual ISnakeRules GetGameRules()
        {
            return new SnakeRules();
        }

        public virtual ISnakeGameStrategy GetSnakeGameStrategy()
        {
            return new SnakeGameStrategy();
        }
    }
}