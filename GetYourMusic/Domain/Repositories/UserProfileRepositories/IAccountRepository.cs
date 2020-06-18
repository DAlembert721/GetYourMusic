using GetYourMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task<Account> FindById(int id);
    }
}
