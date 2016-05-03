using System;
using System.Collections.Generic;
using ECommerce.Core;
using ECommerce.Core.Domain.Customers;
using ECommerce.Core.Domain.Logging;

namespace ECommerce.Services.Logging
{
    /// <summary>
    /// ��־�ӿ�
    /// </summary>
    public partial interface ILogger
    {
        /// <summary>
        /// ȷ���Ƿ�������־����
        /// </summary>
        /// <param name="level">��־����</param>
        /// <returns>Result</returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// ɾ����־��
        /// </summary>
        /// <param name="log">Log item</param>
        void DeleteLog(Log log);

        /// <summary>
        /// �����־
        /// </summary>
        void ClearLog();

        /// <summary>
        /// ��ȡ������־
        /// </summary>
        /// <param name="fromUtc">��־��Ŀ������ʼ����; Ϊ�ռ������м�¼</param>
        /// <param name="toUtc">��־��Ŀ������ֹ����; Ϊ�ռ������м�¼</param>
        /// <param name="message">��Ϣ</param>
        /// <param name="logLevel">��־����;Ϊ�ռ������м�¼</param>
        /// <param name="pageIndex">��ҳ����</param>
        /// <param name="pageSize">��ҳҳ���С</param>
        /// <returns>Log item items</returns>
        IPagedList<Log> GetAllLogs(DateTime? fromUtc = null, DateTime? toUtc = null,
            string message = "", LogLevel? logLevel = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// ����ID��ȡ��־
        /// </summary>
        /// <param name="logId">��־ID</param>
        /// <returns>��־</returns>
        Log GetLogById(int logId);

        /// <summary>
        /// ���ݶ��ID������ȡ��־
        /// </summary>
        /// <param name="logIds">��־ID����</param>
        /// <returns>��־�б�</returns>
        IList<Log> GetLogByIds(int[] logIds);

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="logLevel">��־����</param>
        /// <param name="shortMessage">��Ѷ</param>
        /// <param name="fullMessage">������Ϣ</param>
        /// <param name="customer">�˿͹�����־��¼</param>
        /// <returns>A log item</returns>
        Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null);
    }
}
