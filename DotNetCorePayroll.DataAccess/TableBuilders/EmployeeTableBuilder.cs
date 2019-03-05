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

                entity.Property(e => e.CompanyId).HasColumnName("companyid");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.DisabilityDescription)
                    .HasColumnName("disabilitydescription")
                    .HasMaxLength(100);

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("emailaddress")
                    .HasMaxLength(500);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasColumnName("employeenumber")
                    .HasMaxLength(20);

                entity.Property(e => e.EthnicGroup)
                    .IsRequired()
                    .HasColumnName("ethnicgroup")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);

                entity.Property(e => e.HasDisability).HasColumnName("hasdisability");

                entity.Property(e => e.HomeLanguage)
                    .IsRequired()
                    .HasColumnName("homelanguage")
                    .HasMaxLength(50);

                entity.Property(e => e.HomeNumber)
                    .HasColumnName("homenumber")
                    .HasMaxLength(20);

                entity.Property(e => e.IdOrPassportNumber)
                    .HasColumnName("idorpassportnumber")
                    .HasMaxLength(20);

                entity.Property(e => e.ImageFileName)
                    .HasColumnName("imagefilename")
                    .HasMaxLength(1000);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasColumnName("initials")
                    .HasMaxLength(20);

                entity.Property(e => e.IsSouthAfricanCitizen).HasColumnName("issouthafricancitizen");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(100);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnName("maritalstatus")
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobilenumber")
                    .HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnName("modify_date");

                entity.Property(e => e.ModifyUserId).HasColumnName("modify_user_id");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnName("nickname")
                    .HasMaxLength(100);

                entity.Property(e => e.PhysicalAddressId).HasColumnName("physical_address_id");

                entity.Property(e => e.PostalAddressId).HasColumnName("postal_address_id");

                entity.Property(e => e.StatusId).HasColumnName("statuses_id");

                entity.Property(e => e.TaxReferenceNumber)
                    .IsRequired()
                    .HasColumnName("taxreferencenumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(20);

                entity.Property(e => e.WorkNumber)
                    .HasColumnName("worknumber")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_company_companyid");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_account_create_user_id");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany()
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_employee_account_modify_user_id");

                entity.HasOne(d => d.PhysicalAddress)
                    .WithMany()
                    .HasForeignKey(d => d.PhysicalAddressId)
                    .HasConstraintName("fk_employee_physical_address_id");

                entity.HasOne(d => d.PostalAddress)
                    .WithMany()
                    .HasForeignKey(d => d.PostalAddressId)
                    .HasConstraintName("fk_employee_postal_address_id");
            });
        }
    }
}
