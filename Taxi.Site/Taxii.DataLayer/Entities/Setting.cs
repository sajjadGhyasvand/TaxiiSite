﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.DataLayer.Entities
{
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Display(Name = "  نام  ")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Name { get; set; }
        [Display(Name = "  توضیحات  ")]
        public string? Desc { get; set; }
        [Display(Name = "  درباره ما ")]
        public string? About { get; set; }
        [Display(Name = " شرایط و قوانین")]
        public string? Terms { get; set; }
        [Display(Name = " شماره تماس")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Tel { get; set; }
        [Display(Name = "شماره فکس")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نیاید بیشتر از {1} باشد")]
        public string? Fax { get; set; }
        [Display(Name = "  آب و هوا در قیمت  ")]
        public bool IsWeatherPrice { get; set; }
        [Display(Name = "   بعد مسافت در قیمت ")]
        public bool IsDistancePrice { get; set; }
    }
}
