using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context){}

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task<Comment> FindById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId) =>
            await _context.Comments
            .Where(a => a.PublicationId == publicationId)
            .Include(a => a.Publication)
            .ToListAsync();

        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }
    }
}
