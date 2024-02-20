using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class DriverCarViewModel
    {
        public Guid? CarId { get; set; }
        public Guid? ColorId { get; set; }
        [Display(Name = "  شماره پلاک")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد ")]
        public  string CarCode { get; set; }
    }
}
