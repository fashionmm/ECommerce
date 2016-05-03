using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Mapping.Customers
{
    public partial class CustomerMap : ECommerceEntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(c => c.Id);
            this.Property(c=>c.UserName).HasMaxLength(200);
            this.Property(c => c.Email).HasMaxLength(200);
            this.Property(c => c.SystemName).HasMaxLength(100);

        }
    }
}
