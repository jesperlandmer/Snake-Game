
using System;

namespace Snake_Game.Src.View
{
    public class ConsoleView : IConsoleView
    {
        public ConsoleKey GetPressedArrow()
        {
            return Console.ReadKey(false).Key;
        }
    }
}