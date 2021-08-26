using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransMe
{
    class Settings
    {
        public static string GetOrDefault(string key, string deft)
        {
            var got = System.Configuration.ConfigurationManager.AppSettings.Get(key);
            if (string.IsNullOrEmpty(got))
            {
                return deft;
            }
            return got;           

        }

        public static int GetOrDefaultInt(string key, int deft)
        {
            var got = System.Configuration.ConfigurationManager.AppSettings.Get(key);
            if (string.IsNullOrEmpty(got))
            {
                return deft;
            }
            int n;
            if(int.TryParse(got, out n))
            {
                return n;
            }
            return deft;

        }
    }
}
