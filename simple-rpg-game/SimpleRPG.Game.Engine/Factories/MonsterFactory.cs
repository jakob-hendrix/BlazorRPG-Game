using SimpleRPG.Game.Engine.Models;
using SimpleRPG.Game.Engine.Services;
using System;

namespace SimpleRPG.Game.Engine.Factories
{
    internal static class MonsterFactory
    {
        private static readonly IDiceService _service = DiceService.Instance;

        public static Monster GetMonster(int monsterId)
        {
            switch (monsterId)
            {
                case 1:
                    Monster snake = new Monster
                    {
                        Name = "Snake",
                        ImageName = "/images/monsters/snake.png",
                        CurrentHitPoints = 4,
                        MaximumHitPoints = 4,
                        RewardExperiencePoints = 5,
                        Gold = 1
                    };

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);
                    return snake;

                case 2:
                    Monster rat = new Monster
                    {
                        Name = "Rat",
                        ImageName = "/images/monsters/rat.png",
                        CurrentHitPoints = 5,
                        MaximumHitPoints = 5,
                        RewardExperiencePoints = 5,
                        Gold = 1
                    };

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);
                    return rat;

                case 3:
                    Monster giantSpider = new Monster
                    {
                        Name = "Giant Spider",
                        ImageName = "/images/monsters/giant-spider.png",
                        CurrentHitPoints = 10,
                        MaximumHitPoints = 10,
                        RewardExperiencePoints = 10,
                        Gold = 3
                    };

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 75);
                    return giantSpider;

                default:
                    throw new ArgumentOutOfRangeException(nameof(monsterId));
            }
        }

        private static void AddLootItem(Monster monster, int itemID, int chance)
        {
            if (chance < 0 || chance > 100)
                throw new ArgumentOutOfRangeException(nameof(chance));

            if (_service.Roll("1d100").Value <= chance)
            {
                monster.Inventory.AddItem(ItemFactory.CreateGameItem(itemID));
            }
        }
    }
}
