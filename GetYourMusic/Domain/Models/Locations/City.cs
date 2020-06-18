using System.Collections.Generic;

namespace GetYourMusic.Domain.Models.Locations
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public IList<District> Districts { get; set; }
    }
}
