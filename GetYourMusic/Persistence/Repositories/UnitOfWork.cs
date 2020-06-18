using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
