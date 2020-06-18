using GetYourMusic.Domain.Models.UserProfileSystem;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using GetYourMusic.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            // TODO: Implement Repository-base behavior
            var user = await _userRepository.Authenticate(request.Email, request.Password);

            // Return when user not found
            if (user == null) return null;

            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            // Setup Security Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Account.AccountType)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the event user: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingPerformer = await _userRepository.FindById(id);

            if (existingPerformer == null)
                return new UserResponse("User not found");

            try
            {
                _userRepository.Remove(existingPerformer);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingPerformer);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error has ocurred while deleting user: {ex.Message}");
            }
        }
    }
}
