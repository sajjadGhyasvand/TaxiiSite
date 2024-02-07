using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class RoleViewModel
    {
        [Display(Name = " عنوان سیستمی نقش   ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string Name { get; set; }
        [Display(Name = "  عنوان نمایشی نقش   ")]
        [Required(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string Title { get; set; }
    }
}
