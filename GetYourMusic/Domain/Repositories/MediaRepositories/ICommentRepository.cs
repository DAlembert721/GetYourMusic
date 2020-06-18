using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task<Comment> FindById(int id);
        Task AddAsync(Comment comment);
        void Update(Comment comment);
        void Remove(Comment comment);
    }
}
