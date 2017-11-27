
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
        public Game()
        {
            Snake = new Snake(_rules);
            Food = new Food(_rules);
        }

        public virtual void NewGame()
        {
            Snake.NewGame();
            Food.NewFood();
            Score = 0;
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
                Food.NewFood();
                Snake.Grow();
                Score++;
            }
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