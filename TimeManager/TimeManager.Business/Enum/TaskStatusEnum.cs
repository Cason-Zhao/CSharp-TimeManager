using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Business
{
    /// <summary>
    /// 任务状态
    /// </summary>
    public enum TaskStatusEnum
    {
        /// <summary>
        /// 创建状态
        /// </summary>
        [Description("创建")]
        Created = 0,
        /// <summary>
        /// 执行中
        /// </summary>
        [Description("执行中")]
        Running,
        /// <summary>
        /// 暂停
        /// </summary>
        [Description("暂停")]
        Stop,
        /// <summary>
        /// 完成
        /// </summary>
        [Description("完成")]
        Complete,
        /// <summary>
        /// 中止
        /// </summary>
        [Description("中止")]
        Abort,
        /// <summary>
        /// 中止
        /// </summary>
        [Description("删除")]
        Delete,
    }

}
