using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> DeleteAsync(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}
