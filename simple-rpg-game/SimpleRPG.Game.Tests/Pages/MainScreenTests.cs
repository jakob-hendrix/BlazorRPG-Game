using Bunit;
using Microsoft.Extensions.DependencyInjection;
using SimpleRPG.Game.Engine.ViewModels;
using SimpleRPG.Game.Pages;
using SimpleRPG.Game.Tests.Mocks;
using Xunit;

namespace SimpleRPG.Game.Tests.Pages
{
    public class MainScreenTests
    {
        private readonly GameSession session = new MockGameSession();

        [Fact]
        public void SimpleRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddBlazoriseServices();
            ctx.Services.AddSingleton<GameSession>(session);

            // act
            var cut = ctx.RenderComponent<MainScreen>();

            // assert
            var expected = @"<th scope=""col"" class="""" style="""" blazor:onclick=""2"" rowspan=""2"">";
            Assert.Contains(expected, cut.Markup);
            Assert.Contains("Player Data", cut.Markup);
            Assert.Contains("Anomen", cut.Markup);
            Assert.Contains("Paladin", cut.Markup);
        }
    }
}
