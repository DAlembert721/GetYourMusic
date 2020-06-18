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
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Search search)
        {
            await _context.Searches.AddAsync(search);
        }

        public async Task<IEnumerable<Search>> ListByAccountIdAsync(int accountId)
        {
            return await _context.Searches
                .Where(a => a.AccountId == accountId)
                .ToListAsync();
        }
    }
}
