using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels
{
    public class RegisterViewModel
    {
        [Display(Name = "  شماره همراه ")]
        [Required(ErrorMessage = "لطفا شماره همراه معتبر وارد کنید.")]
        [MaxLength(11, ErrorMessage = "لطفا شماره همراه معتبر وارد کنید.")]
        [MinLength(11, ErrorMessage = "لطفا شماره همراه معتبر وارد کنید.")]
        [Phone(ErrorMessage = "لطفا شماره همراه معتبر وارد کنید.")]
        public string UserName { get; set; }
    }
}
