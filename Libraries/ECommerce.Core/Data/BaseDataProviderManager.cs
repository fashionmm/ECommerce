using System;

namespace ECommerce.Core.Data
{
    /// <summary>
    /// 数据提供者管理器抽象类
    /// </summary>
    public abstract class BaseDataProviderManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="settings">Data settings</param>
        protected BaseDataProviderManager(DataSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            this.Settings = settings;
        }

        /// <summary>
        /// 获取或设置设置对象
        /// </summary>
        protected DataSettings Settings { get; private set; }

        /// <summary>
        /// 加载数据提供者接口
        /// </summary>
        /// <returns>Data provider</returns>
        public abstract IDataProvider LoadDataProvider();
    }
}
