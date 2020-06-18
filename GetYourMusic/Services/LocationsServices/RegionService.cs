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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RegionService(IRegionRepository regionRepository, IUnitOfWork unitOfWork)
        {
            _regionRepository = regionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Region>> ListAsync()
        {
            return await _regionRepository.ListAsync();
        }
    }
}
