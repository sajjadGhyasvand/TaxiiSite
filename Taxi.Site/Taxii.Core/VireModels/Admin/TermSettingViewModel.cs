using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.VireModels.Admin
{
    public class TermSettingViewModel
    {
        [Display(Name = " شرایط و قوانین")]
        public string? Terms { get; set; }
    }
}
