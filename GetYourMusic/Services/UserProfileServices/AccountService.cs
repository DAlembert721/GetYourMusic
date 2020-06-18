using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using GetYourMusic.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IDistrictRepository _districtRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountResponse> SaveAsync(AccountFactory account)
        {
            try
            {
                AccountFactory accountFactory = null;
                bool result = account.AccountType.Equals("Musician");
                if (result == true)
                {
                    accountFactory = new MusicianFactory();
                }
                else
                {
                    accountFactory = new OrganizerFactory();
                }
                Account newAccount = accountFactory.GetAccount();
                newAccount.FirstName = account.FirstName;
                newAccount.LastName = account.LastName;
                newAccount.Phone = account.Phone;
                newAccount.PersonalWeb = account.PersonalWeb;
                newAccount.BirthDate = account.BirthDate;
                newAccount.User = account.User;
                newAccount.RegisterDate = DateTime.Now;
                newAccount.AccountType = account.AccountType;
                int id = account.DistrictId;
                newAccount.District = await _districtRepository.FindById(id);
                await _accountRepository.AddAsync(newAccount); 
                await _unitOfWork.CompleteAsync();
                return new AccountResponse(newAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while saving the account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> GetByIdAsync(int id)
        {
            var existingAccount = await _accountRepository.FindById(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");
            return new AccountResponse(existingAccount);
        }
    }
}
