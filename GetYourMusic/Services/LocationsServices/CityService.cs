using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<City>> ListByRegionIdAsync(int regionId)
        {
            return await _cityRepository.ListByRegionIdAsync(regionId);
        }
    }
}
