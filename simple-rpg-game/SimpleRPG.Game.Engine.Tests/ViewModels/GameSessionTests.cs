using System.Threading.Tasks;
using SimpleRPG.Game.Engine.Models;
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
            Assert.Equal(10, vm.CurrentPlayer.CurrentHitPoints);
            Assert.Equal(1000, vm.CurrentPlayer.Gold);
            Assert.Equal(0, vm.CurrentPlayer.ExperiencePoints);
            Assert.Equal(1, vm.CurrentPlayer.Level);

            Assert.NotNull(vm.CurrentLocation);
            Assert.Equal("Home", vm.CurrentLocation.Name);
            Assert.Equal(0, vm.CurrentLocation.XCoordinate);
            Assert.Equal(-1, vm.CurrentLocation.YCoordinate);
            Assert.Equal("This is your home.", vm.CurrentLocation.Description);
            Assert.Equal("/images/locations/Home.png", vm.CurrentLocation.ImageName);
        }

        [Fact]
        public void GetMonsterAtLocation()
        {
            // arrange
            var vm = new GameSession();
            var loc = new Location(10, 10, "MockLoc", "MockDesc", "test.png");
            loc.AddMonsterEncounter(1, 100);

            // act
            vm.OnLocationChanged(loc);

            // assert
            Assert.True(vm.HasMonster);
            Assert.NotNull(vm.CurrentMonster);
        }
    }
}
