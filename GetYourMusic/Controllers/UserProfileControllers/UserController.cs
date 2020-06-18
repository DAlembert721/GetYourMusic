using AutoMapper;
using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using GetYourMusic.Extensions;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Authorize]
    [Route("/api/users")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);

            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var musicianResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(musicianResource);
        }
    }
}