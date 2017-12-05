
using System;
using System.Collections.Generic;

namespace Snake_Game.Src.Model.rules
{
    public interface ISnakeGameStrategy
    {
        List<Position> GetInitSnake();
    }
}