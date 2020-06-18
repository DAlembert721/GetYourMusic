using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<District>> ListByCityIdAsync(int cityId)
        {
            return await _districtRepository.ListByCityIdAsync(cityId);
        }
    }
}
