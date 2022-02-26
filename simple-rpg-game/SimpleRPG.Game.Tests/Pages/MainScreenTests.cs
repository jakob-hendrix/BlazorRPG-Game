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

        [Fact]
        public void SimpleRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddBlazoriseServices();
            ctx.Services.AddSingleton(session.Object);

            // act
            var cut = ctx.RenderComponent<MainScreen>();

            // assert
            var expected = @"<th scope=""col"" class="""" style="""" blazor:onclick=""2"" rowspan=""2"">";
            Assert.Contains(expected, cut.Markup);
            Assert.Contains("Player Data", cut.Markup);
            Assert.Contains("TestPlayer", cut.Markup);
            Assert.Contains("TestClass", cut.Markup);
        }
    }
}
