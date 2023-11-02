using DataAccess.Entities;
using Entities.EntitiesDto;

namespace DataAccess.Interfaces
{
    public interface IAccountService
    {
        Task<CustomResponse> Register(AccountDtoCreate account);
        Task<CustomResponse> Login(AccountDtoLogin account);
        Task<CustomResponse> Update(int accountKey, AccountDtoChangeable account);
        Task<CustomResponse> UpdateProfile(AccountDtoChangeable account);
        Task<CustomResponse> UpdatePassword(AccountDtoChangeable account);
        Task<CustomResponse> Delete(int accountKey);
        Task<CustomResponse> GetAccount(int accountKey);
        Task<CustomResponse> GetAccountAndCv(int accountKey);
        Account FindById(int? accountKey);
    }
}
