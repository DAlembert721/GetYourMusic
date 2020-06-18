using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class CityRepository: BaseRepository, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<City>> ListByRegionIdAsync(int regionId) =>
            await _context.Cities
            .Where(p => p.RegionId == regionId)
            .Include(p => p.Region)
            .ToListAsync();
    }
}
