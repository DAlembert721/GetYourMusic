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
    [Route("/api/musicians/{musicianId}/genres")]
    public class MusicianGenresController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMusicianGenreService _musicianGenreService;
        private readonly IMapper _mapper;


        public MusicianGenresController(IGenreService genreService, IMusicianGenreService musicianGenreService, IMapper mapper)
        {
            _genreService = genreService;
            _musicianGenreService = musicianGenreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GenreResource>> GetAllByMusicianIdAsync(int musicianId)
        {
            var genres = await _genreService.ListByMusicianIdAsync(musicianId);
            var resources = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
            return resources;
        }

        [HttpPost("{genreId}")]
        public async Task<IActionResult> AssignMusicianGenre(int musicianId, int genreId)
        {
            var result = await _musicianGenreService.AssignMusicianGenreAsync(musicianId, genreId);
            if (!result.Success)
                return BadRequest(result.Message);

            var genreResource = _mapper.Map<Genre, GenreResource>(result.Resource.Genre);
            return Ok(genreResource);

        }

        [HttpDelete("{genreId}")]
        public async Task<IActionResult> UnassignMusicianGenre(int musicianId, int genreId)
        {
            var result = await _musicianGenreService.UnassignMusicianGenreAsync(musicianId, genreId);

            if (!result.Success)
                return BadRequest(result.Message);
            var genreResource = _mapper.Map<Genre, GenreResource>(result.Resource.Genre);
            return Ok(genreResource);
        }

    }
}
