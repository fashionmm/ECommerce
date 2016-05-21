using ECommerce.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Mapping.Customers
{
    public class CustomerRoleMap : ECommerceEntityTypeConfiguration<CustomerRole>
    {
        public CustomerRoleMap()
        {
            this.ToTable("CustomerRole");
            this.HasKey(r=>r.Id);
            this.Property(r=>r.Name).IsRequired().HasMaxLength(255);
            this.Property(r => r.SystemName).HasMaxLength(255);
          
        }
    }
}
