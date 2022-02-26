using SimpleRPG.Game.Engine.Models;
using SimpleRPG.Game.Engine.ViewModels;

namespace SimpleRPG.Game.Tests.Mocks
{
    public class MockGameSession : GameSession
    {
        public MockGameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "TestPlayer",
                CharacterClass = "TestClass",
                Level = 1,
                HitPoints = 8,
            };
        }
    }
}