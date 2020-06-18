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
    [Route("/api/regions/{regionId}/cities")]
    public class RegionCitiesController: Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public RegionCitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllByRegionIdAsync(int regionId)
        {
            var cities = await _cityService.ListByRegionIdAsync(regionId);
            var resources = _mapper
                .Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);
            return resources;
        }
    }
}
