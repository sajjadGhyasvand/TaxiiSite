using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
