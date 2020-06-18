using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while deleting a publication: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<IEnumerable<Publication>> ListByMusicianIdAsync(int musicianId)
        {
            return await _publicationRepository.ListByMusicianIdAsync(musicianId);
        }
        
        public async Task<IEnumerable<Publication>> ListByTypeAsync(string publicationId)
        {
            return await _publicationRepository.ListByTypeAsync(publicationId);
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(publication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while saving the publication: {ex.Message}");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Category not found");

            existingPublication.Content = publication.Content;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while updating publication: {ex.Message}");
            }
        }

        public async Task<PublicationResponse> GetByIdAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");
            return new PublicationResponse(existingPublication);
        }
    }
}
