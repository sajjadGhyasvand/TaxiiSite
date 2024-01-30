using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class RateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Display(Name = "  گزینه امتیاز  ")]
        public string? Name { get; set; }
        [Display(Name = "   مثبت ")]
        public bool OK { get; set; }
        [Display(Name = "  ترتیب نمایش ")]
        public int? ViewOrder { get; set; }
    }
}
