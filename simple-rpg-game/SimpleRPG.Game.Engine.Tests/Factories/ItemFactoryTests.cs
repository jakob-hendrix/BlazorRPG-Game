using SimpleRPG.Game.Engine.Factories;
using System;
using Xunit;

namespace SimpleRPG.Game.Engine.Tests.Factories
{
    public class ItemFactoryTests
    {
        [Fact]
        public void CreateGameItem_WihtValidItemTypeID()
        {
            // arrange

            // act
            var item = ItemFactory.CreateGameItem(1001);

            // assert
            Assert.NotNull(item);
            Assert.Equal(1001, item.ItemTypeID);
            Assert.Equal("Pointy Stick", item.Name);
            Assert.Equal(1, item.Price);
        }

        [Fact]
        public void CreateGameItem_WithInvalidItemTypeId()
        {
            // arrange

            // act
            Assert.Throws<ArgumentOutOfRangeException>(() => ItemFactory.CreateGameItem(1));

            // assert
        }
    }
}
