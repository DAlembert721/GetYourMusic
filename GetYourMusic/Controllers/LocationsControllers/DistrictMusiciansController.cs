using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers.LocationsControllers
{
    [Route("/api/districts/{districtId}/musicians")]
    public class DistrictMusiciansController : Controller
    {
        private readonly IMusicianService _musicianService;
        private readonly IMapper _mapper;

        public DistrictMusiciansController(IMusicianService musicianService, IMapper mapper)
        {
            _musicianService = musicianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MusicianResource>> GetAllByDistrictIdAsync(int districtId)
        {
            var musicians = await _musicianService.ListByDistrictIdAsync(districtId);
            var resources = _mapper.Map<IEnumerable<Musician>, IEnumerable<MusicianResource>>(musicians);
            return resources;
        }

    }
}
