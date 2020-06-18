using Microsoft.EntityFrameworkCore;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class OrganizerRepository : BaseRepository, IOrganizerRepository
    {
        public OrganizerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Organizer>> ListAsync()
        {
            return await _context.Organizers.ToListAsync();
        }

        public async Task<Organizer> FindById(int id)
        {
            return await _context.Organizers.FindAsync(id);
        }

        public void Update(Organizer organizer)
        {
            _context.Organizers.Update(organizer);
        }

        public void Remove(Organizer organizer)
        {
            _context.Organizers.Remove(organizer);
        }
    }
}