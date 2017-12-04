
namespace Snake_Game.Src.Model.rules
{
    interface ISnakeRules
    {
        int GetSpeedLimit();
        int GetArenaLimit();
        bool IsGameOver(Snake m_snake);
    }
}