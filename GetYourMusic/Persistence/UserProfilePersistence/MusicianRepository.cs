using Microsoft.EntityFrameworkCore;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GetYourMusic.Persistence
{
    public class MusicianRepository : BaseRepository, IMusicianRepository
    {
        public MusicianRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Musician>> ListAsync()
        {
            return await _context.Musicians.ToListAsync();
        }

        public async Task<Musician> FindById(int id)
        {
            return await _context.Musicians.FindAsync(id);
        }

        public void Update(Musician musician)
        {
            _context.Musicians.Update(musician);
        }

        public void Remove(Musician musician)
        {
            _context.Musicians.Remove(musician);
        }

        public async Task<IEnumerable<Musician>> ListByDistrictIdAsync(int districtId) =>
            await _context.Musicians
            .Where(p => p.DistrictId == districtId)
            .Include(p => p.District)
            .ToListAsync();

        public async Task<IEnumerable<Musician>> FindMusicianByName(string name) =>
            await _context.Musicians
            .Where(p => p.FirstName == name)
            .ToListAsync();
    }
}
