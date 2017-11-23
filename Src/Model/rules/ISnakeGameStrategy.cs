
using System;
using System.Collections.Generic;

namespace Snake_Game.Src.Model.rules
{
    interface ISnakeGameStrategy
    {
        List<Position> GetInitSnake();
    }
}