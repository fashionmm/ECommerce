using ECommerce.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Mapping.Common
{
    public partial class AddressMap : ECommerceEntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.ToTable("Address");
            this.HasKey(a=>a.Id);

            //this.HasOptional(a=>a.Country)
            //    .WithMany()
            //    .HasForeignKey(a=>a.CountryId)
            //    .WillCascadeOnDelete(false);

            //this.HasOptional(a => a.StateProvince)
            //    .WithMany()
            //    .HasForeignKey(a=>a.StateProvinceId)
            //    .WillCascadeOnDelete(false); 
        }
    }
}
