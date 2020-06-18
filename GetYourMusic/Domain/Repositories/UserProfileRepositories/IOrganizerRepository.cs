using GetYourMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IOrganizerRepository
    {
        Task<IEnumerable<Organizer>> ListAsync();
        Task<Organizer> FindById(int id);
        void Update(Organizer organizer);
        void Remove(Organizer organizer);
    }
}
