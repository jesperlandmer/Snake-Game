
namespace Snake_Game.Src.Model.rules
{
    interface ISnakeRules
    {
        int GetSpeedLimit();
        int GetSpeedIncrease();
        int GetArenaLimit();
        bool IsGameOver(Snake m_snake);
    }
}