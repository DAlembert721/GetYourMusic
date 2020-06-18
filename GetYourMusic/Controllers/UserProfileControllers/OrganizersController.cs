using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using GetYourMusic.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetYourMusic.Domain.Models.UserProfileSystem;

namespace GetYourMusic.Controllers
{
    [Route("/api/[controller]")]
    public class OrganizersController : Controller
    {
        private readonly IOrganizerService _organizerService;
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OrganizersController(IOrganizerService organizerService, IUserService userService, IMapper mapper)
        {
            _organizerService = organizerService;
            //_userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrganizerResource>> GetAllAsync()
        {
            var organizers = await _organizerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Organizer>, IEnumerable<OrganizerResource>>(organizers);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _organizerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var organizerResource = _mapper.Map<Organizer, OrganizerResource>(result.Resource);
            return Ok(organizerResource);
        }

        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody] SaveEventOwnerResource resource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState.GetErrorMessages());

        //    var user = _mapper.Map<SaveEventOwnerResource, User>(resource);
        //    var userResult = await _userService.SaveAsync(user);

        //    if (!userResult.Success)
        //        return BadRequest(userResult.Message);

        //    var eventOwner = _mapper.Map<SaveEventOwnerResource, EventOwner>(resource);
        //    eventOwner.User = user;

        //    var result = await _eventOwnerService.SaveAsync(eventOwner);

        //    if (!result.Success)
        //        return BadRequest(result.Message);

        //    var eventOwnerResource = _mapper.Map<EventOwner, EventOwnerResource>(result.Resource);
        //    return Ok(eventOwnerResource);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrganizerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var organizer = _mapper.Map<SaveOrganizerResource, Organizer>(resource);
            var result = await _organizerService.UpdateAsync(id, organizer);

            if (!result.Success)
                return BadRequest(result.Message);

            var organizerResource = _mapper.Map<Organizer, OrganizerResource>(result.Resource);
            return Ok(organizerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _organizerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var organizerResource = _mapper.Map<Organizer, OrganizerResource>(result.Resource);
            return Ok(organizerResource);
        }
    }
}
