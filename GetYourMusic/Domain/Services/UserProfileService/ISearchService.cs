using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<Search>> ListByAccountIdAsync(int accountId);
        Task<SearchResponse> SaveAsync(Search search);
    }
}
