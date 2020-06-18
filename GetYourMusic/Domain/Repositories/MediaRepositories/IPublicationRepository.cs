using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        void Update(Publication publication);
        void Remove(Publication publication);
        Task<IEnumerable<Publication>> ListByMusicianIdAsync(int musicianId);
        Task<Publication> FindById(int id);
        Task<IEnumerable<Publication>> ListByTypeAsync(string publicationType);

    }
}
