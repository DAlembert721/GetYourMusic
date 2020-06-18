using AutoMapper;
using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Services;
using GetYourMusic.Resources.ContractResources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers.ContractsControllers
{
    [Route("api/musicians/{musicianId}/qualifications")]
    public class MusicianQualificationsController : Controller
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public MusicianQualificationsController(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<QualificationResource>> GetAllByMusicianIdAsync(int musicianId)
        {
            var qualifications = await _qualificationService.ListByMusicianIdAsync(musicianId);
            var resources = _mapper
                .Map<IEnumerable<Qualification>, IEnumerable<QualificationResource>>(qualifications);
            return resources;
        }
    }
}
