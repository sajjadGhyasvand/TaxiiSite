using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Display(Name = "  عنوان تخفیف ")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name = "  کد تخفیف  ")]
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
        [Display(Name = "  مبلغ تخفیف   ")]
        public long? Price { get; set; }
        [Display(Name = "  درصد تخفیف   ")]
        public int? Percent { get; set; }
        [Display(Name = "  توضیحات   ")]
        public string? Description { get; set; }
        [Display(Name = "  تاریخ شروع  ")]
        [MaxLength(10)]
        public string? Start { get; set; }
        [Display(Name = "  تاریخ انقضا  ")]
        [MaxLength(10)]
        public string? Expire { get; set; }
    }
}
