using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class LookupTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("pk_lookup");

                entity.ToTable("lookup");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(100);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(100);
            });
        }
    }
}
