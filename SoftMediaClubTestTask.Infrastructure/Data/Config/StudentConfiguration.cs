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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Firstname)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(p => p.Lastname)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(p => p.Middlename)
                .HasMaxLength(128);
            builder.HasOne(p => p.AcademicPerformanceType)
                .WithMany(p => p.Students)
                .HasForeignKey(p => p.AcademicPerformanceTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.HasQueryFilter(p => !p.DeleteDate.HasValue);
        }
    }
}
