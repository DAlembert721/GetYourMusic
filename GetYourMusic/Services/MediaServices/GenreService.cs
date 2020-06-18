using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMusicianGenreRepository _musicianGenreRepository;
        public readonly IUnitOfWork _unitOfWork;

        public GenreService(IGenreRepository genreRepository, IMusicianGenreRepository musicianGenreRepository,IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _musicianGenreRepository = musicianGenreRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Genre>> ListAsync()
        {
            return await _genreRepository.ListAsync();
        }

        public async Task<IEnumerable<Genre>> ListByMusicianIdAsync(int musicianId)
        {
            var musicianGenres = await _musicianGenreRepository.ListByMusicianIdAsync(musicianId);
            var genres = musicianGenres.Select(pt => pt.Genre).ToList();
            return genres;
        }
    }
}
