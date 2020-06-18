using AutoMapper;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/musicians/{musicianId}/contracts")]
    public class ContractsMusiciansController : Controller
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public ContractsMusiciansController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MusiciansContractResource>> GetAllByMusicianId(int musicianId)
        {
            var musician = await _contractService.ListByMusicianIdAsync(musicianId);
            var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<MusiciansContractResource>>(musician);
            return resources;
        }
    }
}