using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels
{
    public class ActiveViewModel
    {
        [Display(Name = "  کد فعال سازی  ")]
        [Required(ErrorMessage = "لطفا  کد فعال سازی 6 رقمی همراه معتبر وارد کنید.")]
        [MaxLength(6, ErrorMessage = "لطفا  کد فعال سازی 6 رقمی همراه معتبر وارد کنید.")]
        [MinLength(6, ErrorMessage = "لطفا  کد فعال سازی 6 رقمی همراه معتبر وارد کنید.")]
        [Phone(ErrorMessage = "لطفا  کد فعال سازی 6 رقمی همراه معتبر وارد کنید.")]
        public  string Code { get; set; }
    }
}
