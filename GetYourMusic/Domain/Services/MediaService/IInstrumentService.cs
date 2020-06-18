using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IInstrumentService
    {
        Task<IEnumerable<Instrument>> ListAsync();
        Task<IEnumerable<Instrument>> ListByMusicianIdAsync(int musicianId);
    }
}
