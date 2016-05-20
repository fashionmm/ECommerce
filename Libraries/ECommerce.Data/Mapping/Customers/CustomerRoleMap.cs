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
        }
    }
}
