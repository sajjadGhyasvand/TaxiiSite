using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class PriceTypeViewModel
    {
        [Display(Name = "  عنوان تعرفه ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Name { get; set; }
        [Display(Name = "  از مسافت  ")]
        public int Start { get; set; }
        [Display(Name = "  تا مسافت ")]
        public int End { get; set; }
        [Display(Name = "  نرخ ثابت  ")]
        public long Price { get; set; }
    }
}
