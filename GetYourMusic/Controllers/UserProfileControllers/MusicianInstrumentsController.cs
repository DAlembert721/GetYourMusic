using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/musicians/{musicianId}/instruments")]
    public class MusicianInstrumentsController : Controller
    {
        private readonly IInstrumentService _instrumentService;
        private readonly IMusicianInstrumentService _musicianInstrumentService;
        private readonly IMapper _mapper;

        public MusicianInstrumentsController(IInstrumentService instrumentService,
            IMusicianInstrumentService musicianInstrumentService, IMapper mapper)
        {
            _instrumentService = instrumentService;
            _musicianInstrumentService = musicianInstrumentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InstrumentResource>> GetAllByMusicianIdAsync(int musicianId)
        {
            /*var genres = await _musicianGenreService.ListByMusicianIdAsync(musicianId);
            var resources = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
            return resources; */
            var instruments = await _instrumentService.ListByMusicianIdAsync(musicianId);
            var resources = _mapper.Map<IEnumerable<Instrument>, IEnumerable<InstrumentResource>>(instruments);
            return resources;
        }

        [HttpPost("{instrumentId}")]
        public async Task<IActionResult> AssignMusicianInstrument(int musicianId, int instrumentId)
        {
            var result = await _musicianInstrumentService.AssignMusicianInstrumentAsync(musicianId, instrumentId);
            if (!result.Success)
                return BadRequest(result.Message);

            var instrumentResource = _mapper.Map<Instrument, InstrumentResource>(result.Resource.Instrument);
            return Ok(instrumentResource);

        }

        [HttpDelete("{instrumentId}")]
        public async Task<IActionResult> UnassignMusicianInstrument(int musicianId, int instrumentId)
        {
            var result = await _musicianInstrumentService.UnassignMusicianInstrumentAsync(musicianId, instrumentId);

            if (!result.Success)
                return BadRequest(result.Message);
            var instrumentResource = _mapper.Map<Instrument, InstrumentResource>(result.Resource.Instrument);
            return Ok(instrumentResource);
        }

    }
}
