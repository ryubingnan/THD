using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class FoodEntityTypeConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();

            b.Property(e => e.Title).HasMaxLength(150);
            b.Property(e => e.Type).HasMaxLength(50);
            b.Property(e => e.Price).HasDefaultValue(0);
            b.Property(e => e.PriceNew).HasDefaultValue(0);
            b.Property(e => e.Area).HasMaxLength(50);
            b.Property(e => e.Info).HasMaxLength(int.MaxValue);
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
            b.Property(e => e.Info11).HasMaxLength(500);
            b.Property(e => e.Info12).HasMaxLength(500);
            b.Property(e => e.Info13).HasMaxLength(500);
            b.Property(e => e.Info14).HasMaxLength(500);
            b.Property(e => e.Info15).HasMaxLength(500);
            b.Property(e => e.Info16).HasMaxLength(500);
            b.Property(e => e.Info17).HasMaxLength(500);
            b.Property(e => e.Info18).HasMaxLength(500);
            b.Property(e => e.Info19).HasMaxLength(500);
            b.Property(e => e.Info20).HasMaxLength(500);
            b.Property(e => e.Img1).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img2).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img3).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img4).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img5).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img6).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img7).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img8).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img9).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img10).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img11).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img12).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img13).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img14).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img15).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img16).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img17).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img18).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img19).HasMaxLength(int.MaxValue);
            b.Property(e => e.Img20).HasMaxLength(int.MaxValue);
            b.Property(e => e.Datein).HasMaxLength(50);
            b.Property(e => e.Pid).HasMaxLength(150);
            b.Property(e => e.Map).HasMaxLength(int.MaxValue);
            b.Property(e => e.Video).HasMaxLength(int.MaxValue);
            b.Property(e => e.Supplier).HasMaxLength(50);
            b.Property(e => e.Features).HasMaxLength(int.MaxValue);
            b.Property(e => e.Category).HasMaxLength(50);
            b.Property(e => e.IsDelete).HasDefaultValue(false);
        }
    }
}
