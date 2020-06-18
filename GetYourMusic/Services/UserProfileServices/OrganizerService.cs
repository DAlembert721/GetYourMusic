using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;
        public readonly IUnitOfWork _unitOfWork;

        public OrganizerService(IOrganizerRepository organizerRepository, IUnitOfWork unitOfWork)
        {
            _organizerRepository = organizerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Organizer>> ListAsync()
        {
            return await _organizerRepository.ListAsync();
        }

        public async Task<OrganizerResponse> GetByIdAsync(int id)
        {
            var existingOrganizer = await _organizerRepository.FindById(id);

            if (existingOrganizer == null)
                return new OrganizerResponse("Organizer nor found");
            return new OrganizerResponse(existingOrganizer);
        }

        public async Task<OrganizerResponse> UpdateAsync(int id, Organizer organizer)
        {
            var existingOrganizer = await _organizerRepository.FindById(id);

            if (existingOrganizer == null)
                return new OrganizerResponse("Organizer not found");

            existingOrganizer.FirstName = organizer.FirstName;
            existingOrganizer.LastName = organizer.LastName;
            existingOrganizer.Phone = organizer.Phone;
            existingOrganizer.PersonalWeb = organizer.PersonalWeb;
            existingOrganizer.BirthDate = organizer.BirthDate;

            try
            {
                _organizerRepository.Update(existingOrganizer);
                await _unitOfWork.CompleteAsync();

                return new OrganizerResponse(existingOrganizer);
            }
            catch (Exception ex)
            {
                return new OrganizerResponse($"An error has ocurred while updating organizer: {ex.Message}");
            }
        }

        public async Task<OrganizerResponse> DeleteAsync(int id)
        {
            var existingOrganizer = await _organizerRepository.FindById(id);

            if (existingOrganizer == null)
                return new OrganizerResponse("Organizer not found");

            try
            {
                _organizerRepository.Remove(existingOrganizer);
                await _unitOfWork.CompleteAsync();

                return new OrganizerResponse(existingOrganizer);
            }
            catch (Exception ex)
            {
                return new OrganizerResponse($"An error has ocurred while deleting organizer: {ex.Message}");
            }
        }
    }
}
