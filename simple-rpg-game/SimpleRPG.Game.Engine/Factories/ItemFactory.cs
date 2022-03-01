using SimpleRPG.Game.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG.Game.Engine.Factories
{
    internal static class ItemFactory
    {
        private static List<GameItem> _standardGameItems = new List<GameItem>
        {
            new Weapon(1001, "Pointy Stick", 1, 1, 2),
            new Weapon(1002, "Rusty Sword", 5, 1, 3)
        };

        /// <summary>
        /// Return a new instance of the item of the given ID
        /// </summary>
        /// <param name="itemTypeID"></param>
        /// <returns></returns>
        public static GameItem? CreateGameItem(int itemTypeID)
        {
            var standardItem = _standardGameItems.FirstOrDefault(p => p.ItemTypeID == itemTypeID);
            return standardItem?.Clone();
        }
    }
}
