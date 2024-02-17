using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class DriverPropViewModel
    {
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کارکتر باشد ")]
        [Phone(ErrorMessage = "فقط عدد وارد کنید")]
        public string NationalCode { get; set; }
        [Display(Name = "شماره ثابت")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کارکتر باشد ")]
        public string Tel { get; set; }
        [Display(Name = "آدرس")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name = "تصویر راننده")]
        public string? AvatarName { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
