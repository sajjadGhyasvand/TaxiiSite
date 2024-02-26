using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Interfaces;

namespace Taxii.Core.Scope
{
    
    public class SiteLayoutScope
    {
        private IPanelService _panelService;

        public SiteLayoutScope(IPanelService panelService)
        {
            _panelService=panelService;
        }

        public string GetUserRole(string userName)
        {
            return _panelService.GetRoleName(userName);
        }
    }
}
