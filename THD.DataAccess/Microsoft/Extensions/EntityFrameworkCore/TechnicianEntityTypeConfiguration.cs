using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using THD.DataAccess.Models;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class TechnicianEntityTypeConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(e => e.Name).HasMaxLength(128);
            b.Property(e => e.Alias).HasMaxLength(128);
            b.Property(e => e.Phone).HasMaxLength(50);
            b.Property(e => e.Email).HasMaxLength(50);
            b.Property(e => e.Password).HasMaxLength(150);
            b.Property(e => e.WorkExperienceFilePath).HasMaxLength(500);
            b.Property(e => e.Ask).HasMaxLength(500);
            b.Property(e => e.CreateTime).IsRequired().HasDefaultValueSql("GETDATE()");
            b.Property(e => e.UpdateTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETDATE()");

            b.HasIndex(e => e.Name);
        }
    }
}
