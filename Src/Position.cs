
using System;

namespace Snake_Game.Src
{
    public class Position
    {
        private int _x;
        private int _y;
        public Position(int x, int y)
        {

        }

        public int XCoordinate
        {
            get
            {
                return _x;
            }
            set
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
    }
}