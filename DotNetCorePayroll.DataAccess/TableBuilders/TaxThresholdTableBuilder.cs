using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class TaxThresholdTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TaxThreshold>(entity =>
            {
                entity.ToTable("tax_threshold", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.tax_threshold_id_seq'::regclass)");

                entity.Property(e => e.MaximumAge).HasColumnName("maximum_age");

                entity.Property(e => e.MinimumAge).HasColumnName("minimum_age");

                entity.Property(e => e.ThresholdAmount)
                    .HasColumnName("threshold_amount")
                    .HasColumnType("money");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.HasSequence<int>("tax_threshold_id_seq");
        }
    }
}
