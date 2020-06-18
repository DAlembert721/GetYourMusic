using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IOrganizerService
    {
        Task<IEnumerable<Organizer>> ListAsync();
        Task<OrganizerResponse> UpdateAsync(int id, Organizer organizer);
        Task<OrganizerResponse> DeleteAsync(int id);
        Task<OrganizerResponse> GetByIdAsync(int id);
    }
}
