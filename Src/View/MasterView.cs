
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
            for (int columnIndex = 0; columnIndex < lim; columnIndex++)
            {
                Console.SetCursorPosition(columnIndex, 0);
                System.Console.Write("#");
            }
        }
        public void WriteSides(int lim)
        {
            for (int rowIndex = 1; rowIndex < lim - 1; rowIndex++)
            {
                Console.SetCursorPosition(0, rowIndex);
                Console.Out.Write("#");

                Console.SetCursorPosition(lim - 1, rowIndex);
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