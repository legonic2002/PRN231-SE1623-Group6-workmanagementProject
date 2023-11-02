using Microsoft.AspNetCore.Mvc;
using DataAccess.Interfaces;
using DataAccess;
using Entities.EntitiesDto;
using System.Text;
using DataAccess.Services;

namespace WorkManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountKey}")]
        public async Task<CustomResponse> GetAccount(int accountKey)
        {
            return await _accountService.GetAccount(accountKey);
        }

        [HttpGet("accountAndCv/{accountKey}")]
        public async Task<CustomResponse> GetAccountAndCv(int accountKey)
        {
            return await _accountService.GetAccountAndCv(accountKey);
        }

        [HttpPut]
        public async Task<CustomResponse> PutAccount(AccountDtoChangeable account)
        {
            return await _accountService.UpdateProfile(account);
        }

        [HttpPut("pass")]
        public async Task<CustomResponse> PutAccountPass(AccountDtoChangeable account)
        {
            return await _accountService.UpdatePassword(account);
        }

        [HttpPost]
        public async Task<CustomResponse> PostAccount(AccountDtoCreate account)
        {
            return await _accountService.Register(account);
        }

        [HttpDelete("{accountKey}")]
        public async Task<CustomResponse> DeleteAccount(int accountKey)
        {
            return await _accountService.Delete(accountKey);
        }

        [HttpPost("login")]
        public async Task<CustomResponse> Login([FromBody] AccountDtoLogin account)
        {
            var response = await _accountService.Login(account);
            if (response.Data != null)
            {
                AccountDtoDisplay accDTO = (AccountDtoDisplay) response.Data;
               HttpContext.Session.SetInt32("AccountKey", accDTO.AccountKey);
               HttpContext.Session.SetString("Role", accDTO.Role);
				HttpContext.Session.SetString("UserName", accDTO.FirstName + " " + accDTO.LastName);
            }
            return response;
        }

        [HttpPost("logout")]
        public async Task<CustomResponse> Logout()
        {
            HttpContext.Session.Clear();
            return await Task.FromResult(new CustomResponse
            {
                Success = true,
                StatusCode = 200,
                Message = "Logout successfully"
            });
        }
        [HttpPost("reset")]
        public async Task<CustomResponse> Reset()
        {
            int? userId = HttpContext.Session.GetInt32("AccountKey");
            var response = await _accountService.GetAccount(userId.Value);
            if (response.Data != null)
            {
                AccountDtoDisplay accDTO = (AccountDtoDisplay)response.Data;
                HttpContext.Session.SetString("UserName", accDTO.FirstName + " " + accDTO.LastName);
            }
            return await Task.FromResult(new CustomResponse
            {
                Success = true,
                StatusCode = 200,
                Message = "Reset successfully"
            });
        }
    }
}
