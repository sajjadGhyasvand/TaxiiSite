using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.Generatiors
{
    public static class ColorGenerators
    {
        public static string SelectColorCode()
        {
            string[] colors = { "#FF1493", "#6A5ACD", "#FA8072","#DC143C","#FF8C00","#3CB371","#20B2AA","#6495ED","#BC8F8F","#A52A2A",
             "#FDD493", "#6A43CD", "#FA80A5","#DC3B3C","#FF0000","#3CB001","#2F0AAA","#4495ED","#A48F8F","#A52B3A",};

            Random random = new Random();
            int index = random.Next(colors.Length);
            
            return colors[index]; 
        }
    }
}
