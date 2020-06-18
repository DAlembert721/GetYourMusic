using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> ListAsync();
    }
}
