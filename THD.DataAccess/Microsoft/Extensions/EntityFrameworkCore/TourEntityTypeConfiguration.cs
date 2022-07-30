using THD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class TourEntityTypeConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();

            b.Property(e => e.Title).HasMaxLength(150);
            b.Property(e => e.Type).HasMaxLength(50);
            b.Property(e => e.Area).HasMaxLength(50);
            b.Property(e => e.Days).HasMaxLength(50);
            b.Property(e => e.Contents).HasMaxLength(500);
            b.Property(e => e.Img1).HasMaxLength(1000);
            b.Property(e => e.Img2).HasMaxLength(1000);
            b.Property(e => e.Img3).HasMaxLength(1000);
            b.Property(e => e.Img4).HasMaxLength(1000);
            b.Property(e => e.Img5).HasMaxLength(1000);
            b.Property(e => e.Img6).HasMaxLength(1000);
            b.Property(e => e.Img7).HasMaxLength(1000);
            b.Property(e => e.Img8).HasMaxLength(1000);
            b.Property(e => e.Img9).HasMaxLength(1000);
            b.Property(e => e.Img10).HasMaxLength(1000);
            b.Property(e => e.Img11).HasMaxLength(1000);
            b.Property(e => e.Img12).HasMaxLength(1000);
            b.Property(e => e.Img13).HasMaxLength(1000);
            b.Property(e => e.Img14).HasMaxLength(1000);
            b.Property(e => e.Img15).HasMaxLength(1000);
            b.Property(e => e.Img16).HasMaxLength(1000);
            b.Property(e => e.Img17).HasMaxLength(1000);
            b.Property(e => e.Img18).HasMaxLength(1000);
            b.Property(e => e.Img19).HasMaxLength(1000);
            b.Property(e => e.Img20).HasMaxLength(1000);
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
            b.Property(e => e.Map).HasMaxLength(int.MaxValue);
            b.Property(e => e.Video).HasMaxLength(150);
            b.Property(e => e.Url).HasMaxLength(150);
            b.Property(e => e.ReleaseDate).HasMaxLength(150);
            b.Property(e => e.Pid).HasMaxLength(150);
            b.Property(e => e.StartDate).HasMaxLength(150);
            b.Property(e => e.StartPlace).HasMaxLength(150);
            b.Property(e => e.Country).HasMaxLength(int.MaxValue);
            b.Property(e => e.Features).HasMaxLength(int.MaxValue);
            b.Property(e => e.Supplier).HasMaxLength(150);
            b.Property(e => e.Day1).HasMaxLength(50);
            b.Property(e => e.Day2).HasMaxLength(50);
            b.Property(e => e.Day3).HasMaxLength(50);
            b.Property(e => e.Day4).HasMaxLength(50);
            b.Property(e => e.Day5).HasMaxLength(50);
            b.Property(e => e.Day6).HasMaxLength(50);
            b.Property(e => e.Day7).HasMaxLength(50);
            b.Property(e => e.Day8).HasMaxLength(50);
            b.Property(e => e.Day9).HasMaxLength(50);
            b.Property(e => e.Day10).HasMaxLength(50);
            b.Property(e => e.Day11).HasMaxLength(50);
            b.Property(e => e.Day12).HasMaxLength(50);
            b.Property(e => e.Day13).HasMaxLength(50);
            b.Property(e => e.Day14).HasMaxLength(50);
            b.Property(e => e.Day15).HasMaxLength(50);
            b.Property(e => e.Day16).HasMaxLength(50);
            b.Property(e => e.Day17).HasMaxLength(50);
            b.Property(e => e.Day18).HasMaxLength(50);
            b.Property(e => e.Day19).HasMaxLength(50);
            b.Property(e => e.Day20).HasMaxLength(50);
            b.Property(e => e.Category).HasMaxLength(50);
            b.Property(e => e.IsDelete).HasDefaultValue(false);
        }
    }
}
