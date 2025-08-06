using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.Utilities
{
    public static class EnumUtility
    {
        public static List<string> GetNamesEnum<T>() where T : Enum 
        {
            var names = Enum.GetNames(typeof(T)).ToList();
            return names;
        }

        public static T ParseEnum<T>(string selected) where T : Enum 
        {
            var parsed = (T)Enum.Parse(typeof(T), selected);
            return parsed;
        }
    }
}
