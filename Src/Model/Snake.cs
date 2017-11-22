
using System;
using System.Collections.Generic;

namespace Snake_Game.Src.Model
{
    public class Snake
    {
        public List<Position> Body { get; private set; }
        public object Direction { get; set; }
        public Snake()
        {

        }
        public void SetDirection()
        {
            throw new NotImplementedException();
        }
        public void UpdatePosition()
        {
            throw new NotImplementedException();
        }
        public Position GetHead()
        {
            throw new NotImplementedException();
        }
        public void Grow()
        {
            throw new NotImplementedException();
        }
        public void MoveTail()
        {
            throw new NotImplementedException();
        }
        public bool Dead()
        {
            throw new NotImplementedException();
        }
    }
}