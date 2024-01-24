using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public Guid? CarId { get; set; }
        public Guid? ColorId { get; set; }
        [Display(Name = " کد ملی   ")]
        public string? NationalCOde { get; set; }
        [Display(Name = " شماره ثابت  ")]
        public string? Tel { get; set; }
        [Display(Name = " آدرس  ")]
        public string? Address { get; set; }
        [Display(Name = "  تصویر گواهینامه  ")]
        public string? CarImg { get; set; }
        [Display(Name = "  تصویر راننده  ")]
        public string? Avatar { get; set; }
        [Display(Name = "  شماره پلاک ")]
        [MaxLength(30)]
        public string? CarCode { get; set; }
        public bool IsConfirm { get; set; }
        public virtual User User { get; set; }
        public virtual Car Car { get; set; }
        public virtual Color Color { get; set; }

    }
}
