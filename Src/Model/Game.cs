
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Game.Src.Model
{
    class Game
    {
        private rules.IRulesFactory _rules = new rules.RulesFactory();
        public Snake Snake { get; protected set; }
        public Food Food { get; protected set; }
        public int Score { get; protected set; }
        public int Speed { get; protected set; }

        public Game()
        {
            Snake = new Snake(_rules);
            Food = new Food(_rules);
        }

        public void NewGame()
        {
            Snake.NewGame();
            Food.NewFood();
            Score = 0;
        }
        public int GetGameSpeed()
        {
            Speed = _rules.GetGameRules().GetArenaLimit();
            return Speed;
        }
        public int GetArenaLimits()
        {
            return _rules.GetGameRules().GetArenaLimit();
        }
        public void SetDirection(Direction m_dir)
        {
            Snake.UpdateDirection(m_dir);
        }
        public void UpdateSnake()
        {
            Snake.UpdatePosition();
        }
        public void FeedSnake()
        {
            if (IsSnakeFed())
            {
                Snake.Grow();
                Food.NewFood();
                IncreaseSpeed();
                Score++;
            }
        }
        private void IncreaseSpeed()
        {
            throw new NotImplementedException();
        }
        private bool IsSnakeFed()
        {
            return Snake.GetHead().IsPositionEqualTo(Food.FoodPosition);
        }

        public bool IsGameOver()
        {
            return Snake.Dead();
        }
    }
}