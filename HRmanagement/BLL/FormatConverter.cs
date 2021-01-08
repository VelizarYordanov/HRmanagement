using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL
{
    public static class FormatConverter
    {
        public static string MySqlDateFormat = "yyyy/MM/dd";
        public static string StandardDateFormat = "dd.MM.yyyy";
        public static string ConvertToMySqlDateString(DateTime Date)
        {
            return Date.ToString(MySqlDateFormat);
        }
    }
}
