using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.DataLayer.Enum;

namespace Taxii.Core.VireModels.Panel
{
    public class DashboardViewModel
    {
        public TransactStatus Status { get; set; }

        public Guid? TransactId { get; set; }

        public Guid? DriverId { get; set; }

        public Guid? UserId { get; set; }
    }
}
