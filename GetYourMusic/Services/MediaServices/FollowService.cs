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
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        public readonly IUnitOfWork _unitOfWork;

        public FollowService(IFollowRepository followRepository, IUnitOfWork unitOfWork)
        {
            _followRepository = followRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Follow>> ListByFollowerIdAsync(int followerId)
        {
            return await _followRepository.ListByFollowerIdAsync(followerId);
        }

        public async Task<IEnumerable<Follow>> ListByFollowedAsync(int followedId)
        {
            return await _followRepository.ListByFollowedIdAsync(followedId);
        }

        public async Task<FollowResponse> AssignFollowerFollowedAsync(int followerId, int followedId)
        {
            try
            {
                await _followRepository.AssignFollow(followerId, followedId);
                await _unitOfWork.CompleteAsync();
                Follow follow = await _followRepository.FindByFollowerIdAndFollowedId(followerId, followedId);
                return new FollowResponse(follow);
            }
            catch (Exception ex)
            {
                return new FollowResponse($"An error ocurred while assigning Follower to Followed: {ex.Message}");
            }
        }

        public async Task<FollowResponse> UnassignFollowerFollowedAsync(int followerId, int followedId)
        {
            try
            {
                Follow follow = await _followRepository.FindByFollowerIdAndFollowedId(followerId, followedId);
                _followRepository.Remove(follow);
                await _unitOfWork.CompleteAsync();
                return new FollowResponse(follow);
            }
            catch (Exception ex)
            {
                return new FollowResponse($"An error ocurred while unassigning Follower to Followed: {ex.Message}");
            }
        }
    }
}
