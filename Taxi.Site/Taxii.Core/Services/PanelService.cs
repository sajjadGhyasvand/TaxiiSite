using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Context;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Services
{
    public class PanelService : IPanelService
    {
        private DataBaseContext _context;

        public PanelService(DataBaseContext context)
        {
            _context = context;
        }

        public PanelService()
        {
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public string GetRoleName(string userName)
        {
            return _context.Users.Include(u => u.Role).SingleOrDefault(u => u.UserName == userName).Role.Name;
        }

        public async Task<UserDetail> GetUserDetail(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.UserName == username);
        }

        public bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel)
        {
            UserDetail userDetail = _context.UserDetails.Find(id);
            if (userDetail != null)
            {
                userDetail.FullName = viewModel.FullName;
                userDetail.BirthDate = viewModel.BirthDate;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateFactor(Guid userid, string orderNumber, long price)
        {
            Factor factor = _context.Factors.SingleOrDefault(f => f.UserId == userid && f.BankName == null);

            if (factor != null)
            {
                factor.OrderNumber = orderNumber;
                factor.Price = Convert.ToInt32(price);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
        public void AddFactor(Factor factor)
        {
            _context.Factors.Add(factor);
            _context.SaveChanges();
        }
        public async Task<Factor> GetFactor(Guid id)
        {
            return await _context.Factors.FindAsync(id);
        }

        public Guid GetFactorById(string orderNumber)
        {
            return _context.Factors.SingleOrDefault(f => f.OrderNumber == orderNumber).Id;
        }
        public void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trace, string refId)
        {
            Factor factor = _context.Factors.Find(id);
            User user = _context.Users.Find(factor.UserId);

            factor.Date = DateTimeGenerators.GetShamsiDate();
            factor.Time = DateTimeGenerators.GetShamsiTime();
            factor.Desc = desc;
            factor.TraceNumber = trace;
            factor.BankName = bank;
            factor.RefNumber = refId;

            user.Wallet += factor.Price;

            _context.SaveChanges();
        }
    }
}
