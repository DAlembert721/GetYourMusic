using GetYourMusic.Domain.Models.ContractSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> ListAsync();
        Task<Contract> FindById(int id);
        Task<IEnumerable<Contract>> ListByMusicianIdAsync(int musicianId);
        Task<IEnumerable<Contract>> ListByOrganizerIdAsync(int organizerId);
        //Task<IEnumerable<Contract>> FindByMusicianIdAndEmployerId(int musicianId, int eventOwnerId);
        Task<Contract> FindByContractIdAndMusicianId(int contractId, int musicianId);
        Task<Contract> FindByContractIdAndOrganizerId(int contractId, int organizerId);
        Task AddAsync(Contract contract);
        void Update(Contract contract);
        void Remove(Contract contract);
        //void UnassignContract(int performerId, int employerId);
    }
}
