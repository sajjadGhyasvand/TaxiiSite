﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.DataLayer.Enum;

namespace Taxii.Core.VireModels.Panel
{
    public class DriverPanelViewModel
    {
        public TransactStatus Status { get; set; }

        public Guid? TransactId { get; set; }

        public Guid? DriverId { get; set; }

        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public string StartLat { get; set; }

        public string StartLng { get; set; }

        public string EndLat { get; set; }

        public string EndLng { get; set; }

        public long Price { get; set; }

        public string Desc { get; set; }
    }
}