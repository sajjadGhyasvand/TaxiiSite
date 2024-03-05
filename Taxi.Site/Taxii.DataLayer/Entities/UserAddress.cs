﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = "نام یا عنوان")]
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [Display(Name = "طول جغرافیایی")]
        [Required]
        [MaxLength(20)]
        public string Lat { get; set; }

        [Display(Name = "عرض جغرافیایی")]
        [Required]
        [MaxLength(20)]
        public string Lng { get; set; }

        [Display(Name = "آدرس")]
        [Required]
        public string Desc { get; set; }

        public virtual User User { get; set; }
    }
}