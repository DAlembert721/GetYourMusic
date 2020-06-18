using GetYourMusic.Domain.Persistence.Contexts;

namespace GetYourMusic.Persistence
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context; 
        
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
