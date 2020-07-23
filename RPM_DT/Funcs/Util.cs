using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_DT.Funcs
{
    static  public class Util
    {
        static public string getDate(object obj)
        {
            if (obj is DateTime dt)
            {
                return dt.ToShortDateString();
            }
            else
            {
                return "";
            }
        }
    }
}
