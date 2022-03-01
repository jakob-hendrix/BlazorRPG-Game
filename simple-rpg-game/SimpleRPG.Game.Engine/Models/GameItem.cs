namespace SimpleRPG.Game.Engine.Models
{
    // The concept of an item
    public class GameItem
    {
        public GameItem(int itemTypeID, string name, int price)
        {
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
        }

        public int ItemTypeID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }

        // Create a deep copy of the item
        public virtual GameItem Clone() => new GameItem(ItemTypeID, Name, Price);   
    }
}
