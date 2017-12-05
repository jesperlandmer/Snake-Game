
using System;

namespace Snake_Game.Src.View
{
    public interface IView
    {
        ConsoleKey GetChosenDirection();
        void WriteSnake(Model.Snake m_snake);
        void WriteArena(int m_limit);
        void WriteFood(Model.Food m_food);
        void WriteStats(int m_score);
        void WriteGameOver();
    }
}