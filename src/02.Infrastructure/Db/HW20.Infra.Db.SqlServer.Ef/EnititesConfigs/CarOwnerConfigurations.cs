using HW20.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Db.SqlServer.Ef.EnititesConfigs
{
    public class CarOwnerConfigurations : IEntityTypeConfiguration<CarOwner>
    {
        public void Configure(EntityTypeBuilder<CarOwner> builder)
        {
            builder.Property(o => o.Address).HasMaxLength(1000);
            builder.Property(o => o.Phone).HasMaxLength(11);
            builder.Property(o => o.IdentityCode).HasMaxLength(10);

            builder.HasMany(o => o.Cars)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
