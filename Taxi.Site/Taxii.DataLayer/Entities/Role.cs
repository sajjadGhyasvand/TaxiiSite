using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Display(Name = " نقش سیستمی")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Display(Name = " نقش ")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        #region Relations
        public virtual ICollection<User> User { get; set; }
        
        #endregion
    }
}
