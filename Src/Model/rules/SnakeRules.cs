
using System;

namespace Snake_Game.Src.Model.rules
{
    class SnakeRules : ISnakeRules
    {
        private int _squareArenaLimit = 30;

        public int GetArenaLimit()
        {
            return _squareArenaLimit;
        }
        public bool IsGameOver(Snake m_snake)
        {
            if (HitHeightLimits(m_snake.GetHead()) || HitLengthLimits(m_snake.GetHead()))
            {
                return true;
            }
            return false;
        }

        private bool HitHeightLimits(Position p)
        {
            return (p.YCoordinate <= 0 || p.YCoordinate >= _squareArenaLimit);
        }
        private bool HitLengthLimits(Position p)
        {
            return (p.XCoordinate <= 0 || p.XCoordinate >= _squareArenaLimit);
        }
    }
}