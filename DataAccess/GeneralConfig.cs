using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public  static class GeneralConfig
    {
        public static string Connstring { get; set; }

        internal static Context DBContext = new Context();

        static GeneralConfig()
        {
        }
    }
}
