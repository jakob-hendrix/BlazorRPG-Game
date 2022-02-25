using SimpleRPG.Game.Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.Equal("Anomen", vm.CurrentPlayer.Name);
            Assert.Equal("Paladin", vm.CurrentPlayer.CharacterClass);
            Assert.Equal(10, vm.CurrentPlayer.HitPoints);
            Assert.Equal(1000, vm.CurrentPlayer.Gold);
            Assert.Equal(0, vm.CurrentPlayer.ExperiencePoints);
            Assert.Equal(1, vm.CurrentPlayer.Level);
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
