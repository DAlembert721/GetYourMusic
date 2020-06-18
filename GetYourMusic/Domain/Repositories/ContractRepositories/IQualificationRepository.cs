using GetYourMusic.Domain.Models.ContractSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IQualificationRepository
    {
        Task<Qualification> FindById(int id);
        Task<IEnumerable<Qualification>> ListByMusicianIdAsync(int musicianId);
        Task AddAsync(Qualification qualification);
    }
}
