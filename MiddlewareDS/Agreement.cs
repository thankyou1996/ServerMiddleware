using MiddlewareDS.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareDS
{
    public class Agreement
    {
        public static string GetEventCmd(CK_ALARM evInfo)
        {
            StringBuilder sbCmd = new StringBuilder();
            sbCmd.Append("$");

            sbCmd.Append("|*|");
            return sbCmd.ToString();
        }
    }
}
