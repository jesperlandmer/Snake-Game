
namespace Snake_Game.Src.Model.rules
{
    public interface ISnakeRules
    {
        int GetSpeedLimit();
        int GetSpeedIncrease();
        int GetArenaLimit();
        bool IsGameOver(Snake m_snake);
    }
}