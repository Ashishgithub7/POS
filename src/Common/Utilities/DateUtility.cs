using POS.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.Utilities
{
    public static class DateUtility
    {
        public static string FormatDate(this DateTime date, string format = Others.Format)
        {
            return date.ToString(format);
        }
        
        public static string FormatDate(this DateTime? date, string format = Others.Format)
        {
            if (date.HasValue) 
            {
             return date.Value.ToString(format);
            }
            return null;
        }


    }
}
