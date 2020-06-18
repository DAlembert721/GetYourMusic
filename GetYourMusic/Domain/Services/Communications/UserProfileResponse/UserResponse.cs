using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message) { }

        public UserResponse(User user) : base(user) { }
    }
}
