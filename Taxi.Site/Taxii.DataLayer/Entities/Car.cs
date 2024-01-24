﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Display(Name = "  نام خودرو ")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Driver> Drivers { get; set; }

    }
}
