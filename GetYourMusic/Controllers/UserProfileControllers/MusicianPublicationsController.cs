using AutoMapper;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services;
using GetYourMusic.Extensions;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/musicians/{musicianId}/publications")]
    public class MusicianPublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IMusicianService _musicianService;
        private readonly IMapper _mapper;

        public MusicianPublicationsController(IPublicationService publicationService, IMusicianService musicianService, IMapper mapper)
        {
            _publicationService = publicationService;
            _musicianService = musicianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IEnumerable<PublicationResource>> GetAllByMusicianIdAsync (int musicianId)
        {
            var publications = await _publicationService.ListByMusicianIdAsync(musicianId);
            var resources = _mapper
                .Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(int musicianId, [FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var existingMusician = await _musicianService.GetByIdAsync(musicianId);

            if (!existingMusician.Success)
                return BadRequest(existingMusician.Message);

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            publication.Musician = existingMusician.Resource;

            var result = await _publicationService.SaveAsync(publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePublicationResource resource)
        {
            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, publication);

            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _publicationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
    }
}
