using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class EmployeeAllowanceTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAllowance>(entity =>
            {
                entity.ToTable("employee_allowance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowanceTypeId).HasColumnName("allowance_type_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedUserId).HasColumnName("modified_user_id");

                entity.HasOne(d => d.AllowanceType)
                    .WithMany(p => p.EmployeeAllowance)
                    .HasForeignKey(d => d.AllowanceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_allowance_employee_allowance_type_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_allowance_account_create_user_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAllowance)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_allowance_employee_employee_id");

                entity.HasOne(d => d.ModifiedUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifiedUserId)
                    .HasConstraintName("fk_employee_allowance_account_modified_user_id");
            });
        }
    }
}
