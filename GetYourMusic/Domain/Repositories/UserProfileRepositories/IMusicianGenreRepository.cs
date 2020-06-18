using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IMusicianGenreRepository
    {
        Task<IEnumerable<MusicianGenre>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<MusicianGenre>> ListByGenreIdAsync(int genreId);
        Task<MusicianGenre> FindByMusicianIdAndGenreId(int musicianId, int genreId);
        Task AddAsync(MusicianGenre musicianGenre);
        void Remove(MusicianGenre musicianGenre);
        Task AssignMusicianGenre(int musicianId, int genreId);
        void UnassignMusicianGenre(int musicianId, int genreId);
    }
}
