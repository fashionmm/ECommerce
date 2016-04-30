using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using ECommerce.Data.Mapping;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //禁用延迟加载，默认为启用。
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            //动态加载所有配置
            //

            //动态获取对象类型
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null &&
                    type.BaseType.IsGenericType &&
                    type.BaseType.GetGenericTypeDefinition() == typeof(ECommerceEntityTypeConfiguration<>)
                    );

            //动态注册实体类型配置
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);

                modelBuilder.Configurations.Add(configurationInstance);
            }

            // 或者可以手动直接添加
           // modelBuilder.Configurations.Add(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
