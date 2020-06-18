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
    public class DistrictRepository : BaseRepository, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context) { }

        public async Task<District> FindById(int id)
        {
            return await _context.Districts.FindAsync(id);
        }

        public async Task<IEnumerable<District>> ListByCityIdAsync(int cityId) =>
            await _context.Districts
            .Where(p => p.CityId == cityId)
            .Include(p => p.City)
            .ToListAsync();
    }
}
