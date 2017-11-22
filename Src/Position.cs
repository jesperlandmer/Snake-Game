
using System;

namespace Snake_Game.Src
{
    public class Position
    {
        private int _x;
        private int _y;
        public Position(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int XCoordinate
        {
            get
            {
                return _x;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _x = value;
            }
        }
        public int YCoordinate
        {
            get
            {
                return _y;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _y = value;
            }
        }
    }
}