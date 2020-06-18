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
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Genre>> ListAsync()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
