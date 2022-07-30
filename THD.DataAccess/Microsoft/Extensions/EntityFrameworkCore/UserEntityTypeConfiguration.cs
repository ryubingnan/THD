using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Extensions.EntityFrameworkCore
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(e => e.UserName).IsRequired().HasMaxLength(128);
            b.Property(e => e.Password).IsRequired().HasMaxLength(128);
            b.Property(e => e.Name).HasMaxLength(128);
            b.Property(e => e.Phone).HasMaxLength(20);
            b.Property(e => e.Email).HasMaxLength(128);
            b.Property(e => e.EmailConfirmed).HasDefaultValue(false);
            b.Property(e => e.EmailConfirmeToken).HasMaxLength(128);
            b.Property(e => e.Gender);
            b.Property(e => e.Country).HasMaxLength(50);
            b.Property(e => e.Address).HasMaxLength(150);
            b.Property(e => e.QQ).HasMaxLength(150);
            b.Property(e => e.WeChat).HasMaxLength(150);
            b.Property(e => e.CreateTime).IsRequired().HasDefaultValueSql("GETDATE()");
            b.Property(e => e.UpdateTime).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETDATE()");
            b.Property(e => e.Type).HasMaxLength(50);
            b.Property(e => e.Identity).HasMaxLength(50);
            b.Property(e => e.Point).HasDefaultValue(0);
            b.Property(e => e.Pic).HasMaxLength(500);
            b.Property(e => e.GSMC).HasMaxLength(500);
            b.Property(e => e.GSDH).HasMaxLength(500);
            b.Property(e => e.GSYX).HasMaxLength(500);
            b.Property(e => e.GSCZ).HasMaxLength(500);
            b.Property(e => e.GSDZ).HasMaxLength(500);
            b.Property(e => e.IsDelete).HasDefaultValue(0);

            b.HasIndex(e => e.UserName);

            b.HasData(new User
            {
                Id = 1,
                UserName = "Admin",
                Password = "123456"
            });
        }
    }
}
