using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class AccountBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.Guid)
                    .HasName("ck_account_guid")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("ck_account_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("companyid");

                entity.Property(e => e.ContactNumber).HasColumnName("contactnumber");

                entity.Property(e => e.CreateDate).HasColumnName("createdate");

                entity.Property(e => e.CreateUserId).HasColumnName("createuserid");

                entity.Property(e => e.DisableDate).HasColumnName("disabledate");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.IsFirstTimeLogin)
                    .IsRequired()
                    .HasColumnName("isfirsttimelogin")
                    .HasColumnType("bit");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.OrganisationId).HasColumnName("organisationid");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.PasswordResetKey).HasColumnName("passwordresetkey");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("passwordsalt");

                entity.Property(e => e.RoleId).HasColumnName("roleid");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_account_company_companyid");

                entity.HasOne(d => d.CreateUser)
                    .WithMany()
                    .HasForeignKey(d => d.CreateUserId)
                    .HasConstraintName("fk_account_account_accountid");

                entity.HasOne(d => d.Organisation)
                    .WithMany()
                    .HasForeignKey(d => d.OrganisationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_organisation_organisationid");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_role_roleid");
            });
        }
    }
}
