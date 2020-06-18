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
    [Route("/api/[controller]")]
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationsController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PublicationResource>> GetAllAsync()
        {
            var publications = await _publicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
        }

        [HttpGet("{publicationType}")]
        public async Task<IEnumerable<PublicationResource>> GetAllByTypeAsync(string publicationType)
        {
            var publications = await _publicationService.ListByTypeAsync(publicationType);
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
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
