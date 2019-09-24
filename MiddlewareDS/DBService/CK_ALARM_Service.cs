using MiddlewareDS.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiddlewareDS.DBService
{
    public class CK_ALARM_Service: DbContext<CK_ALARM>, IRepository<CK_ALARM>
    {

    }
}
