using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class EmployeeMedicalAidTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeMedicalAid>(entity =>
            {
                entity.ToTable("employee_medical_aid");

                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.IsMainMember).HasColumnName("is_main_member");

                entity.Property(e => e.MedicalAidName)
                    .IsRequired()
                    .HasColumnName("medical_aid_name")
                    .HasMaxLength(100);

                entity.Property(e => e.MedicalAidNumber)
                    .IsRequired()
                    .HasColumnName("medical_aid_number")
                    .HasMaxLength(20);

                entity.Property(e => e.MedicalAidScheme)
                    .IsRequired()
                    .HasColumnName("medical_aid_scheme")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedUserId).HasColumnName("modified_user_id");

                entity.Property(e => e.NumberOfDependants).HasColumnName("number_of_dependants");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_medical_aid_account_create_user_id");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeMedicalAid)
                    .HasForeignKey<EmployeeMedicalAid>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_medical_aid_employee_employee_id");

                entity.HasOne(d => d.ModifiedUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifiedUserId)
                    .HasConstraintName("fk_employee_medical_aid_account_modified_user_id");
            });
        }
    }
}
