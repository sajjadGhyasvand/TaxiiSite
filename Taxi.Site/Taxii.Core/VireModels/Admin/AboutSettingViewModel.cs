using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class AboutSettingViewModel
    {
        [Display(Name = "  درباره ما ")]
        [DataType(DataType.MultilineText)]
        public string? About { get; set; }
    }
}
