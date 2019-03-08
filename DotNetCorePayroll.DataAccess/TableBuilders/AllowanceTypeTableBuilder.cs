using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class AllowanceTypeTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowanceType>(entity =>
            {
                entity.ToTable("allowance_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });
        }
    }
}
