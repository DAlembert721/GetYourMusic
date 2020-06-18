using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class QualificationRepository : BaseRepository, IQualificationRepository
    {
        public QualificationRepository(AppDbContext context) : base(context) { }
        public async Task<Qualification> FindById(int id)
        {
            return await _context.Qualifications.FindAsync(id);
        }
        public async Task<IEnumerable<Qualification>> ListByMusicianIdAsync(int musicianId) =>
            await _context.Qualifications
            .Where(p => p.MusicianId == musicianId)
            .Include(p => p.Musician)
            .ToListAsync();
        public async Task AddAsync(Qualification qualification)
        {
            await _context.Qualifications.AddAsync(qualification);
        }
    }
}
