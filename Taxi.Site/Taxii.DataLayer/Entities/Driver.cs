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
        [Display(Name = " کد ملی   ")]
        public string NationalCOde { get; set; }
        [Display(Name = " شماره ثابت  ")]
        public string Tel { get; set; }
        [Display(Name = " آدرس  ")]
        public string Address { get; set; }


        public virtual User User { get; set; }

    }
}
