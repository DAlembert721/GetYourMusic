using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ContractService(IContractRepository contractRepository, IUnitOfWork unitOfWork)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _contractRepository.ListAsync();
        }

        public async Task<ContractResponse> GetByIdAsync(int id)
        {
            var existingContract = await _contractRepository.FindById(id);

            if (existingContract == null)
                return new ContractResponse("Contract not found");
            return new ContractResponse(existingContract);
        }

        public async Task<IEnumerable<Contract>> ListByMusicianIdAsync(int musicianId)
        {
            return await _contractRepository.ListByMusicianIdAsync(musicianId);
        }

        public async Task<IEnumerable<Contract>> ListByOrganizerIdAsync(int organizerId)
        {
            return await _contractRepository.ListByOrganizerIdAsync(organizerId);
        }

        //public async Task<IEnumerable<Contract>> FindByPerformerIdAndEmployerId(int performerId, int employerId)
        //{
        //    return await _contractRepository.FindByPerformerIdAndEmployerId(performerId, employerId);
        //}

        public async Task<ContractResponse> SaveAsync(Contract contract)
        {
            try
            {
                await _contractRepository.AddAsync(contract);
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(contract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"An error ocurred while saving the contract: {ex.Message}");
            }
        }

        public async Task<ContractResponse> AssignContractMusician(int contractId, int musicianId)
        {
            try
            {
                var existingContract = await _contractRepository.FindById(contractId);
                existingContract.MusicianId = musicianId;
                await _unitOfWork.CompleteAsync();
                Contract contract = await _contractRepository.FindByContractIdAndMusicianId(contractId, musicianId);
                return new ContractResponse(contract);
                
            }
            catch(Exception ex)
            {
                return new ContractResponse($"An error ocurred while assigning Musician to Contract: {ex.Message}");
            }
        }

        public async Task<ContractResponse> AssignContractOrganizer(int id, int organizerId)
        {
            try
            {
                var existingContract = await _contractRepository.FindById(id);
                existingContract.OrganizerId = organizerId;

                _contractRepository.Update(existingContract);

                await _unitOfWork.CompleteAsync();
                Contract contract = await _contractRepository.FindByContractIdAndOrganizerId(id, organizerId);
                return new ContractResponse(contract);

            }
            catch (Exception ex)
            {
                return new ContractResponse($"An error ocurred while assigning Organizer to Contract: {ex.Message}");
            }
        }

        public async Task<ContractResponse> UpdateAsync(int id, Contract contract)
        {
            var existingContract = await _contractRepository.FindById(id);

            if (existingContract == null)
                return new ContractResponse("Contract not found");

            //Asignar todos los valores

            try
            {
                _contractRepository.Update(existingContract);
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(existingContract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"An error ocurred while updating contract: {ex.Message}");
            }
        }

        public async Task<ContractResponse> DeleteAsync(int id)
        {
            var existingContract = await _contractRepository.FindById(id);

            if (existingContract == null)
                return new ContractResponse("Contract not found");

            try
            {
                _contractRepository.Remove(existingContract);
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(existingContract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"An error ocurred while deleting contract: {ex.Message}");
            }
        }
    }
}
