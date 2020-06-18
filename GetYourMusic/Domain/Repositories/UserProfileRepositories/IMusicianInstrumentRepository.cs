using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IMusicianInstrumentRepository
    {
        Task<IEnumerable<MusicianInstrument>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<MusicianInstrument>> ListByInstrumentIdAsync(int instrumentId);
        Task<MusicianInstrument> FindByMusicianIdAndInstrumentId(int musicianId, int instrumentId);
        Task AddAsync(MusicianInstrument musicianInstrument);
        void Remove(MusicianInstrument musicianInstrument);
        Task AssignMusicianInstrument(int musicianId, int instrumentId);
        void UnassignMusicianInstrument(int musicianId, int instrumentId);
    }
}
