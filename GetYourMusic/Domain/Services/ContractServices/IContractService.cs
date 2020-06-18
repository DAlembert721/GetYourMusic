using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> ListAsync();
        Task<ContractResponse> GetByIdAsync(int id);
        Task<IEnumerable<Contract>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<Contract>> ListByOrganizerIdAsync(int organizerId);
        //Task<IEnumerable<Contract>> FindByPerformerIdAndEmployerId(int performerId, int employerId);
        Task<ContractResponse> SaveAsync(Contract contract);
        Task<ContractResponse> AssignContractMusician(int id, int musicianId);
        Task<ContractResponse> AssignContractOrganizer(int id, int organizerId);

        Task<ContractResponse> UpdateAsync(int id, Contract contract);
        //Task<ContractResponse> DeleteAsync(int id);
    }
}
