namespace ECommerce.Core.Infrastructure
{
    /// <summary>
    /// 应在启动时执行任务的接口
    /// </summary>
    public interface IStartupTask 
    {
        /// <summary>
        /// 执行一个任务
        /// </summary>
        void Execute();

        /// <summary>
        /// 顺序
        /// </summary>
        int Order { get; }
    }
}
