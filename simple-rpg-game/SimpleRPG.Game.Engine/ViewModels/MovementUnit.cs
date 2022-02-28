using Microsoft.AspNetCore.Components;
using SimpleRPG.Game.Engine.Models;
using System;

namespace SimpleRPG.Game.Engine.ViewModels
{
    public class MovementUnit
    {
        private readonly World _world;

        public MovementUnit(World world)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
            CurrentLocation = world.GetHomeLocation();
        }

        public Location CurrentLocation { get; private set; }
        public EventCallback<Location> LocationChanged { get; set; }

        public bool CanMoveNorth =>
            _world.HasLocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);

        public bool CanMoveEast =>
            _world.HasLocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);

        public bool CanMoveSouth =>
            _world.HasLocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);

        public bool CanMoveWest =>
            _world.HasLocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);

        public void MoveNorth() =>
            MoveBase(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);

        public void MoveEast() =>
            MoveBase(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);

        public void MoveSouth() =>
            MoveBase(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);

        public void MoveWest() =>
            MoveBase(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);

        private void MoveBase(int xCorridate, int yCoordinate)
        {
            if (_world.HasLocationAt(xCorridate, yCoordinate))
            {
                CurrentLocation = _world.LocationAt(xCorridate, yCoordinate);
                LocationChanged.InvokeAsync(CurrentLocation);
            }
        }

    }
}
