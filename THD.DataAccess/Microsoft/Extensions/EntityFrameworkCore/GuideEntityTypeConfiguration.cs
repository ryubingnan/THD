using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class GuideEntityTypeConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();

            b.Property(e => e.Title).HasMaxLength(150);
            b.Property(e => e.Type).HasMaxLength(50);
            b.Property(e => e.Price).HasDefaultValue(0);
            b.Property(e => e.PriceNew).HasDefaultValue(0);
            b.Property(e => e.Area).HasMaxLength(50);
            b.Property(e => e.Info).HasMaxLength(500);
            b.Property(e => e.Contents).HasMaxLength(int.MaxValue);
            b.Property(e => e.Info1).HasMaxLength(500);
            b.Property(e => e.Info2).HasMaxLength(500);
            b.Property(e => e.Info3).HasMaxLength(500);
            b.Property(e => e.Info4).HasMaxLength(500);
            b.Property(e => e.Info5).HasMaxLength(500);
            b.Property(e => e.Info6).HasMaxLength(500);
            b.Property(e => e.Info7).HasMaxLength(500);
            b.Property(e => e.Info8).HasMaxLength(500);
            b.Property(e => e.Info9).HasMaxLength(500);
            b.Property(e => e.Info10).HasMaxLength(500);
            b.Property(e => e.Img1).HasMaxLength(500);
            b.Property(e => e.Img2).HasMaxLength(500);
            b.Property(e => e.Img3).HasMaxLength(500);
            b.Property(e => e.Img4).HasMaxLength(500);
            b.Property(e => e.Img5).HasMaxLength(500);
            b.Property(e => e.Img6).HasMaxLength(500);
            b.Property(e => e.Img7).HasMaxLength(500);
            b.Property(e => e.Img8).HasMaxLength(500);
            b.Property(e => e.Img9).HasMaxLength(500);
            b.Property(e => e.Img10).HasMaxLength(500);
            b.Property(e => e.Datein).HasMaxLength(50);
            b.Property(e => e.Pid).HasMaxLength(150);
            b.Property(e => e.Map).HasMaxLength(500);
            b.Property(e => e.Video).HasMaxLength(500);
            b.Property(e => e.Supplier).HasMaxLength(500);
            b.Property(e => e.Features).HasMaxLength(int.MaxValue);
            b.Property(e => e.Category).HasMaxLength(50);
            b.Property(e => e.IsDelete).HasDefaultValue(false);
        }
    }
}
