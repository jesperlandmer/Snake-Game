
using System;
using System.Threading.Tasks;
using System.Timers;

namespace Snake_Game.Src.Controller
{
    public class PlaySnake
    {
        private static System.Timers.Timer a_Timer;

        public bool Run(Model.Game m_game, View.IView v_view)
        {
            DoTimedEvent(m_game, v_view);
            ConsoleKey direction = v_view.GetChosenDirection();


            if (m_game.IsGameOver() == false)
            {
                switch (direction)
                {
                    case ConsoleKey.UpArrow:
                        m_game.SetDirection(Model.Direction.Up);
                        a_Timer.Enabled = false;
                        return true;
                    case ConsoleKey.DownArrow:
                        m_game.SetDirection(Model.Direction.Down);
                        a_Timer.Enabled = false;
                        return true;
                    case ConsoleKey.RightArrow:
                        m_game.SetDirection(Model.Direction.Right);
                        a_Timer.Enabled = false;
                        return true;
                    case ConsoleKey.LeftArrow:
                        m_game.SetDirection(Model.Direction.Left);
                        a_Timer.Enabled = false;
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                v_view.WriteGameOver();
                v_view.WriteStats(m_game.Score);
                return false;
            }
        }

        private void DoTimedEvent(Model.Game m_game, View.IView v_view)
        {
            a_Timer = new System.Timers.Timer(m_game.Speed);
            a_Timer.Elapsed += (source, e) => DoPlayBoard(m_game, v_view);
            a_Timer.AutoReset = true;
            a_Timer.Enabled = true;
        }

        private void DoPlayBoard(Model.Game m_game, View.IView v_view)
        {
            m_game.UpdateSnake();
            m_game.FeedSnake();

            v_view.WriteSnake(m_game.Snake);
            v_view.WriteArena(m_game.GetArenaLimits());
            v_view.WriteStats(m_game.Score);
            v_view.WriteFood(m_game.Food);
        }
    }
}