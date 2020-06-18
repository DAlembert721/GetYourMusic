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
    public class MusicianInstrumentRepository : BaseRepository, IMusicianInstrumentRepository
    {
        public MusicianInstrumentRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(MusicianInstrument musicianInstrument)
        {
            await _context.MusicianInstruments.AddAsync(musicianInstrument);
        }

        public async Task AssignMusicianInstrument(int musicianId, int instrumentId)
        {
            MusicianInstrument musicianInstrument = await FindByMusicianIdAndInstrumentId(musicianId, instrumentId);
            if (musicianInstrument == null)
            {
                musicianInstrument = new MusicianInstrument { MusicianId = musicianId, InstrumentId = instrumentId };
                await AddAsync(musicianInstrument);
            }
        }

        public async Task<MusicianInstrument> FindByMusicianIdAndInstrumentId(int musicianId, int instrumentId)
        {
            return await _context.MusicianInstruments.FindAsync(musicianId, instrumentId);
        }

        public async Task<IEnumerable<MusicianInstrument>> ListByInstrumentIdAsync(int instrumentId)
        {
            return await _context.MusicianInstruments
                .Where(pt => pt.InstrumentId == instrumentId)
                .Include(pt => pt.Musician)
                .Include(pt => pt.Instrument)
                .ToListAsync();
        }

        public async Task<IEnumerable<MusicianInstrument>> ListByMusicianIdAsync(int musicianId)
        {
            return await _context.MusicianInstruments
                .Where(pt => pt.MusicianId == musicianId)
                .Include(pt => pt.Musician)
                .Include(pt => pt.Instrument)
                .ToListAsync();
        }

        public void Remove(MusicianInstrument musicianInstrument)
        {
            _context.MusicianInstruments.Remove(musicianInstrument);
        }

        public async void UnassignMusicianInstrument(int musicianId, int instrumentId)
        {
            MusicianInstrument musicianInstrument = await FindByMusicianIdAndInstrumentId(musicianId, instrumentId);
            if (musicianInstrument != null)
            {
                Remove(musicianInstrument);
            }
        }
    }
}
