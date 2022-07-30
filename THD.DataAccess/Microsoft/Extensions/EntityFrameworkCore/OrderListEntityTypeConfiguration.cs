using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    public class OrderListEntityTypeConfiguration : IEntityTypeConfiguration<OrderList>
    {
        public void Configure(EntityTypeBuilder<OrderList> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();

            b.Property(e => e.Pid).HasMaxLength(150);
            b.Property(e => e.Img1).HasMaxLength(150);
            b.Property(e => e.Country).HasMaxLength(50);
            b.Property(e => e.Title).HasMaxLength(150);
            b.Property(e => e.Type).HasMaxLength(50);
            b.Property(e => e.Category).HasMaxLength(50);
            b.Property(e => e.Price);
            b.Property(e => e.Num);
            b.Property(e => e.TotalPrice);
            b.Property(e => e.Datein).HasMaxLength(50);
            b.Property(e => e.UserId).HasMaxLength(50);
            b.Property(e => e.Keyword).HasMaxLength(50);
            b.Property(e => e.PayId).HasMaxLength(150);
            b.Property(e => e.DateEnd).HasMaxLength(50);
            b.Property(e => e.DateStart).HasMaxLength(50);
        }
    }
}
