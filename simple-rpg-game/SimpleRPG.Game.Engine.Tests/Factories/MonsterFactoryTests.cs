using System;
using SimpleRPG.Game.Engine.Factories;
using SimpleRPG.Game.Engine.Services;
using Xunit;

namespace SimpleRPG.Game.Engine.Tests.Factories
{
    public class MonsterFactoryTests
    {
        public MonsterFactoryTests()
        {
            DiceService.Instance.Configure(IDiceService.RollerType.Constant, constantValue: 50);
        }

        [Fact]
        public void CreateMonster_Snake()
        {
            // arrange

            // act
            var m = MonsterFactory.GetMonster(1);

            // assert
            Assert.NotNull(m);
            Assert.Equal("Snake", m.Name);
            Assert.Equal(4, m.CurrentHitPoints);
            Assert.Equal(5, m.RewardExperiencePoints);
            Assert.Equal(1, m.Gold);
            Assert.NotEmpty(m.Inventory.GroupedItems);
            Assert.Equal(1, m.Inventory.GroupedItems.Count);
        }

        [Fact]
        public void CreateMonster_Rat()
        {
            // arrange

            // act
            var m = MonsterFactory.GetMonster(2);

            // assert
            Assert.NotNull(m);
            Assert.Equal("Rat", m.Name);
            Assert.Equal(5, m.CurrentHitPoints);
            Assert.Equal(5, m.RewardExperiencePoints);
            Assert.Equal(1, m.Gold);
            Assert.NotEmpty(m.Inventory.GroupedItems);
            Assert.Equal(1, m.Inventory.GroupedItems.Count);
        }

        [Fact]
        public void CreateMonster_GiantSpider()
        {
            // arrange

            // act
            var m = MonsterFactory.GetMonster(3);

            // assert
            Assert.NotNull(m);
            Assert.Equal("Giant Spider", m.Name);
            Assert.Equal(10, m.CurrentHitPoints);
            Assert.Equal(10, m.RewardExperiencePoints);
            Assert.Equal(3, m.Gold);
            Assert.NotEmpty(m.Inventory.GroupedItems);
            Assert.Equal(1, m.Inventory.GroupedItems.Count);
        }

        [Fact]
        public void CreateMonster_InvalidId()
        {
            // arrange

            // act
            Assert.Throws<ArgumentOutOfRangeException>(() => MonsterFactory.GetMonster(101));

            // assert
        }
    }
}
