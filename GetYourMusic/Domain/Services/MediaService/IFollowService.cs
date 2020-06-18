using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IFollowService
    {
        Task<IEnumerable<Follow>> ListByFollowerIdAsync(int followerId);
        Task<IEnumerable<Follow>> ListByFollowedAsync(int followedId);
        Task<FollowResponse> AssignFollowerFollowedAsync(int followerId, int followedId);
        Task<FollowResponse> UnassignFollowerFollowedAsync(int followerId, int followedId);
    }
}
