using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class EmployeeCompanyDetailTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCompanyDetail>(entity =>
            {
                entity.ToTable("employeecompanydetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnnualLeaveType)
                    .IsRequired()
                    .HasColumnName("annualleavetype")
                    .HasMaxLength(50);

                entity.Property(e => e.BasicSalary)
                    .HasColumnName("basicsalary")
                    .HasColumnType("money");

                entity.Property(e => e.ContractEndDate)
                    .HasColumnName("contractenddate")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.DateOfEngagement)
                    .HasColumnName("dateofengagement")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeid");

                entity.Property(e => e.EmployementType)
                    .IsRequired()
                    .HasColumnName("employementtype")
                    .HasMaxLength(50);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("jobtitle")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifyDate).HasColumnName("modify_date");

                entity.Property(e => e.ModifyUserId).HasColumnName("modify_user_id");

                entity.Property(e => e.OtherAllowance)
                    .HasColumnName("otherallowance")
                    .HasColumnType("money");

                entity.Property(e => e.PayrollDay).HasColumnName("payrollday");

                entity.Property(e => e.SupervisorId).HasColumnName("supervisorid");

                entity.Property(e => e.TravelAllowance)
                    .HasColumnName("travelallowance")
                    .HasColumnType("money");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employeecompanydetail_account_create_user_id");
                
                entity.HasOne(d => d.ModifyUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_employeecompanydetail_account_modify_user_id");
            });

        }
    }
}
