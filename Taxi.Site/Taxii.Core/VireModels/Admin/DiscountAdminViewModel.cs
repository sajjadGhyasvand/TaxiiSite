using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class DiscountAdminViewModel
    {
        [Display(Name = "  عنوان تخفیف ")]
        [Required(ErrorMessage ="نباید بدون مقدار باشد")]
        [MaxLength(100,ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "  کد تخفیف  ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Code { get; set; }
        [Display(Name = "  مبلغ تخفیف   ")]
        public long? Price { get; set; }
        [Display(Name = "  درصد تخفیف   ")]
        public int? Percent { get; set; }
        [Display(Name = "  توضیحات   ")]
        public string? Description { get; set; }
        [Display(Name = "  تاریخ شروع  ")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Start { get; set; }
        [Display(Name = "  تاریخ انقضا  ")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string? Expire { get; set; }
    }
}
