using AutoMapper;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using GetYourMusic.Extensions;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("api/[controller]")]
    public class ContractsController : Controller
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public ContractsController(IContractService contractService, IOrganizerService organizerService, IMusicianService musicianService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveContractResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var contract = _mapper.Map<SaveContractResource, Contract>(resource);
            var result = await _contractService.SaveAsync(contract);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var contractResource = _mapper.Map<Contract, BaseContractResourse>(result.Resource);
            return Ok(contractResource);
        }
    }
}
