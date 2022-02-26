using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels
{
    public interface IGameSession
    {
        Player CurrentPlayer { get;  }
        void AddXP();
    }
}
