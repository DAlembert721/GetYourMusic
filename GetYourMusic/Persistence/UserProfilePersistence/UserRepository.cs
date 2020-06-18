using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await _context.Users.Include(x => x.Account).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
