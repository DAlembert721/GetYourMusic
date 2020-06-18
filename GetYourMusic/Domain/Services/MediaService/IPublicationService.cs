using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task<IEnumerable<Publication>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<Publication>> ListByTypeAsync(string publicationType);
        Task<PublicationResponse> GetByIdAsync(int id);
        Task<PublicationResponse> SaveAsync(Publication publication);
        Task<PublicationResponse> UpdateAsync(int id, Publication publication);
        Task<PublicationResponse> DeleteAsync(int id);
    }
}
