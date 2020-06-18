using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> ListAsync();
    }
}
