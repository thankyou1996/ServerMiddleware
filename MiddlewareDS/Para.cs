using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiddlewareDS
{
    public static class Para
    {
        /// <summary>
        /// 事件数据库连接字符串
        /// </summary>
        public static string EventDBConnectStr
        {
            get;
            set;
        }


        /// <summary>
        /// 服务器地址
        /// </summary>
        public static string ServerAddress
        {
            get;
            set;
        }


        /// <summary>
        /// 服务器端口
        /// </summary>
        public static ushort ServerPort
        {
            get;
            set;
        }
    }
}
