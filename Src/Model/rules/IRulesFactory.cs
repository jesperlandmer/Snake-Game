
using System;

namespace Snake_Game.Src.Model.rules
{
    interface IRulesFactory
    {
        ISnakeRules GetGameRules();
        ISnakeGameStrategy GetInitSnake();
    }
}