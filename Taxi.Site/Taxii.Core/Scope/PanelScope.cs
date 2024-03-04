using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Interfaces;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Scope
{
    public class PanelScope
    {
        private readonly IPanelService _panelService;

        public PanelScope(IPanelService panelService)
        {
            _panelService = panelService;
        }

        public User GetUser(Guid id)
        {
            return _panelService.GetUserById(id);
        }
        public Driver GetDriver(Guid id)
        {
            return _panelService.GetDriverById(id);
        }
    }
}
