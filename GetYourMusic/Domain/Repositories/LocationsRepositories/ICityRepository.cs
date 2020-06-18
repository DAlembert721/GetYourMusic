using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListByRegionIdAsync(int regionId);
    }
}
