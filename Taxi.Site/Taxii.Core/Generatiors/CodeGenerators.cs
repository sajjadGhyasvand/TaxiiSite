using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics.Contracts;
namespace Taxii.Core.Generatiors
{
    public class CodeGenerators
    {
        public static  string GetActiveCode() 
        {
            Random random = new();
            return random.Next(100000,990000).ToString();
        }
        public static Guid GetId()
        {
            return Guid.NewGuid();
        }
        
        public static string GetFileName()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }

        public static string GetOrderCode()
        {
            Random random = new();
            return random.Next(10000000, 99000000).ToString();
        }
    }
}
