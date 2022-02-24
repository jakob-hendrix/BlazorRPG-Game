using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using SimpleRPG.Game.Shared;
using SimpleRPG.Game.Tests.Mocks;
using Xunit;

namespace SimpleRPG.Game.Tests
{
    public class NavMenuTests
    {
        // initial render test
        [Fact]
        public void SimpleRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NavigationManager>(new MockNavigationManager());

            // act
            var cut = ctx.RenderComponent<NavMenu>();

            // assert
            var expected = 
                @"<span class=""oi oi-home"" aria-hidden=""true""></span> Home";
            Assert.Contains(expected, cut.Markup);

            expected = 
                @"<div class=""collapse"" blazor:onclick=""2"">";
            Assert.Contains(expected, cut.Markup);
        }

        // interactivity test
        [Fact]
        public void ToggleNavMenu()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NavigationManager>(new MockNavigationManager());

            // act
            var cut = ctx.RenderComponent<NavMenu>();
            cut.Find(".navbar-toggler").Click();

            // assert
            var expected = @"<div class="""" blazor:onclick=""2"">";
            Assert.Contains(expected, cut.Markup);
        }
    }
}
