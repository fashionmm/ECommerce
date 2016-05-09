using ECommerce.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace ECommerce.Core.Infrastructure
{
    /// <summary>
    /// 提供访问的ECommerce engine单体实例。
    /// </summary>
    public class EngineContext
    {
        #region Methods

        /// <summary>
        /// 初始化EC工厂静态实例。
        /// </summary>
        /// <param name="forceRecreate">是否重新创建。创建一个新工厂实例，即使工厂已被初始化。</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                Singleton<IEngine>.Instance = new ECEngine();

                var config = ConfigurationManager.GetSection("NopConfig") as NopConfig;
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        ///将静态引擎实例设置为所提供的引擎。使用此方法来提供您的引擎实现。
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>如果你知道你在做什么，就用这种方法。</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 获取E单例引擎，用于访问E服务
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }

}
