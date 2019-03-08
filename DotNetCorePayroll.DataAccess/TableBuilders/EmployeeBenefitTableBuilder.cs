using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class EmployeeBenefitTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeBenefit>(entity =>
            {
                entity.ToTable("employee_benefit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BenefitId).HasColumnName("benefit_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.EmployeeContribution)
                    .HasColumnName("employee_contribution")
                    .HasColumnType("money");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EmployerContribution)
                    .HasColumnName("employer_contribution")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedUserId).HasColumnName("modified_user_id");

                entity.HasOne(d => d.Benefit)
                    .WithMany(p => p.EmployeeBenefit)
                    .HasForeignKey(d => d.BenefitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_benefit_benefit_benefit_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_benefit_account_create_user_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeBenefit)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_benefit_employee_employee_id");

                entity.HasOne(d => d.ModifiedUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifiedUserId)
                    .HasConstraintName("fk_employee_benefit_account_modified_user_id");
            });
        }
    }
}
