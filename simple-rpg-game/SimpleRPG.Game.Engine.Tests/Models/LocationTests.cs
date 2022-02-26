using SimpleRPG.Game.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleRPG.Game.Engine.Tests.Models
{
    public class LocationTests
    {
        [Fact]
        public void CreateSimpleLocation()
        {
            var l = new Location
            {
                Name = "Test Name",
                XCoordinate = 0,
                YCoordinate = -1,
                Description = "Test Description",
                ImageName = "/images/locations/test.png"
            };

            Assert.NotNull(l);
            Assert.Equal("Test Name",l.Name);
            Assert.Equal(0,l.XCoordinate);
            Assert.Equal(-1,l.YCoordinate);
            Assert.Equal("Test Description", l.Description);
            Assert.Equal("/images/locations/test.png", l.ImageName);
        }
    }
}
