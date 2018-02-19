using DotNetCorePayroll.Data;

using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class AddressBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("countryid");

                entity.Property(e => e.Line1)
                    .IsRequired()
                    .HasColumnName("line1");

                entity.Property(e => e.Line2).HasColumnName("line2");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.PostalCode).HasColumnName("postalcode");

                entity.Property(e => e.ProvinceId).HasColumnName("provinceid");

                entity.Property(e => e.Suburb)
                    .IsRequired()
                    .HasColumnName("suburb");
            });
        }
    }
}
