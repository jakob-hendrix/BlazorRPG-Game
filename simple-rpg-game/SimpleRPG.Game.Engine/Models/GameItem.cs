namespace SimpleRPG.Game.Engine.Models
{
    // The concept of an item
    public class GameItem
    {
        public static readonly GameItem Empty = new GameItem();

        public GameItem()
        {

        }

        public GameItem(int itemTypeID, string name, int price, bool isUnique = false)
        {
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
            IsUnique = isUnique;
        }

        public int ItemTypeID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsUnique { get; set; }

        // Create a deep copy of the item
        public virtual GameItem Clone() => new GameItem(ItemTypeID, Name, Price, IsUnique);   
    }
}
