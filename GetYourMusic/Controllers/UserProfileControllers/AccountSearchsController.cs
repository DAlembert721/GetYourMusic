using AutoMapper;
using GetYourMusic.Domain.Models.UserProfileSystem;
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
    [Route("/api/accounts/{accountId}/searchs")]
    public class AccountSearchsController : Controller
    {
        //readonly private IMusicianService _musicianService;
        //readonly private IEventOwnerService _eventOwnerService;
        readonly private ISearchService _searchService;
        readonly private IMapper _mapper;

        public AccountSearchsController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SearchResource>> GetAllByAccountId(int accountId)
        {
            var searches = await _searchService.ListByAccountIdAsync(accountId);
            var resources = _mapper.Map<IEnumerable<Search>, IEnumerable<SearchResource>>(searches);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int accountId, [FromBody] SaveSearchResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            //var existingEventOwner = await _eventOwnerService.GetByIdAsync(eventOwnerId);

            //if (!existingEventOwner.Success)
            //    return BadRequest(existingEventOwner.Message);

            //var existingMusician = await _musicianService.GetByIdAsync(musicianId);

            //if (!existingMusician.Success)
            //    return BadRequest(existingMusician.Message);

            var search = _mapper.Map<SaveSearchResource, Search>(resource);
            search.AccountId = accountId;
            //search.Musician = existingMusician.Resource;

            var result = await _searchService.SaveAsync(search);

            if (!result.Success)
                return BadRequest(result.Message);

            var searchResource = _mapper.Map<Search, SearchResource>(result.Resource);
            return Ok(searchResource);
        }
    }
}
