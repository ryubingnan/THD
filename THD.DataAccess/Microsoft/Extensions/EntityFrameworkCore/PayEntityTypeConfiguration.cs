using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    public class PayEntityTypeConfiguration : IEntityTypeConfiguration<Pay>
    {
        public void Configure(EntityTypeBuilder<Pay> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();

            b.Property(e => e.PayId).HasMaxLength(150);
            b.Property(e => e.Status).HasMaxLength(50);
            b.Property(e => e.PayType).HasMaxLength(50);
            b.Property(e => e.PayDate).HasMaxLength(50);
            b.Property(e => e.AllTotalPrice).HasMaxLength(50);
            b.Property(e => e.UserId).HasMaxLength(50);
            b.Property(e => e.Datein).HasMaxLength(50);
            b.Property(e => e.FromWhere).HasMaxLength(50);
        }
    }
}
