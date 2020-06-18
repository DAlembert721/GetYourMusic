using AutoMapper;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/organizers/{organizerId}/contracts")]
    public class OrganizerContractsController : Controller
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public OrganizerContractsController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrganizersContractResource>> GetAllByOrganizerId(int organizerId)
        {
            var organizer = await _contractService.ListByOrganizerIdAsync(organizerId);
            var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<OrganizersContractResource>>(organizer);
            return resources;
        }

    }
}
