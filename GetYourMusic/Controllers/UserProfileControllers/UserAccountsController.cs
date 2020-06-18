using AutoMapper;
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services;
using GetYourMusic.Extensions;
using GetYourMusic.Resources;
using GetYourMusic.Test;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Controllers
{
    [Route("/api/users/{userId}/accounts")]
    public class UserAccountsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserAccountsController(IUserService userService, IAccountService accountService, IMapper mapper)
        {
            _userService = userService;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int userId, [FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var existingUser = await _userService.GetByIdAsync(userId);

            if (!existingUser.Success)
                return BadRequest(existingUser.Message);

            var account = _mapper.Map<SaveAccountResource, AccountFactory>(resource);
            account.User = existingUser.Resource;

            var result = await _accountService.SaveAsync(account);

            if (!result.Success)
                return BadRequest(result.Message);

            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            return Ok(accountResource);
        }
    }
}
