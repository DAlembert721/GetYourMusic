using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IFollowRepository
    {
        Task<IEnumerable<Follow>> ListByFollowerIdAsync(int followerId);
        Task<IEnumerable<Follow>> ListByFollowedIdAsync(int followedId);
        Task<Follow> FindByFollowerIdAndFollowedId(int followerId, int followedId);
        Task AddAsync(Follow follow);
        void Remove(Follow follow);
        Task AssignFollow(int followerId, int followedId);
        void UnassignFollow(int followerId, int followedId);
    }
}
