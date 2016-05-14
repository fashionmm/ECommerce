using ECommerce.Core.Configuration;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Core.Infrastructure.DependencyManagement;

namespace ECommerce.Core.Infrastructure
{
    /// <summary>
    /// 实现这个接口的类为各种服务构成NOP引擎门户。
    /// 编辑功能，通过该接口模块和实现访问大多数NOP功能。
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// 容器管理器
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// 初始化组件和插件
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(EConfig config);

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        ///  解析
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 解析所有
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }

}
