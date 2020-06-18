using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IGenreService
    {
       Task<IEnumerable<Genre>> ListAsync();
       Task<IEnumerable<Genre>> ListByMusicianIdAsync(int musicianId);
    }
}
