using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using TimeManager.Business.Util;

namespace TimeManager.Business
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Task
    {
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public TaskStatusEnum Status { get; set; }

        /// <summary>
        /// 完整时间片
        /// 任务首次开始时间、完成时间（中止时间）、执行时间
        /// </summary>
        public TimeSliceBasic WholeTimeSlice { get; set; }

        /// <summary>
        /// 执行过程
        ///     一段一段的执行记录
        /// </summary>
        public List<TimeSlice> TimeSlices { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        [JsonIgnore]
        public string StatusName { get { return this.Status.GetDescription(); } }

        /// <summary>
        /// 关联链接
        /// </summary>
        public List<LinkInfo> ReferLinkList { get; set; }

        /// <summary>
        /// 任务中止再启动时，需要基于中止的任务（ParentId）再创建新任务
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 关联人员列表
        /// （当前任务与哪些人有关，与那些人讨论）
        /// </summary>
        public List<PersonInfo> RelationPersonList { get; set; }
    }

    /// <summary>
    /// 时间片基础类
    /// </summary>
    public class TimeSliceBasic
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 执行时长
        /// </summary>
        public string ExecuteDuration { get; set; }

    }

    /// <summary>
    /// 时间片
    /// </summary>
    public class TimeSlice: TimeSliceBasic
    {
        /// <summary>
        /// 导致当前任务中断的任务Id
        /// </summary>
        public string BreakTaskId { get; set; }

        /// <summary>
        /// 时间片类型
        /// </summary>
        public TimeSliceTypeEnum SliceType { get; set; }
    }

    /// <summary>
    /// 链接信息类
    /// </summary>
    public class LinkInfo
    {
        public string URL { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    /// <summary>
    /// 人员信息
    /// </summary>
    public class PersonInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Tel { get; set; }

        public string EMail { get; set; }

        public string QQ { get; set; }

        public string Wechat { get; set; }
    }
}
