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
    public class FollowRepository : BaseRepository, IFollowRepository
    {
        public FollowRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Follow follow)
        {
            await _context.Follows.AddAsync(follow);
        }

        public async Task AssignFollow(int followerId, int followedId)
        {
            Follow follow = await FindByFollowerIdAndFollowedId(followerId, followedId);
            if (follow == null)
            {
                follow = new Follow { FollowerId = followerId, FollowedId = followedId};
                await AddAsync(follow);
            }
        }

        public async Task<Follow> FindByFollowerIdAndFollowedId(int followerId, int followedId)
        {
            return await _context.Follows.FindAsync(followerId, followedId);
        }

        public async Task<IEnumerable<Follow>> ListByFollowedIdAsync(int followedId)
        {
            return await _context.Follows
                .Where(f => f.FollowedId == followedId)
                .Include(f => f.Follower)
                .Include(f => f.Followed)
                .ToListAsync();
        }

        public async Task<IEnumerable<Follow>> ListByFollowerIdAsync(int followerId)
        {
            return await _context.Follows
                .Where(f => f.FollowerId == followerId)
                .Include(f => f.Follower)
                .Include(f => f.Followed)
                .ToListAsync();
        }

        public void Remove(Follow follow)
        {
            _context.Follows.Remove(follow);
        }

        public async void UnassignFollow(int followerId, int followedId)
        {
            Follow follow = await FindByFollowerIdAndFollowedId(followerId, followedId);
            if (follow != null)
            {
                Remove(follow);
            }
        }
    }
}
