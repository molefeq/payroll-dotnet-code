using DotNetCorePayroll.Data;

using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class CompanyTableBuilder
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

                entity.Property(e => e.CompanyRegistrationNumber).HasColumnName("companyregistrationnumber");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.LogoFileName).HasColumnName("logofilename");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.NatureOfBusiness)
                    .IsRequired()
                    .HasColumnName("natureofbusiness");

                entity.Property(e => e.ContactNumber).HasColumnName("contactnumber");

                entity.Property(e => e.EmailAddress).HasColumnName("emailaddress");

                entity.Property(e => e.FaxNumber).HasColumnName("faxnumber");

                entity.Property(e => e.OrganisationId).HasColumnName("organisationid");

                entity.Property(e => e.PayeReferenceNumber).HasColumnName("payereferencenumber");

                entity.Property(e => e.PaysdlInd)
                    .HasColumnName("paysdlind");

                entity.Property(e => e.RegisteredName)
                    .IsRequired()
                    .HasColumnName("registeredname");

                entity.Property(e => e.SarsUifNumber).HasColumnName("sarsuifnumber");

                entity.Property(e => e.TaxNumber).HasColumnName("taxnumber");

                entity.Property(e => e.TradingName)
                    .IsRequired()
                    .HasColumnName("tradingname");

                entity.Property(e => e.UifCompanyReferenceNumber).HasColumnName("uifcompanyreferencenumber");

                entity.Property(e => e.UifReferenceNumber).HasColumnName("uifreferencenumber"); ;

                entity.Property(e => e.PhysicalAddressId)
                    .HasColumnName("physical_address_id")
                    .ForNpgsqlHasComment("company physical address");

                entity.Property(e => e.PostalAddressId)
                    .HasColumnName("postal_address_id")
                    .ForNpgsqlHasComment("company postal address");

                entity.HasOne(d => d.Organisation)
                    .WithMany()
                    .HasForeignKey(d => d.OrganisationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_company_organisation_organisationid");

                entity.HasOne(d => d.PhysicalAddress)
                    .WithMany()
                    .HasForeignKey(d => d.PhysicalAddressId)
                    .HasConstraintName("fk_company_physical_address_id");

                entity.HasOne(d => d.PostalAddress)
                    .WithMany()
                    .HasForeignKey(d => d.PostalAddressId)
                    .HasConstraintName("fk_company_postal_address_id");
            });
        }
    }
}
