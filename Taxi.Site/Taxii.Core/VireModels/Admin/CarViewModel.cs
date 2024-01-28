using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class CarViewModel
    {
        [Display(Name = " نام خودرو  ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")] 
        [MaxLength(100, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string Name { get; set; }
    }
}
