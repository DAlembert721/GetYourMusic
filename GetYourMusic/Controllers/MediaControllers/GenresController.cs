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
    public class GenresController: Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GenreResource>> GetAllAsync()
        {
            var genres = await _genreService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
            return resources;
        }
    }
}
