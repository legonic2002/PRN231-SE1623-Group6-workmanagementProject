using DataAccess.Entities;
using Entities.EntitiesDto;

namespace DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountDtoDisplay?> Register(AccountDtoCreate account);
        Task<AccountDtoDisplay?> Login(AccountDtoLogin account);
        Task<AccountDtoDisplay?> Update(int accountKey, AccountDtoChangeable account);
        Task<AccountDtoDisplay?> UpdateProfile(AccountDtoChangeable account);
        Task<AccountDtoDisplay?> UpdatePassword(AccountDtoChangeable account);
        Task<int> Delete(int accountKey);
        Task<AccountDtoDisplay?> GetAccount(int accountKey);
        Task<AccountDtoApplied?> GetAccountAndCv(int accountKey);
        Account FindById(int? accountKey);
    }
}
