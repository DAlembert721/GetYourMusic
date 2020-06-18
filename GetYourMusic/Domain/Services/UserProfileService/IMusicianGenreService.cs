using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IMusicianGenreService
    {
        Task<IEnumerable<MusicianGenre>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<MusicianGenre>> ListByGenreIdAsync(int genreId);
        Task<MusicianGenreResponse> AssignMusicianGenreAsync(int musicianId, int genreId);
        Task<MusicianGenreResponse> UnassignMusicianGenreAsync(int musicianId, int genreId);
    }
}
