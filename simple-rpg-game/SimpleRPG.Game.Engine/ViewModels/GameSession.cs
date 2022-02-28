using SimpleRPG.Game.Engine.Factories;
using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels
{
    public class GameSession : IGameSession
    {
        public Player CurrentPlayer { get; private set; }

        public World CurrentWorld { get; set; }
        public Location CurrentLocation { get; private set; }

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "CHARNAME",
                CharacterClass = "Mook",
                HitPoints = 10,
                Gold = 1000,
                ExperiencePoints = 0,
                Level = 1
            };

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.GetHomeLocation();
        }

        public void AddXP()
        {
            CurrentPlayer.ExperiencePoints += 10;
        }
    }
}
