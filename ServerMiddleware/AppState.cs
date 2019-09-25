using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMiddleware
{
    public enum AppState
    {
        /// <summary>
        /// 启动中
        /// </summary>
        Starting,
        /// <summary>
        /// 启动完成/运行中
        /// </summary>
        Started,
        /// <summary>
        /// 暂停中
        /// </summary>
        Stoping,
        /// <summary>
        /// 停止
        /// </summary>
        Stoped,
        /// <summary>
        /// 异常
        /// </summary>
        Error
    }
}
