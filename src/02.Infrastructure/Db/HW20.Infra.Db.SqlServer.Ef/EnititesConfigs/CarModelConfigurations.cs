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
    public class CarModelConfigurations : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasMany(m => m.Cars)
                .WithOne(c => c.Model)
                .HasForeignKey(c => c.ModelId);

            builder.Property(c => c.Name).HasMaxLength(120);

            builder.HasData(
                new CarModel { Id = 1, Name = "پژو ۴۰۵" },
                new CarModel { Id = 2, Name = "سمند ال‌ایکس" },
                new CarModel { Id = 3, Name = "دنا پلاس" },
                new CarModel { Id = 4, Name = "پراید ۱۳۱" },
                new CarModel { Id = 5, Name = "کوییک R" },
                new CarModel { Id = 6, Name = "تیبا ۲" },
                new CarModel { Id = 7, Name = "پژو ۲۰۶" },
                new CarModel { Id = 8, Name = "پژو ۲۰۷" }
            );

        }
    }
}
