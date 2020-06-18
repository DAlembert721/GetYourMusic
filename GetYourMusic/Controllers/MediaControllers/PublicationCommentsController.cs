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
    [Route("/api/publication/{publicationId}/comments")]
    public class PublicationCommentsController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public PublicationCommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CommentResource>> GetAllByPublicationIdAsync(int publicationId)
        {
            var comments = await _commentService.ListByPublicationIdAsync(publicationId);
            var resources = _mapper
                .Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return resources;
        }
    }
}
