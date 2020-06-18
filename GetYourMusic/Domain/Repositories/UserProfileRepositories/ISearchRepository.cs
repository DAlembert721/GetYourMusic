using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface ISearchRepository
    {
        Task<IEnumerable<Search>> ListByAccountIdAsync(int accountId);
        Task AddAsync(Search search);

    }
}
