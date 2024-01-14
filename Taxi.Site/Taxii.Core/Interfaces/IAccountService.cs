using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.VireModels;
using Taxii.DataLayer.Entities;
namespace Taxii.Core.Interfaces
{
    public interface IAccountService : IDisposable
    {
        bool CheckMobileNumber(string userName);
        Task<User> RegisterUser(RegisterViewModel viewModel);
        Guid GetRoleByName(string name);
        Task<User> GetUser(string userName);
        void UpdateUserPassword(Guid Id, string code);
    }
}
