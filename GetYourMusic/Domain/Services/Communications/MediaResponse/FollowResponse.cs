using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{ 
    public class FollowResponse : BaseResponse<Follow>
    {
        public FollowResponse(string message) : base(message) { }

        public FollowResponse(Follow follow) : base(follow) { }
    }
}
