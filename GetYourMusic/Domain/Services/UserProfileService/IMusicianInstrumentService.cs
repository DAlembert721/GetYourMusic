using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IMusicianInstrumentService
    {
        Task<IEnumerable<MusicianInstrument>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<MusicianInstrument>> ListByInstrumentIdAsync(int instrumentId);
        Task<MusicianInstrumentResponse> AssignMusicianInstrumentAsync(int musicianId, int instrumentId);
        Task<MusicianInstrumentResponse> UnassignMusicianInstrumentAsync(int musicianId, int instrumentId);
    }
}
