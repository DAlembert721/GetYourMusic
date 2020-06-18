using AutoMapper;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services;
using GetYourMusic.Extensions;
using GetYourMusic.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers.UserProfileControllers
{
    [Route("/api/accounts/{commenterId}/publications/{publicationId}/comments")]
    public class AccountPublicationCommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IAccountService _accountService;
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public AccountPublicationCommentsController(ICommentService commentService, IAccountService accountService, IPublicationService publicationService,IMapper mapper)
        {
            _commentService = commentService;
            _accountService = accountService;
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int commenterId, int publicationId, [FromBody] SaveCommentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var existingAccount = await _accountService.GetByIdAsync(commenterId);

            if (!existingAccount.Success)
                return BadRequest(existingAccount.Message);

            var existingPublication = await _publicationService.GetByIdAsync(publicationId);

            if (!existingPublication.Success)
                return BadRequest(existingPublication.Message);

            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            comment.Commenter = existingAccount.Resource;
            comment.Publication = existingPublication.Resource;

            var result = await _commentService.SaveAsync(comment);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCommentResource resource)
        {
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentService.UpdateAsync(id, comment);

            if (!result.Success)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _commentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
    }
}
