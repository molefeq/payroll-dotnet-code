using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class PensionFundTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PensionFund>(entity =>
            {
                entity.ToTable("pension_fund", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.pension_fund_id_seq'::regclass)");

                entity.Property(e => e.AnnualRemunerationPercent)
                    .HasColumnName("annual_remuneration_percent")
                    .HasColumnType("numeric");

                entity.Property(e => e.MaximumAmount)
                    .HasColumnName("maximum_amount")
                    .HasColumnType("money");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.HasSequence<int>("pension_fund_id_seq");
        }
    }
}
