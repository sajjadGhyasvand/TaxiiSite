using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Scope
{
    public class TransactScope
    {
        private IAdminService _admniService;

        public TransactScope(IAdminService admniService)
        {
            _admniService = admniService;
        }
        public User GetUserById(Guid id)
        {
            return _admniService.GetUserById(id).Result;
        }
    }
}
