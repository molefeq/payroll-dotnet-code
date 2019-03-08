using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class UifTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uif>(entity =>
            {
                entity.ToTable("uif", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.uif_id_seq'::regclass)");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("date");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("date");

                entity.Property(e => e.MaximumAmount)
                    .HasColumnName("maximum_amount")
                    .HasColumnType("money");

                entity.Property(e => e.UifPercent)
                    .HasColumnName("uif_percent")
                    .HasColumnType("numeric");
            });

            modelBuilder.HasSequence<int>("uif_id_seq");
        }
    }
}
