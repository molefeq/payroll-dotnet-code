using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class EmployeePayrollTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeePayroll>(entity =>
            {
                entity.ToTable("employee_payroll");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnnualLeaveType)
                    .IsRequired()
                    .HasColumnName("annual_leave_type")
                    .HasMaxLength(50);

                entity.Property(e => e.BasicSalary)
                    .HasColumnName("basic_salary")
                    .HasColumnType("money");

                entity.Property(e => e.ContractEndDate)
                    .HasColumnName("contract_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.DateOfEngagement)
                    .HasColumnName("date_of_engagement")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EmployementType)
                    .IsRequired()
                    .HasColumnName("employement_type")
                    .HasMaxLength(50);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("job_title")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedUserId).HasColumnName("modified_user_id");

                entity.Property(e => e.PaymentFrequencyId).HasColumnName("payment_frequency_id");

                entity.Property(e => e.PayrollDay).HasColumnName("payroll_day");

                entity.Property(e => e.SupervisorId).HasColumnName("supervisor_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_payroll_account_create_user_id");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeePayrollEmployee)
                    .HasForeignKey<EmployeePayroll>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_payroll_employee_employee_id");

                entity.HasOne(d => d.ModifiedUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifiedUserId)
                    .HasConstraintName("fk_employee_payroll_account_modified_user_id");

                entity.HasOne(d => d.PaymentFrequency)
                    .WithMany()
                    .HasForeignKey(d => d.PaymentFrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_payroll_payment_frequency_id");

                entity.HasOne(d => d.Supervisor)
                    .WithMany()
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("fk_employee_payroll_employee_supervisor_id");
            });

        }
    }
}
