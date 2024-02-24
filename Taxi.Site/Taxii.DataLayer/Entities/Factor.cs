using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class Factor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "تاریخ")]
        [MaxLength(10)]
        public string? Date { get; set; }
        [Display(Name = "  تاریخ پرداخت  ")]
        public string? Time { get; set; }
        [Display(Name = "شماره سفارش")]
        [MaxLength(8)]
        public long? OrderNumber { get; set; }
        [Display(Name = "  مبلغ ")]
        public int? Price  { get; set; }
        [Display(Name = "درگاه")]
        [MaxLength(30)]
        public string? BankName { get; set; }
        [Display(Name = "  شماره پیگیری ")]
        [MaxLength(50)]
        public string? RefNumber { get; set; }
        [Display(Name = "  شماره مرجع ")]
        [MaxLength(50)]
        public string? TraceNumber  { get; set; }

        public virtual User User { get; set; }
    }
}
