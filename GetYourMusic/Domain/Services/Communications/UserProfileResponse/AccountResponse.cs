using GetYourMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class AccountResponse : BaseResponse<Account>
    {
        public AccountResponse(string message) : base(message) { }

        public AccountResponse(Account account) : base(account) { }
    }
}
