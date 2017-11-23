
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Game.Src.Model.rules
{
    public class SnakeGameStrategy
    {
        private int _initLength = 5;
        private int _initXCoordinate = 10;
        private int _initYCoordinate = 10;

        public List<Position> GetInitSnake()
        {
            List<Position> initBody = new List<Position>();

            for (int i = 0; i < _initLength; i++)
            {
                initBody.Add(new Position(_initXCoordinate, _initYCoordinate));
                _initXCoordinate -= 1;
            }

            return initBody;
        }
    }
}