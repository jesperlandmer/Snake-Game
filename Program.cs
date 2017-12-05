using System;

namespace Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Src.View.IView v = new Src.View.MasterView();
            Src.Model.Game g = new Src.Model.Game();
            g.NewGame();

            var Master = new Src.Controller.PlaySnake();
            while (Master.Run(g, v))
                ;
        }
    }
}
