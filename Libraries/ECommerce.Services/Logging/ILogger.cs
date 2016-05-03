using System;
using System.Collections.Generic;
using ECommerce.Core;
using ECommerce.Core.Domain.Customers;
using ECommerce.Core.Domain.Logging;

namespace ECommerce.Services.Logging
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public partial interface ILogger
    {
        /// <summary>
        /// 确定是否启用日志级别
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <returns>Result</returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// 删除日志项
        /// </summary>
        /// <param name="log">Log item</param>
        void DeleteLog(Log log);

        /// <summary>
        /// 清除日志
        /// </summary>
        void ClearLog();

        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <param name="fromUtc">日志项目创建开始日期; 为空加载所有记录</param>
        /// <param name="toUtc">日志项目创建截止日期; 为空加载所有记录</param>
        /// <param name="message">信息</param>
        /// <param name="logLevel">日志级别;为空加载所有记录</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页页面大小</param>
        /// <returns>Log item items</returns>
        IPagedList<Log> GetAllLogs(DateTime? fromUtc = null, DateTime? toUtc = null,
            string message = "", LogLevel? logLevel = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 根据ID获取日志
        /// </summary>
        /// <param name="logId">日志ID</param>
        /// <returns>日志</returns>
        Log GetLogById(int logId);

        /// <summary>
        /// 根据多个ID批量获取日志
        /// </summary>
        /// <param name="logIds">日志ID数组</param>
        /// <returns>日志列表</returns>
        IList<Log> GetLogByIds(int[] logIds);

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="shortMessage">简讯</param>
        /// <param name="fullMessage">完整信息</param>
        /// <param name="customer">顾客关联日志记录</param>
        /// <returns>A log item</returns>
        Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null);
    }
}
