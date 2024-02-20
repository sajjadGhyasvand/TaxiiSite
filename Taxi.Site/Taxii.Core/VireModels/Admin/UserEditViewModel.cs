using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class UserEditViewModel
    {
        [Display(Name = " نقش کاربر ")]
        public Guid RoleId { get; set; }
        [Display(Name = "  شماره موبایل")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد ")]
        [MaxLength(11, ErrorMessage = "مقدار{0} نباید بیشتر از {1} کاراکتر باشد.")]
        [MinLength(11, ErrorMessage = "مقدار{0} نباید کمتر از {1} کاراکتر باشد.")]
        [Phone(ErrorMessage = "شماره همراه معتبر وارد نمایید")]
        public string UserName { get; set; }

        [Display(Name = " فعال/غیرفعال")]
        public bool IsActive { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد ")]
        [MaxLength(100)]
        public string? FullName { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد ")]
        [MaxLength(10)]
        public string? BirthDate { get; set; }
    }
}
