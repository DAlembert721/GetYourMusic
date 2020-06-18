using System.Collections.Generic;

namespace GetYourMusic.Domain.Models.Locations
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<City> Cities { get; set; } = new List<City>();
    }
}
