using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class RateTypeViewModel
    {
        [Display(Name = "  گزینه امتیاز  ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Name { get; set; }
        [Display(Name = "مثبت")]
        public bool? OK { get; set; }
        [Display(Name = "  ترتیب نمایش ")]
        public int? ViewOrder { get; set; }
    }
}
