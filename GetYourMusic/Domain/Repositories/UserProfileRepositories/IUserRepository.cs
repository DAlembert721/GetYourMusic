using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> FindById(int id);
        Task<User> Authenticate(string email, string password);
        void Remove(User user);
    }
}
