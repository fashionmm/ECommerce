using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public abstract class ECommerceEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected ECommerceEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }
    }
}
