using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Business
{
    /// <summary>
    /// 时间片类型枚举
    /// </summary>
    public enum TimeSliceTypeEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,
        /// <summary>
        /// 中断
        /// </summary>
        [Description("中断")]
        Break,
    }
}
