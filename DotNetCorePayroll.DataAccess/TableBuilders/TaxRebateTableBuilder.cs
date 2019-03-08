using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class TaxRebateTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRebate>(entity =>
            {
                entity.ToTable("tax_rebate", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.tax_rebate_id_seq'::regclass)");

                entity.Property(e => e.MaximumAge).HasColumnName("maximum_age");

                entity.Property(e => e.MinimumAge).HasColumnName("minimum_age");

                entity.Property(e => e.RebateAmount)
                    .HasColumnName("rebate_amount")
                    .HasColumnType("money");

                entity.Property(e => e.RebateDescription)
                    .IsRequired()
                    .HasColumnName("rebate_description")
                    .HasMaxLength(500);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.HasSequence<int>("tax_rebate_id_seq");
        }
    }
}
