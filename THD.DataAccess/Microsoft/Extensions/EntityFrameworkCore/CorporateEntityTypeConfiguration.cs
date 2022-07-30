using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class CorporateEntityTypeConfiguration : IEntityTypeConfiguration<Corporate>
    {
        public void Configure(EntityTypeBuilder<Corporate> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();

            b.Property(e => e.ContentsofInquiry).HasMaxLength(150);
            b.Property(e => e.FirstName).HasMaxLength(50);
            b.Property(e => e.LastName).HasMaxLength(50);
            b.Property(e => e.Surname).HasMaxLength(50);
            b.Property(e => e.Mei).HasMaxLength(50);
            b.Property(e => e.BirthDate);
            b.Property(e => e.Phone).HasMaxLength(50);
            b.Property(e => e.Email).HasMaxLength(50);
            b.Property(e => e.ErrorCode).HasMaxLength(50);
            b.Property(e => e.ProposalNumber).HasMaxLength(50);
            b.Property(e => e.Content).HasMaxLength(500);
        }
    }
}
