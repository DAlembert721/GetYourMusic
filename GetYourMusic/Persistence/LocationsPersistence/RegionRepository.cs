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
    public class RegionRepository: BaseRepository, IRegionRepository
    {
        public RegionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Region>> ListAsync()
        {
            return await _context.Regions.ToListAsync();
        }
    }
}
