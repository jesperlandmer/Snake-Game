
using System;

namespace Snake_Game.Src.Model.rules
{
    public class SnakeRules : ISnakeRules
    {
        private int _gameSpeedLimit = 250;
        private int _gameSpeedIncrease = 10;
        private int _squareArenaLimit = 30;

        public int GetSpeedLimit()
        {
            return _gameSpeedLimit;
        }
        public int GetSpeedIncrease()
        {
            return _gameSpeedIncrease;
        }
        public int GetArenaLimit()
        {
            return _squareArenaLimit;
        }

        public bool IsGameOver(Snake m_snake)
        {
            if (HasHitArenaLimits(m_snake.GetHead()))
            {
                return true;
            }
            return false;
        }
        private bool HasHitArenaLimits(Position p)
        {
            if (p.YCoordinate <= 0 || p.YCoordinate >= _squareArenaLimit ||
                p.XCoordinate <= 0 || p.XCoordinate >= _squareArenaLimit)
            {
                return true;
            }
            return false;
        }
    }
}