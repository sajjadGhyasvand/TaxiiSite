using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Interfaces
{
    public interface IPanelService : IDisposable
    {
        Task<UserDetail> GetUserDetail(string username);
        string GetRoleName(string userName);
        bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel);
    }
}
