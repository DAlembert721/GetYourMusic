using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommentResponse> DeleteAsync(int id)
        {
            var existingComment = await _commentRepository.FindById(id);

            if (existingComment == null)
                return new CommentResponse("Comment not found");

            try
            {
                _commentRepository.Remove(existingComment);
                await _unitOfWork.CompleteAsync();

                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while deleting a comment: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId)
        {
            return await _commentRepository.ListByPublicationIdAsync(publicationId);
        }

        public async Task<CommentResponse> SaveAsync(Comment comment)
        {
            try
            {
                await _commentRepository.AddAsync(comment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while saving the comment: {ex.Message}");
            }
        }

        public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _commentRepository.FindById(id);

            if (existingComment == null)
                return new CommentResponse("Comment not found");

            existingComment.Text = comment.Text;

            try
            {
                _commentRepository.Update(existingComment);
                await _unitOfWork.CompleteAsync();

                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while updating comment: {ex.Message}");
            }
        }
    }
}
