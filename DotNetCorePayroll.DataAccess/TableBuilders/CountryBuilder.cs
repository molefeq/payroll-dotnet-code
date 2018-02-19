using DotNetCorePayroll.Data;

using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class CountryBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasIndex(e => e.Code)
                    .HasName("ck_country_code")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

        }
    }
}
