using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context){ }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindById(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public async Task<IEnumerable<Publication>> ListByMusicianIdAsync(int musicianId) =>
            await _context.Publications
            .Where(a => a.MusicianId == musicianId)
            .Include(a => a.Musician)
            .ToListAsync();

        public async Task<IEnumerable<Publication>> ListByTypeAsync(string publicationType) =>
            await _context.Publications
            .Where(a => a.PublicationType == publicationType)
            .ToListAsync();

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }
    }
}
