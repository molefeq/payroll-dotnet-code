using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class CompanyPayrollSettingTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompanyPayrollSetting>(entity =>
            {
                entity.ToTable("companypayrollsetting");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("companyid");

                entity.Property(e => e.DaysPerMonth)
                    .HasColumnName("dayspermonth")
                    .HasColumnType("numeric");

                entity.Property(e => e.HourPerWeek).HasColumnName("hourperweek");

                entity.Property(e => e.HoursPerDay).HasColumnName("hoursperday");

                entity.Property(e => e.MonthPeriods).HasColumnName("monthperiods");

                entity.Property(e => e.PayrollMessage).HasColumnName("payrollmessage");

                entity.Property(e => e.WeeklyPeriods).HasColumnName("weeklyperiods");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyPayrollSettings)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companypayrollsetting_company_companyid");
            });
        }
    }
}
