using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services.Communications;
using GetYourMusic.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IAccountService
    {
        Task<AccountResponse> SaveAsync(AccountFactory account);
        Task<AccountResponse> GetByIdAsync(int id);
    }
}
