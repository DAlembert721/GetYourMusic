using AutoMapper;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/[controller]")]
    public class InstrumentsController : Controller
    {
        private readonly IInstrumentService _instrumentService;
        private readonly IMapper _mapper;

        public InstrumentsController(IInstrumentService instrumentService, IMapper mapper)
        {
            _instrumentService = instrumentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InstrumentResource>> GetAllAsync()
        {
            var instruments = await _instrumentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Instrument>, IEnumerable<InstrumentResource>>(instruments);
            return resources;
        }
    }
}
