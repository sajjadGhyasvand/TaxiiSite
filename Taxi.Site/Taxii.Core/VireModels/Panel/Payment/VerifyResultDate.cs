using System;
using System.Collections.Generic;
using System.Text;

namespace Taxii.Core.VireModels.Panel.Payment
{
    public class VerifyResultDate
    {
        public int ResCode { get; set; }
        public string Decription { get; set; }
        public string Amount { get; set; }
        public string RetrivalRefNo { get; set; }
        public string SystemTraceNo { get; set; }
        public string OrderId { get; set; }
    }
}
