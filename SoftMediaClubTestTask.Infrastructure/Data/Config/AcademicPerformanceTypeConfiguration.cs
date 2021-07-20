using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftMediaClubTestTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Infrastructure.Data.Config
{
    public class AcademicPerformanceTypeConfiguration : IEntityTypeConfiguration<AcademicPerformanceType>
    {
        public void Configure(EntityTypeBuilder<AcademicPerformanceType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Code)
                .HasMaxLength(128)
                .IsRequired();
            builder.HasIndex(p => p.Code)
                .IsUnique();

            var seedData = new List<AcademicPerformanceType>
            {
                new AcademicPerformanceType
                {
                    Id = 1,
                    Code = "A",
                    Description = "Отлично"
                },
                new AcademicPerformanceType
                {
                    Id = 2,
                    Code = "B",
                    Description = "Хорошо"
                },
                new AcademicPerformanceType
                {
                    Id = 3,
                    Code = "С",
                    Description = "Удовлетворительно",
                },
                new AcademicPerformanceType
                {
                    Id = 4,
                    Code = "D",
                    Description = "Неудовлетворительно",
                }
            };
            builder.HasData(seedData);
        }
    }
}
