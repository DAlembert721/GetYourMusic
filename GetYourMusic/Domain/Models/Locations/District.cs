using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.Locations
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public IList<Account> Profiles { get; set; } = new List<Account>();
    }
}
