using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class ItListInfoEntityTypeConfiguration : IEntityTypeConfiguration<ItListInfo>
    {
        public void Configure(EntityTypeBuilder<ItListInfo> b)
        {
            b.Property(e => e.Title).HasMaxLength(150);
            b.Property(e => e.Period).HasMaxLength(150);
            b.Property(e => e.Area).HasMaxLength(150);
            b.Property(e => e.Type).HasMaxLength(150);
            b.Property(e => e.Price).HasMaxLength(150);
            b.Property(e => e.Category).HasMaxLength(150);
            b.Property(e => e.Language).HasMaxLength(150);
            b.Property(e => e.Characteristics).HasMaxLength(150);
            b.Property(e => e.Contents).HasMaxLength(150);
            b.Property(e => e.Human).HasMaxLength(150);
            b.Property(e => e.Commitment).HasMaxLength(150);
            b.Property(e => e.Others).HasMaxLength(150);
            b.Property(e => e.user).HasMaxLength(150);
            b.Property(e => e.update).HasMaxLength(150);
        }
    }
}
