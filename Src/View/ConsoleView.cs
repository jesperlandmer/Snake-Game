
using System;

namespace Snake_Game.Src.View
{
    class ConsoleView : IConsoleView
    {
        public ConsoleKey GetPressedArrow()
        {
            return Console.ReadKey(false).Key;
        }
    }
}