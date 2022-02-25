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
            var sut = new GameSession();

            Assert.Equal("Anomen",sut.CurrentPlayer.Name);
            Assert.Equal(1000,sut.CurrentPlayer.Gold);
        }
    }
}
