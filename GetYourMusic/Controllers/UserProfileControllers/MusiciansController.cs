using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Extensions;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class MusiciansController : Controller
    {
        private readonly IMusicianService _musicianService;
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MusiciansController(IMusicianService musicianService, IUserService userService, IMapper mapper)
        {
            _musicianService = musicianService;
            //_userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MusicianResource>> GetAllAsync()
        {
            var musicians = await _musicianService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Musician>, IEnumerable<MusicianResource>>(musicians);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _musicianService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var musicianResource = _mapper.Map<Musician, MusicianResource>(result.Resource);
            return Ok(musicianResource);
        }

        [HttpGet("/search/{name}")]
        public async Task<IEnumerable<MusicianResource>> GetByName(string name)
        {
            var result = await _musicianService.ListByName(name);
            var resources = _mapper.Map <IEnumerable<Musician>,IEnumerable<MusicianResource>> (result);
            return resources;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMusicianResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var musician = _mapper.Map<SaveMusicianResource, Musician>(resource);
            var result = await _musicianService.UpdateAsync(id, musician);

            if (!result.Success)
                return BadRequest(result.Message);

            var musicianResource = _mapper.Map<Musician, MusicianResource>(result.Resource);
            return Ok(musicianResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _musicianService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var musicianResource = _mapper.Map<Musician, MusicianResource>(result.Resource);
            return Ok(musicianResource);
        }
    }
}
