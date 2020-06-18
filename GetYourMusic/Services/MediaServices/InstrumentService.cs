using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly IMusicianInstrumentRepository _musicianInstrumentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public InstrumentService(IInstrumentRepository instrumentRepository, IMusicianInstrumentRepository musicianInstrumentRepository,IUnitOfWork unitOfWork)
        {
            _instrumentRepository = instrumentRepository;
            _musicianInstrumentRepository = musicianInstrumentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Instrument>> ListAsync()
        {
            return await _instrumentRepository.ListAsync();
        }

        public async Task<IEnumerable<Instrument>> ListByMusicianIdAsync(int musicianId)
        {
            var musicianInstruments = await _musicianInstrumentRepository.ListByMusicianIdAsync(musicianId);
            var instruments = musicianInstruments.Select(pt => pt.Instrument).ToList();
            return instruments;
        }
    }
}
