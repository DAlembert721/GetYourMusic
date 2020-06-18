
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Persistence.Contexts;
using GetYourMusic.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Persistence
{
    public class AccountRepository: BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }
        public async Task<Account> FindById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }
    }
}
