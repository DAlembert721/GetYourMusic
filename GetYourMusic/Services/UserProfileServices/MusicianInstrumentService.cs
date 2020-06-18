using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class MusicianInstrumentService : IMusicianInstrumentService
    {
        private readonly IMusicianInstrumentRepository _musicianInstrumentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public MusicianInstrumentService(IMusicianInstrumentRepository musicianInstrumentRepository, IUnitOfWork unitOfWork)
        {
            _musicianInstrumentRepository = musicianInstrumentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MusicianInstrumentResponse> AssignMusicianInstrumentAsync(int musicianId, int instrumentId)
        {
            try
            {

                await _musicianInstrumentRepository.AssignMusicianInstrument(musicianId, instrumentId);
                await _unitOfWork.CompleteAsync();
                MusicianInstrument musicianInstrument = await _musicianInstrumentRepository.FindByMusicianIdAndInstrumentId(musicianId, instrumentId);
                return new MusicianInstrumentResponse(musicianInstrument);
            }
            catch (Exception ex)
            {
                return new MusicianInstrumentResponse($"An error ocurred while assigning Instrument to Musician: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MusicianInstrument>> ListByInstrumentIdAsync(int instrumentId)
        {
            return await _musicianInstrumentRepository.ListByInstrumentIdAsync(instrumentId);
        }

        public async Task<IEnumerable<MusicianInstrument>> ListByMusicianIdAsync(int musicianId)
        {
            return await _musicianInstrumentRepository.ListByMusicianIdAsync(musicianId);
        }

        public async Task<MusicianInstrumentResponse> UnassignMusicianInstrumentAsync(int musicianId, int instrumentId)
        {
            try
            {
                MusicianInstrument musicianInstrument = await _musicianInstrumentRepository.FindByMusicianIdAndInstrumentId(musicianId, instrumentId);
                _musicianInstrumentRepository.Remove(musicianInstrument);
                await _unitOfWork.CompleteAsync();
                return new MusicianInstrumentResponse(musicianInstrument);
            }
            catch (Exception ex)
            {
                return new MusicianInstrumentResponse($"An error ocurred while unassigning Instrument to Musician: {ex.Message}");
            }
        }
    }
}
