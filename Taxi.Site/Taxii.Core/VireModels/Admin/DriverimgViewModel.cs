using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class DriverimgViewModel
    {
        [Display(Name = "تایید")]
        public bool IsConfirm { get; set; }
        [Display(Name = "تصویر گواهینامه")]
        public IFormFile Img { get; set; }
        public string ImgNAme { get; set; }
    }
}
