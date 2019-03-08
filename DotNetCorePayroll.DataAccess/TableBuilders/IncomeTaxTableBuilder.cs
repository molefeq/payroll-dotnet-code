using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class IncomeTaxTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IncomeTax>(entity =>
            {
                entity.ToTable("income_tax", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.income_tax_id_seq'::regclass)");

                entity.Property(e => e.MaximumIncome)
                    .HasColumnName("maximum_income")
                    .HasColumnType("money");

                entity.Property(e => e.MinimumIncome)
                    .HasColumnName("minimum_income")
                    .HasColumnType("money");

                entity.Property(e => e.SlidingScale)
                    .HasColumnName("sliding_scale")
                    .HasColumnType("money");

                entity.Property(e => e.MinimumTaxableAmount)
                    .HasColumnName("minimum_taxable_amount")
                    .HasColumnType("money");

                entity.Property(e => e.TaxPercentage)
                    .HasColumnName("tax_percentage")
                    .HasColumnType("numeric");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.HasSequence<int>("income_tax_id_seq");
        }
    }
}
