using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels
{
    public interface IGameSession
    {
        Player CurrentPlayer { get; }
        Location CurrentLocation { get; }
        Monster? CurrentMonster { get; }
        bool HasMonster { get; }
        MovementUnit Movement { get; }
        void OnLocationChanged(Location location);
    }
}
