using AutoMapper;
using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/cities/{cityId}/districts")]
    public class RegionCityDistrictsController:Controller
    {
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public RegionCityDistrictsController(IDistrictService districtService, IMapper mapper)
        {
            _districtService = districtService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DistrictResource>> GetAllByCityIdAsync(int cityId)
        {
            var districts = await _districtService.ListByCityIdAsync(cityId);
            var resources = _mapper
                .Map<IEnumerable<District>, IEnumerable<DistrictResource>>(districts);
            return resources;
        }
    }
}
