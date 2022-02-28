using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SimpleRPG.Game.Engine.Models;
using SimpleRPG.Game.Engine.ViewModels;
using SimpleRPG.Game.Pages;
using SimpleRPG.Game.Tests.Mocks;
using Xunit;

namespace SimpleRPG.Game.Tests.Pages
{
    public class MainScreenTests
    {
        private readonly Mock<IGameSession> session = new Mock<IGameSession>();

        public MainScreenTests()
        {
            session.SetupGet(p => p.CurrentPlayer)
                   .Returns(new Player
                    {
                       Name = "TestPlayer",
                       CharacterClass = "TestClass",
                       Level = 1,
                       HitPoints = 8,
                   });
        }
    }
}
