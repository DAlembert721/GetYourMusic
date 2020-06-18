using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task<CommentResponse> SaveAsync(Comment comment);
        Task<CommentResponse> UpdateAsync(int id, Comment comment);
        Task<CommentResponse> DeleteAsync(int id);
    }
}
