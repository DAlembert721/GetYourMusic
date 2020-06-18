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
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository;
        public readonly IUnitOfWork _unitOfWork;

        public QualificationService(IQualificationRepository qualificationRepository, IUnitOfWork unitOfWork)
        {
            _qualificationRepository = qualificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Qualification>> ListByMusicianIdAsync(int musicianId)
        {
            return await _qualificationRepository.ListByMusicianIdAsync(musicianId);
        }

        public async Task<QualificationResponse> GetByIdAsync(int id)
        {
            var existingQualification = await _qualificationRepository.FindById(id);

            if (existingQualification == null)
                return new QualificationResponse("Qualification not found");
            return new QualificationResponse(existingQualification);
        }

        public async Task<QualificationResponse> SaveAsync(Qualification qualification)
        {
            try
            {
                await _qualificationRepository.AddAsync(qualification);
                await _unitOfWork.CompleteAsync();

                return new QualificationResponse(qualification);
            }
            catch (Exception ex)
            {
                return new QualificationResponse($"An error ocurred while saving the qualification: {ex.Message}");
            }
        }
    }
}
