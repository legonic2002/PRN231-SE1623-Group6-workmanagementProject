using DataAccess.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Entities.EntitiesDto;
using DataAccess.Helpers;

namespace DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly WorkManagementStableContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(WorkManagementStableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Delete(int accountKey)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(accountKey);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                }
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return -1;
            }
        }

        public Account FindById(int? accountKey)
        {
            return _context.Accounts.Find(accountKey);
        }

        public async Task<AccountDtoDisplay?> GetAccount(int accountKey)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(accountKey);
                return _mapper.Map<AccountDtoDisplay>(account);
            }
            catch
            {
                return null;
            }
        }

        public async Task<AccountDtoApplied?> GetAccountAndCv(int accountKey)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(accountKey);
                return _mapper.Map<AccountDtoApplied>(account);
            }
            catch
            {
                return null;
            }
        }

        public async Task<AccountDtoDisplay?> Login(AccountDtoLogin account)
        {
            try
            {
                var result = await _context.Accounts
                    .Where(a => a.Email.Equals(account.Email)
                            && a.Password.Equals(EncryptPassword.Encrypt(account.Password)))
                    .FirstOrDefaultAsync();
                return _mapper.Map<AccountDtoDisplay>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<AccountDtoDisplay?> Register(AccountDtoCreate account)
        {
            try
            {
                if (!account.Password.Equals(account.ConfirmPassword))
                {
                    return null;
                }
                foreach (var acc in _context.Accounts)
                {
                    if (acc.Email == account.Email)
                    {
                        return null;
                    }
                }
                var newAccount = _mapper.Map<Account>(account);
                newAccount.Password = EncryptPassword.Encrypt(newAccount.Password);
                await _context.Accounts.AddAsync(newAccount);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<AccountDtoDisplay>(newAccount);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<AccountDtoDisplay?> Update(int accountKey, AccountDtoChangeable account)
        {
            try
            {
                if (account.NewPassword != null && !account.NewPassword.Equals(account.ConfirmNewPassword))
                {
                    return null;
                }
                var oldAccount = await _context.Accounts.FindAsync(accountKey);
                if (oldAccount != null)
                {
                    if (!EncryptPassword.Encrypt(account.OldPassword!).Equals(oldAccount.Password))
                    {
                        return null;
                    }
                    var updatedAccount = _mapper.Map<Account>(account);
                    foreach (var prop in updatedAccount.GetType().GetProperties())
                    {
                        if (prop.GetValue(updatedAccount) == null || prop.GetValue(updatedAccount)!.ToString()!.Trim().Equals(""))
                        {
                            prop.SetValue(updatedAccount, prop.GetValue(oldAccount));
                        }
                    }
                    if (account.NewPassword != null && !account.NewPassword.Equals(""))
                    {
                        updatedAccount.Password = EncryptPassword.Encrypt(updatedAccount.Password);
                    }
                    _context.Entry(oldAccount).CurrentValues.SetValues(updatedAccount);
                    if (_context.Entry(oldAccount).State == EntityState.Unchanged)
                    {
                        return _mapper.Map<AccountDtoDisplay>(oldAccount);
                    }
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return _mapper.Map<AccountDtoDisplay>(updatedAccount);
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<AccountDtoDisplay?> UpdatePassword(AccountDtoChangeable account)
        {
            try
            {
                if (account.NewPassword != null && !account.NewPassword.Equals(account.ConfirmNewPassword))
                {
                    return null;
                }
                var oldAccount = await _context.Accounts.FindAsync(account.AccountKey);
                if (oldAccount != null)
                {
                    if (!EncryptPassword.Encrypt(account.OldPassword!).Equals(oldAccount.Password))
                    {
                        return null;
                    }               
                    if (account.NewPassword != null && !account.NewPassword.Equals(""))
                    {
                        oldAccount.Password = EncryptPassword.Encrypt(account.NewPassword);
                    }
                    _context.Update(oldAccount);
                    _context.SaveChanges();
                    return _mapper.Map<AccountDtoDisplay>(oldAccount);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<AccountDtoDisplay?> UpdateProfile(AccountDtoChangeable account)
        {
            var oldAccount = await _context.Accounts.FindAsync(account.AccountKey);
            if (oldAccount != null)
            {
                oldAccount.Email = account.Email;
                oldAccount.FirstName = account.FirstName;
                oldAccount.LastName = account.LastName;
                _context.Update(oldAccount);
                _context.SaveChanges();
                return _mapper.Map<AccountDtoDisplay>(oldAccount);
            }
            return null;
        }
    }
}
