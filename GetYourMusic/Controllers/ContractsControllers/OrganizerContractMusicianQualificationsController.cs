using AutoMapper;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Extensions;
using GetYourMusic.Resources.ContractResources;
using GetYourMusic.Resources.ContractSaveResources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers.ContractsControllers
{
    [Route("/organizer/{organizerId}/contract/{contractId}/musician/{musicianId}/qualifications")]
    public class OrganizerContractMusicianQualificationsController : Controller
    {
        private readonly IQualificationService _qualificationService;
        private readonly IOrganizerService _organizerService;
        private readonly IContractService _contractService;
        private readonly IMusicianService _musicianService;
        private readonly IMapper _mapper;

        public OrganizerContractMusicianQualificationsController(IQualificationService qualificationService, IOrganizerService organizerService,
            IContractService contractService, IMusicianService musicianService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _organizerService = organizerService;
            _contractService = contractService;
            _musicianService = musicianService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int organizerId, int contractId, int musicianId, [FromBody] SaveQualificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var existingOrganizer = await _organizerService.GetByIdAsync(organizerId);

            if (!existingOrganizer.Success)
                return BadRequest(existingOrganizer.Message);

            var existingContract = await _contractService.GetByIdAsync(contractId);

            if (!existingContract.Success)
                return BadRequest(existingContract.Message);

            var existingMusician = await _musicianService.GetByIdAsync(musicianId);

            if (!existingMusician.Success)
                return BadRequest(existingMusician.Message);

            var qualification = _mapper.Map<SaveQualificationResource, Qualification>(resource);
            qualification.Organizer = existingOrganizer.Resource;
            qualification.Contract = existingContract.Resource;
            qualification.Musician = existingMusician.Resource;

            var result = await _qualificationService.SaveAsync(qualification);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificationResource = _mapper.Map<Qualification, QualificationResource>(result.Resource);
            return Ok(qualificationResource);
        }
    }
}
