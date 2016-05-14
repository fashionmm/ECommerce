using Autofac;
using ECommerce.Core.Configuration;

namespace ECommerce.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// 依赖注册接口
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, EConfig config);

        /// <summary>
        /// 依赖注册实现顺序号
        /// </summary>
        int Order { get; }
    }
}
