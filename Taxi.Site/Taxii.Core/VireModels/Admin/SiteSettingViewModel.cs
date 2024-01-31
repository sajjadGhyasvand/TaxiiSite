using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class SiteSettingViewModel
    {
        [Display(Name = "  نام  ")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        public string? Name { get; set; }
        [Display(Name = "  توضیحات  ")]
        [DataType(DataType.MultilineText)]
        public string? Desc { get; set; }
        [Display(Name = " شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Tel { get; set; }
        [Display(Name = "شماره فکس")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Fax { get; set; }
    }
}
