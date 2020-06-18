using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.UserProfileSystem
{
    public class Follow
    {
        public int FollowerId { get; set; }
        public Musician Follower { get; set; }

        public int FollowedId { get; set; }
        public Musician Followed { get; set; }
    }
}
