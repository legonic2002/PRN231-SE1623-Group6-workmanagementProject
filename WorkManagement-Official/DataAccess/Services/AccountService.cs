using DataAccess.Interfaces;
using DataAccess.Entities;
using System.Net;
using Entities.EntitiesDto;

namespace DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CustomResponse> Delete(int accountKey)
        {
            var result = await _accountRepository.Delete(accountKey);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Data = null,
                    Message = "Account deleted successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Account not deleted.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public Account FindById(int? accountKey)
        {
            return _accountRepository.FindById(accountKey);
        }

        public async Task<CustomResponse> GetAccount(int accountKey)
        {
            var result = await _accountRepository.GetAccount(accountKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Account found.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Account not found.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetAccountAndCv(int accountKey)
        {
            var result = await _accountRepository.GetAccountAndCv(accountKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Account found.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Account not found.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> Login(AccountDtoLogin account)
        {
            var result = await _accountRepository.Login(account);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Login succesfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Login fail.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> Register(AccountDtoCreate account)
        {
            var result = await _accountRepository.Register(account);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Register succesfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Register fail.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> Update(int accountKey, AccountDtoChangeable account)
        {
            var result = await _accountRepository.Update(account.AccountKey, account);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Account updated successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Account not updated.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> UpdatePassword(AccountDtoChangeable account)
        {
            var result = await _accountRepository.UpdatePassword(account);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Account updated successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Account not updated.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> UpdateProfile(AccountDtoChangeable account)
        {
            var result = await _accountRepository.UpdateProfile( account);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Account updated successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Account not updated.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }
    }
}
