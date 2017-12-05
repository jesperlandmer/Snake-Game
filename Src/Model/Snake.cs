
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
        protected rules.ISnakeGameStrategy _initRules;
        protected rules.ISnakeRules _snakeRules;
        public List<Position> Body { get; protected set; }
        public Direction Direction { get; private set; }
        public Snake(rules.IRulesFactory r_rules)
        {
            _initRules = r_rules.GetSnakeGameStrategy();
            _snakeRules = r_rules.GetGameRules();
        }

        public void NewGame()
        {
            Body = _initRules.GetInitSnake();
        }
        public Position GetHead()
        {
            return Body.Last();
        }
        public void UpdateDirection(Direction m_dir)
        {
            Direction = m_dir;
        }
        public void UpdatePosition()
        {
            MoveLastTail();
            SetNewPosition();
        }
        public void Grow()
        {
            SetNewPosition();
        }
        private void SetNewPosition()
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
        private void AddTail(int x, int y)
        {
            int newX = GetHead().XCoordinate + x;
            int newY = GetHead().YCoordinate + y;

            Body.Add(new Position(newX, newY));
        }
        public void MoveLastTail()
        {
            Body.Remove(Body.First());
        }
        public bool Dead()
        {
            return _snakeRules.IsGameOver(this);
        }
    }
}