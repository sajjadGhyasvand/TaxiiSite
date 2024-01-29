using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class ColorViewModel
    {
        [Display(Name = " نام رنگ  ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string Name { get; set; }
        [Display(Name = " کد رنگ  ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string ColorCode { get; set; }
    }
}
