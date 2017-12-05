
using System;

namespace Snake_Game.Src.Model.rules
{
    public interface IRulesFactory
    {
        ISnakeRules GetGameRules();
        ISnakeGameStrategy GetSnakeGameStrategy();
    }
}