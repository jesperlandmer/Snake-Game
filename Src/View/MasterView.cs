
using System;

namespace Snake_Game.Src.View
{
    class MasterView
    {
        public ConsoleKey GetChosenDirection(IConsoleView v_console)
        {
            return v_console.GetPressedArrow();
        }

        public void WriteArena(int m_limit)
        {
            WriteTop(m_limit);
        }
        public void WriteTop(int lim)
        {
            for (int x = 0; x < lim; x++)
            {
                Console.SetCursorPosition(x, 0);
                System.Console.Write("#");
            }
        }
        public void WriteSides(int lim)
        {
            for (int y = 1; y < lim - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Out.Write("#");

                Console.SetCursorPosition(lim - 1, y);
                Console.Out.Write("#");
            }
        }

        public void WriteSnake(Model.Snake m_snake)
        {
            foreach (Model.Position p in m_snake.Body)
            {
                Console.SetCursorPosition(p.XCoordinate, p.YCoordinate);

                if (p != m_snake.GetHead())
                {
                    Console.Out.Write("*");
                }
                else
                {
                    Console.Out.Write("⊙");
                }
            }
        }
        public void WriteFood(Model.Food m_food)
        {
            throw new NotImplementedException();
        }
        public void WriteGameOver(int m_score)
        {
            throw new NotImplementedException();
        }
    }
}