using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class TransactRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public Guid TransactId { get; set; }

        public Guid RateTypeId { get; set; }


        #region Relations
        public virtual Transact Transact { get; set; }
        public virtual RateType RateType { get; set; }

        #endregion

    }
}
