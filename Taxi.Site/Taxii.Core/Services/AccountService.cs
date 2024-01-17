using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.Securities;
using Taxii.Core.Senders;
using Taxii.Core.VireModels;
using Taxii.DataLayer.Context;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataBaseContext _context;

        public AccountService(DataBaseContext context)
        {
            _context = context;
        }

        public bool CheckMobileNumber(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public Guid GetRoleByName(string name)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == name).Id;
        }

        public async Task<User> GetUser(string userName)
        {
            return await Task.FromResult(_context.Users.SingleOrDefault(u => u.UserName == userName));
        }

        public async Task<User> RegisterUser(RegisterViewModel viewModel)
        {
            if (!CheckMobileNumber(viewModel.UserName))
            {
                //TODO => فقط ارسال پیامک فعالسازی
                User user = new User()
                {
                    IsActive = false,
                    Id = CodeGenerators.GetId(),
                    Password = HashEncode.GetHashCode(HashEncode.GetHashCode(CodeGenerators.GetActiveCode())),
                    RoleId = GetRoleByName("user"),
                    Token = null,
                    UserName = viewModel.UserName
                };
                _context.Users.Add(user);
                UserDetail userDetail = new UserDetail()
                {
                    UserId = user.Id,
                    BirthDate = null,
                    Date = DateTimeGenerators.GetShamsiDate(),
                    Time = DateTimeGenerators.GetShamsiTime(),
                    FullName = null,
                };
                _context.UserDetails.Add(userDetail);
                _context.SaveChanges();
                try
                {
                    SmsSender.VerifySend(user.UserName, "", user.Password);
                }
                catch (Exception)
                {

                    throw;
                }
                return await Task.FromResult(user);
            }
            else
            {
                User user = await GetUser(viewModel.UserName);
                string code = CodeGenerators.GetActiveCode();
                UpdateUserPassword(user.Id, code);
                try
                {
                    SmsSender.VerifySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }
                return await Task.FromResult(user);
            }

        }

        public void UpdateUserPassword(Guid Id, string code)
        {
            User user = _context.Users.Find(Id);
            user.Password = HashEncode.GetHashCode(CodeGenerators.GetActiveCode());
            _context.SaveChanges();
        }
    }
}
