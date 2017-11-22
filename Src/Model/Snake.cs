
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Game.Src.Model
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    public class Snake
    {
        public List<Position> Body { get; private set; }
        public Direction Direction { get; set; }
        public Snake()
        {
            Body = new List<Position>();
            int initLength = 5;
            int initX = 10;
            int initY = 10;

            for (int i = 0; i < initLength; i++)
            {
                Body.Add(new Position(initX, initY));
                initX -= 1;
            }
        }
        public void SetDirection(Direction m_dir)
        {
            Direction = m_dir;
        }
        public void UpdatePosition()
        {
            MoveLastTail();

            switch (Direction)
            {
                case Direction.Up:
                    AddTail(0, -1);
                    break;
                case Direction.Down:
                    AddTail(0, 1);
                    break;
                case Direction.Right:
                    AddTail(1, 0);
                    break;
                case Direction.Left:
                    AddTail(-1, 0);
                    break;
            }
        }
        private void AddTail(int x, int y)
        {
            int newX = GetHead().XCoordinate + x;
            int newY = GetHead().YCoordinate + y;

            Body.Add(new Position(newX, newY));
        }
        public Position GetHead()
        {
            return Body.Last();
        }
        public void Grow()
        {
            switch (Direction)
            {
                case Direction.Up:
                    AddTail(0, -1);
                    break;
                case Direction.Down:
                    AddTail(0, 1);
                    break;
                case Direction.Right:
                    AddTail(1, 0);
                    break;
                case Direction.Left:
                    AddTail(-1, 0);
                    break;
            }
        }
        public void MoveLastTail()
        {
            Body.Remove(Body.First());
        }
        public bool Dead()
        {
            throw new NotImplementedException();
        }
    }
}