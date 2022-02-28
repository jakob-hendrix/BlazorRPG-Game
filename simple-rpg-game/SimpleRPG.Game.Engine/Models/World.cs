using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRPG.Game.Engine.Models
{
    public class World
    {
        private readonly IList<Location> _locations;

        public World(IEnumerable<Location> locs)
        {
            _locations = locs is null ? new List<Location>() : locs.ToList();
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            var loc = _locations.FirstOrDefault(p => p.XCoordinate == xCoordinate && p.YCoordinate == yCoordinate);
            return loc ?? throw new ArgumentOutOfRangeException("Coordinates", "Provided coordinates could not be found in game world.");
        }

        public bool HasLocationAt(int xCoordinate, int yCoordinate) => _locations.Any(p => p.XCoordinate == xCoordinate && p.YCoordinate == yCoordinate);

        public Location GetHomeLocation() => LocationAt(0, -1);
    }
}
