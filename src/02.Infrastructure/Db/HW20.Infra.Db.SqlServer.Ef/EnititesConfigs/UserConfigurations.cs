using HW20.Domain.Core.Entities;
using HW20.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Db.SqlServer.Ef.EnititesConfigs
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).HasMaxLength(50);
            builder.Property(u => u.PasswordHash).HasMaxLength(100).IsRequired();

            builder.HasData(new User { Id = 1 , CreatedAt = new DateTime(2025, 10, 11, 14, 30, 0), PasswordHash = "1234".ToMd5Hex(), Username = "Admin"});
        }
    }
}
