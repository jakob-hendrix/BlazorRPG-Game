using SimpleRPG.Game.Engine.Models;
using Xunit;

namespace SimpleRPG.Game.Engine.Tests.Models
{
    public class PlayerTests
    {
        [Fact]
        public void CreateSimplePlayer()
        {
            var p = new Player
            {
                Name = "Test",
                Level = 1,
                CurrentHitPoints = 10,
            };

            Assert.NotNull(p);
            Assert.Equal("Test", p.Name);
            Assert.Equal(string.Empty, p.CharacterClass);
            Assert.Equal(1, p.Level);
            Assert.Equal(10, p.CurrentHitPoints);  
            Assert.Equal(0, p.ExperiencePoints);
            Assert.Equal(0, p.Gold);
        }
    }
}
