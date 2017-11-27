
using System;

namespace Snake_Game.Src.Model
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

        public bool IsPositionEqualTo(Position Pos)
        {
            if (this.XCoordinate == Pos.XCoordinate &&
                this.YCoordinate == Pos.YCoordinate)
            {
                return true;
            }
            return false;
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
                    throw new ArgumentOutOfRangeException(nameof(value));
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
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _y = value;
            }
        }
    }
}