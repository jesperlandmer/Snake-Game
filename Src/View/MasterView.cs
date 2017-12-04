
using System;

namespace Snake_Game.Src.View
{
    class MasterView
    {
        private IConsoleView _console;

        public MasterView()
        {
            _console = new ConsoleView();
        }
        public MasterView(IConsoleView v_console)
        {
            _console = v_console;
        }

        public ConsoleKey GetChosenDirection()
        {
            return _console.GetPressedArrow();
        }

        public void WriteSnake(Model.Snake m_snake)
        {
            Console.Clear();
            foreach (Model.Position p in m_snake.Body)
            {
                Console.SetCursorPosition(p.XCoordinate, p.YCoordinate);

                if (p != m_snake.GetHead())
                {
                    System.Console.Write("*");
                }
                else
                {
                    System.Console.Write("⊙");
                }
            }
        }
        public void WriteArena(int m_limit)
        {
            WriteTop(m_limit);
            WriteSides(m_limit);
            WriteBottom(m_limit);
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
                System.Console.Write("#");

                Console.SetCursorPosition(lim - 1, rowIndex);
                System.Console.Write("#");
            }
        }
        public void WriteBottom(int lim)
        {
            Console.SetCursorPosition(0, lim - 1);
            for (int columnIndex = 0; columnIndex < lim; columnIndex++)
            {
                Console.Out.Write("#");
            }
        }
        public void WriteFood(Model.Food m_food)
        {
            Model.Position p = m_food.FoodPosition;

            Console.SetCursorPosition(p.XCoordinate, p.YCoordinate);
            System.Console.Write("◕");
        }
        public void WriteStats(int m_score)
        {
            System.Console.Write("\n");
            System.Console.Write("Score: {0} p", m_score);
        }
        public void WriteGameOver()
        {
            System.Console.Write("\n");
            System.Console.Write("Game Over");
        }
    }
}