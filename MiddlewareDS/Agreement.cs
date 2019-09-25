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
        public static string GetEventCmd(T_Test1 cmdContent)
        {
            StringBuilder sbCmd = new StringBuilder();
            //sbCmd.Append("$");
            sbCmd.Append(cmdContent.NameT);
            //sbCmd.Append("|*|");
            return sbCmd.ToString();
        }
    }
}
