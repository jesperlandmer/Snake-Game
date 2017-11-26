
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Game.Src.Model
{
    class Game
    {
        public Snake Snake { get; protected set; }
        public Food Food { get; protected set; }
        public int Score => 0;
        public Game()
        {
        }

        public void NewGame()
        {
            throw new NotImplementedException();
        }
        public void SetDirection(Direction dir)
        {
            throw new NotImplementedException();
        }
        public void UpdateSnake()
        {
            throw new NotImplementedException();
        }
        public void FeedSnake()
        {
            throw new NotImplementedException();
        }
        public void UpdateFood()
        {
            throw new NotImplementedException();
        }
        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}