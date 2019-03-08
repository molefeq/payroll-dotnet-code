using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class AllowanceTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.ToTable("allowance", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.allowance_id_seq'::regclass)");

                entity.Property(e => e.TaxPercentage)
                    .HasColumnName("tax_percentage")
                    .HasColumnType("numeric");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(100);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.HasSequence<int>("allowance_id_seq");
        }
    }
}
