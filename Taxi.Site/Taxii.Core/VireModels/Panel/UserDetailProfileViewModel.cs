using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Panel
{
    public class UserDetailProfileViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100,ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "{0} نباید بدون مقدار باشد")]
        public string FullName { get; set; }
        [Display(Name = "تاریخ تولد")]
        [MaxLength(10)]
        public string BirthDate { get; set; }
    }
}
