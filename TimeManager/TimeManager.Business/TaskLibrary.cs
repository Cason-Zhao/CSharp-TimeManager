using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Business
{
    /// <summary>
    /// 任务库
    /// </summary>
    public class TaskLibrary
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
        /// 类型
        /// </summary>
        public TaskLibraryTypeEnum Type { get; set; }

        /// <summary>
        /// 任务Id列表
        /// </summary>
        public List<string> TaskIdList { get; set; }
    }
}
