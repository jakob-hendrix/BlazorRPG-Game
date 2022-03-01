namespace SimpleRPG.Game.Engine.Models
{
    public class Location
    {
        public Location()
        {

        }

        public Location(int x, int y, string name, string description, string image)
        {
            XCoordinate = x;
            YCoordinate = y;
            Name = name;
            Description = description;
            ImageName = image;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
    }
}
