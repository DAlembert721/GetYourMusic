using AutoMapper;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Extensions;
using GetYourMusic.Patterns;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/organizers/{organizerId}/musicians/{musicianId}/contracts")]
    public class OrganizerMusicianContractsController : Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IMusicianService _musicianService;
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public OrganizerMusicianContractsController(IOrganizerService organizerService, IMusicianService musicianService, IContractService contractService, IMapper mapper)
        {
            _organizerService = organizerService;
            _musicianService = musicianService;
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int organizerId, int musicianId, [FromBody] SaveContractResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var factory = new FlyweightFactory(_contractService.ListByOrganizerIdAsync(organizerId).Result);

            var contract = _mapper.Map<SaveContractResource, Contract>(resource);

            var flyweight = factory.GetFlyweight(new Contract
            {
                OrganizerId = organizerId,
                ContractStateId = 1
            });

            flyweight.Operation(contract);

            var existingOrganizer = await _organizerService.GetByIdAsync(organizerId);

            if (!existingOrganizer.Success)
                return BadRequest(existingOrganizer.Message);

            var existingMusician = await _musicianService.GetByIdAsync(musicianId);

            if (!existingMusician.Success)
                return BadRequest(existingMusician.Message);


            contract.Organizer = existingOrganizer.Resource;
            contract.Musician = existingMusician.Resource;

            var result = await _contractService.SaveAsync(contract);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractResource = _mapper.Map<Contract, BaseContractResourse>(result.Resource);
            return Ok(contractResource);
        }
    }
}