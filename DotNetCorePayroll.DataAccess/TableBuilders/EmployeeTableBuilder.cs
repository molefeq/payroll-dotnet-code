using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class EmployeeTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.DisabilityDescription)
                    .HasColumnName("disability_description")
                    .HasMaxLength(100);

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("email_address")
                    .HasMaxLength(500);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasColumnName("employee_number")
                    .HasMaxLength(20);

                entity.Property(e => e.EthnicGroup)
                    .IsRequired()
                    .HasColumnName("ethnic_group")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);

                entity.Property(e => e.HasDisability).HasColumnName("has_disability");

                entity.Property(e => e.HomeLanguage)
                    .IsRequired()
                    .HasColumnName("home_language")
                    .HasMaxLength(50);

                entity.Property(e => e.HomeNumber)
                    .HasColumnName("home_number")
                    .HasMaxLength(20);

                entity.Property(e => e.IdOrPassportNumber)
                    .HasColumnName("id_or_passport_number")
                    .HasMaxLength(20);

                entity.Property(e => e.ImageFileName)
                    .HasColumnName("image_file_name")
                    .HasMaxLength(1000);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasColumnName("initials")
                    .HasMaxLength(20);

                entity.Property(e => e.IsSouthAfricanCitizen).HasColumnName("is_south_african_citizen");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnName("marital_status")
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobile_number")
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedUserId).HasColumnName("modified_user_id");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnName("nick_name")
                    .HasMaxLength(100);

                entity.Property(e => e.PhysicalAddressId).HasColumnName("physical_address_id");

                entity.Property(e => e.PostalAddressId).HasColumnName("postal_address_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TaxReferenceNumber)
                    .IsRequired()
                    .HasColumnName("tax_reference_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(20);

                entity.Property(e => e.WorkNumber)
                    .HasColumnName("work_number")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_company_company_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_account_create_user_id");

                entity.HasOne(d => d.ModifiedUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifiedUserId)
                    .HasConstraintName("fk_employee_account_modified_user_id");
            });
        }
    }
}
