using SimpleRPG.Game.Engine.ViewModels;
using Xunit;

namespace SimpleRPG.Game.Engine.Tests.ViewModels
{
    public class GameSessionTests
    {
        [Fact]
        public void CreateSimpleGameSession()
        {
            // arrange

            // act
            var vm = new GameSession();

            // assert
            Assert.NotNull(vm);
            Assert.NotNull(vm.CurrentPlayer);
            Assert.Equal("CHARNAME", vm.CurrentPlayer.Name);
            Assert.Equal("Mook", vm.CurrentPlayer.CharacterClass);
            Assert.Equal(10, vm.CurrentPlayer.HitPoints);
            Assert.Equal(1000, vm.CurrentPlayer.Gold);
            Assert.Equal(0, vm.CurrentPlayer.ExperiencePoints);
            Assert.Equal(1, vm.CurrentPlayer.Level);

            Assert.NotNull(vm.CurrentLocation);
            Assert.Equal("Home", vm.CurrentLocation.Name);
            Assert.Equal(0, vm.CurrentLocation.XCoordinate);
            Assert.Equal(-1, vm.CurrentLocation.YCoordinate);
            Assert.Equal("This is your house.", vm.CurrentLocation.Description);
            Assert.Equal("/images/locations/home.png", vm.CurrentLocation.ImageName);
        }

        [Fact]
        public void AddXP()
        {
            var vm = new GameSession();
            vm.AddXP();

            Assert.Equal(10, vm.CurrentPlayer.ExperiencePoints);
        }
    }
}
