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
    public class MusicianGenreService : IMusicianGenreService
    {
        private readonly IMusicianGenreRepository _musicianGenreRepository;
        public readonly IUnitOfWork _unitOfWork;

        public MusicianGenreService(IMusicianGenreRepository musicianGenreRepository, IUnitOfWork unitOfWork)
        {
            _musicianGenreRepository = musicianGenreRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MusicianGenreResponse> AssignMusicianGenreAsync(int musicianId, int genreId)
        {
            try
            {

                await _musicianGenreRepository.AssignMusicianGenre(musicianId, genreId);
                await _unitOfWork.CompleteAsync();
                MusicianGenre musicianGenre = await _musicianGenreRepository.FindByMusicianIdAndGenreId(musicianId, genreId);
                return new MusicianGenreResponse(musicianGenre);
            }
            catch (Exception ex)
            {
                return new MusicianGenreResponse($"An error ocurred while assigning Genre to Musician: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MusicianGenre>> ListByGenreIdAsync(int genreId)
        {
            return await _musicianGenreRepository.ListByGenreIdAsync(genreId);
        }

        public async Task<IEnumerable<MusicianGenre>> ListByMusicianIdAsync(int musicianId)
        {
            return await _musicianGenreRepository.ListByMusicianIdAsync(musicianId);
        }

        public async Task<MusicianGenreResponse> UnassignMusicianGenreAsync(int musicianId, int genreId)
        {
            try
            {
                MusicianGenre musicianGenre = await _musicianGenreRepository.FindByMusicianIdAndGenreId(musicianId, genreId);
                _musicianGenreRepository.Remove(musicianGenre);
                await _unitOfWork.CompleteAsync();
                return new MusicianGenreResponse(musicianGenre);
            }
            catch (Exception ex)
            {
                return new MusicianGenreResponse($"An error ocurred while unassigning Genre to Musician: {ex.Message}");
            }

        }
    }
}
