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
    [Route("/api/follower/{followerId}/followed")]
    public class FollowsController : Controller
    {
        private readonly IFollowService _followService;
        private readonly IMusicianService _musicianService;
        private readonly IMapper _mapper;
        public FollowsController(IFollowService followService, IMusicianService musicianService,IMapper mapper)
        {
            _followService = followService;
            _musicianService = musicianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MusicianResource>> GetAllByFollowerIdAsync(int followerId)
        {
            var followed = await _musicianService.ListByFollowerIdAsync(followerId);
            var resources = _mapper.Map<IEnumerable<Musician>, IEnumerable<MusicianResource>>(followed);
            return resources;
        }

        [HttpPost("{followedId}")]
        public async Task<IActionResult> AssignFollowerFollowed(int followerId, int followedId)
        {
            var result = await _followService.AssignFollowerFollowedAsync(followerId, followedId);
            if (!result.Success)
                return BadRequest(result.Message);

            var followedResource = _mapper.Map<Musician, MusicianResource>(result.Resource.Followed);
            return Ok(followedResource);

        }

        [HttpDelete("{followedId}")]
        public async Task<IActionResult> UnassignFollowerFollowed(int followerId, int followedId)
        {
            var result = await _followService.UnassignFollowerFollowedAsync(followerId, followedId);

            if (!result.Success)
                return BadRequest(result.Message);
            var followedResource = _mapper.Map<Musician, MusicianResource>(result.Resource.Followed);
            return Ok(followedResource);
        }
    }
}
