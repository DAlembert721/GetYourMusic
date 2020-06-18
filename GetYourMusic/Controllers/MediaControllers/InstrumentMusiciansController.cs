using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers.MediaControllers
{
    [Route("/api/instruments/{instrumentId}/musicians")]
    public class InstrumentMusiciansController : Controller
    {
        private readonly IMusicianService _musicianService;
        private readonly IMapper _mapper;

        public InstrumentMusiciansController(IMusicianService musicianService,IMapper mapper)
        {
            _musicianService = musicianService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<MusicianResource>> GetAllInstrumentIdAsync(int instrumentId)
        {
            var musicians = await _musicianService.ListByInstrumentIdAsync(instrumentId);
            var resources = _mapper.Map<IEnumerable<Musician>, IEnumerable<MusicianResource>>(musicians);
            return resources;
        }
    }
}
