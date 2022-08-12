using SimpleRPG.Game.Engine.Factories;
using SimpleRPG.Game.Engine.Models;
using System;

namespace SimpleRPG.Game.Engine.ViewModels
{
    public class GameSession : IGameSession
    {
        private readonly World currentWorld;

        public Player CurrentPlayer { get; private set; }

        public Location CurrentLocation { get; private set; }
        public Monster? CurrentMonster { get; private set;  }
        public bool HasMonster => CurrentMonster != null;

        public MovementUnit Movement { get; private set; }

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "CHARNAME",
                CharacterClass = "Mook",
                CurrentHitPoints = 10,
                Gold = 1000,
                ExperiencePoints = 0,
                Level = 1
            };

            // init game world
            currentWorld = WorldFactory.CreateWorld();

            Movement = new MovementUnit(currentWorld);
            CurrentLocation = Movement.CurrentLocation;

            CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItem(1001));
            CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItem(1001));
          }

        public void OnLocationChanged(Location location)
        {
            CurrentLocation = location;
            GetMonsterAtCurrentLocation();
        }

        private void GetMonsterAtCurrentLocation()
        {
            CurrentMonster = CurrentLocation.HasMonster() ? CurrentLocation.GetMonster() : null;
        }
    }
}
