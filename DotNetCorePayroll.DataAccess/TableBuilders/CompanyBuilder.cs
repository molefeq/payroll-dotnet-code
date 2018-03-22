using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class CompanyBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Guid)
                    .HasName("ck_company_guid")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companyregistrationnumber).HasColumnName("companyregistrationnumber");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Logofilename).HasColumnName("logofilename");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Natureofbusiness)
                    .IsRequired()
                    .HasColumnName("natureofbusiness");

                entity.Property(e => e.Organisationid).HasColumnName("organisationid");

                entity.Property(e => e.Payereferencenumber).HasColumnName("payereferencenumber");

                entity.Property(e => e.Paysdlind)
                    .HasColumnName("paysdlind")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Registeredname)
                    .IsRequired()
                    .HasColumnName("registeredname");

                entity.Property(e => e.Sarsuifnumber).HasColumnName("sarsuifnumber");

                entity.Property(e => e.Taxnumber).HasColumnName("taxnumber");

                entity.Property(e => e.Tradingname)
                    .IsRequired()
                    .HasColumnName("tradingname");

                entity.Property(e => e.Uifcompanyreferencenumber).HasColumnName("uifcompanyreferencenumber");

                entity.Property(e => e.Uifreferencenumber).HasColumnName("uifreferencenumber");

                entity.HasOne(d => d.Organisation)
                    .WithMany()
                    .HasForeignKey(d => d.Organisationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_company_organisation_organisationid");
            });
        }
    }
}
