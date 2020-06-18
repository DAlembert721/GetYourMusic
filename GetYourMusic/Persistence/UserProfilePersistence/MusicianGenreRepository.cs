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
    public class MusicianGenreRepository: BaseRepository, IMusicianGenreRepository
    {
        public MusicianGenreRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(MusicianGenre musicianGenre)
        {
            await _context.MusicianGenres.AddAsync(musicianGenre);
        }

        public async Task AssignMusicianGenre(int musicianId, int genreId)
        {
            MusicianGenre musicianGenre = await FindByMusicianIdAndGenreId(musicianId, genreId);
            if (musicianGenre == null)
            {
                musicianGenre = new MusicianGenre { MusicianId = musicianId, GenreId = genreId };
                await AddAsync(musicianGenre);
            }
        }

        public async Task<MusicianGenre> FindByMusicianIdAndGenreId(int musicianId, int genreId)
        {
            return await _context.MusicianGenres.FindAsync(musicianId, genreId);
        }

        public async Task<IEnumerable<MusicianGenre>> ListByGenreIdAsync(int genreId)
        {
            return await _context.MusicianGenres
                .Where(pt => pt.GenreId == genreId)
                .Include(pt => pt.Musician)
                .Include(pt => pt.Genre)
                .ToListAsync();
        }

        public async Task<IEnumerable<MusicianGenre>> ListByMusicianIdAsync(int musicianId)
        {
            return await _context.MusicianGenres
                .Where(pt => pt.MusicianId == musicianId)
                .Include(pt => pt.Musician)
                .Include(pt => pt.Genre)
                .ToListAsync();
        }

        public void Remove(MusicianGenre musicianGenre)
        {
            _context.MusicianGenres.Remove(musicianGenre);
        }

        public async void UnassignMusicianGenre(int musicianId, int genreId)
        {
            MusicianGenre musicianGenre = await FindByMusicianIdAndGenreId(musicianId, genreId);
            if (musicianGenre != null)
            {
                Remove(musicianGenre);
            }
        }
    }
}
