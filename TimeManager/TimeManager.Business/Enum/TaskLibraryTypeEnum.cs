using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Business
{
    public enum TaskLibraryTypeEnum
    {
        /// <summary>
        /// 回收站
        /// </summary>
        [Description("回收站")]
        Recycle,

        ///// <summary>
        ///// 完成库
        ///// </summary>
        //[Description("完成库")]
        //Complete,

        /// <summary>
        /// 短期库
        /// </summary>
        [Description("短期库")]
        Short,
        /// <summary>
        /// 常驻库
        /// </summary>
        [Description("常驻库")]
        Always,

        /// <summary>
        /// 执行库
        ///     当前正在进行或处于暂停状态
        /// </summary>
        [Description("执行库")]
        Execute,

        /// <summary>
        /// 执行库
        ///     当前正在进行或处于暂停状态
        /// </summary>
        [Description("常规库")]
        Routine,

        /// <summary>
        /// 自定义库
        /// </summary>
        [Description("自定义库")]
        Custom,
    }
}
