using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class ContractRepository : BaseRepository, IContractRepository
    {
        public ContractRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _context.Contracts
                .Include(c => c.Musician)
                .Include(c => c.Organizer)
                .Include(c => c.ContractState)
                .ToListAsync();
        }

        public async Task<Contract> FindById(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<IEnumerable<Contract>> ListByMusicianIdAsync(int musicianId)
        {
            return await _context.Contracts
                .Where(c => c.MusicianId == musicianId)
                .Include(c => c.Musician)
                .Include(c => c.Organizer)
                .Include(c => c.ContractState)
                .ToListAsync();
        }

        public async Task<IEnumerable<Contract>> ListByOrganizerIdAsync(int organizerId)
        {
            return await _context.Contracts
                .Where(c => c.OrganizerId == organizerId)
                .Include(c => c.Musician)
                .Include(c => c.Organizer)
                .Include(c => c.ContractState)
                .ToListAsync();
        }

        //public async Task<IEnumerable<Contract>> FindByPerformerIdAndEmployerId(int performerId, int employerId)
        //{
        //    return await _context.Contracts
        //        .Where(c => c.PerformerId == performerId)
        //        .Where(c => c.EmployerId == employerId)
        //        .Include(c => c.Performer)
        //        .Include(c => c.Employer)
        //        .ToListAsync();                
        //}

        public async Task AddAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }

        public void Update(Contract contract)
        {
            _context.Contracts.Update(contract);
        }

        public void Remove(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }

        public async Task<Contract> FindByContractIdAndMusicianId(int contractId, int musicianId)
        {
            return await _context.Contracts.FindAsync(contractId, musicianId);
        }

        public async Task<Contract> FindByContractIdAndOrganizerId(int contractId, int organizerId)
        {
            return await _context.Contracts.FindAsync(contractId, organizerId);
        }
    }
}
