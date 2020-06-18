using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class SearchService:ISearchService
    {
        readonly private ISearchRepository _searchRepository;
        readonly public IUnitOfWork _unitOfWork;

        public SearchService(ISearchRepository searchRepository, IUnitOfWork unitOfWork)
        {
            _searchRepository = searchRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Search>> ListByAccountIdAsync(int accountId)
        {
            return await _searchRepository.ListByAccountIdAsync(accountId);
        }

        public async Task<SearchResponse> SaveAsync(Search search)
        {
            try
            {
                await _searchRepository.AddAsync(search);
                await _unitOfWork.CompleteAsync();

                return new SearchResponse(search);
            }
            catch (Exception ex)
            {
                return new SearchResponse($"An error ocurred while saving the search: {ex.Message}");
            }
        }
    }
}
