using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels
{
    public class GameSession : IGameSession
    {
        public Player CurrentPlayer { get; private set; }

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

            CurrentLocation = new Location
            {
                Name = "Home",
                XCoordinate = 0,
                YCoordinate = -1,
                Description = "This is your house.",
                ImageName = "/images/locations/home.png"
            };
        }

        public void AddXP()
        {
            CurrentPlayer.ExperiencePoints += 10;
        }
    }
}
