using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IQualificationService
    {
        Task<QualificationResponse> GetByIdAsync(int id);
        Task<IEnumerable<Qualification>> ListByMusicianIdAsync(int musicianId);
        Task<QualificationResponse> SaveAsync(Qualification qualification);
    }
}
