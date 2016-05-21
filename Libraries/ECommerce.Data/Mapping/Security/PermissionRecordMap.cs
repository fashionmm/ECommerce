using ECommerce.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Mapping.Security
{
    public partial class PermissionRecordMap : ECommerceEntityTypeConfiguration<PermissionRecord>
    {
        public PermissionRecordMap()
        {
            this.ToTable("PermissionRecord");
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.SystemName).IsRequired().HasMaxLength(255);
            this.Property(p => p.Category).IsRequired().HasMaxLength(255);

            this.HasMany(p => p.CustomerRoles)
                .WithMany(c => c.PermissionRecords)
                .Map(m => m.ToTable("PermissionRecord_Role"));
        }
    }
}
