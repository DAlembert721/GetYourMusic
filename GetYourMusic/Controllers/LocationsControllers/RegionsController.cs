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
    [Route("/api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionsController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RegionResource>> GetAllAsync()
        {
            var regions = await _regionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Region>, IEnumerable<RegionResource>>(regions);
            return resources;
        }
    }
}
