using DotNetCorePayroll.Data;

using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class OrganisationBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.ToTable("organisation");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.ContactNumber).HasColumnName("contactnumber");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EmailAddress).HasColumnName("emailaddress");

                entity.Property(e => e.FaxNumber).HasColumnName("faxnumber");

                entity.Property(e => e.LogoFilename).HasColumnName("logofilename");

                entity.Property(e => e.PhysicalAddressId).HasColumnName("physicaladdressid");

                entity.Property(e => e.PostalAddressId).HasColumnName("postaladdressid");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasIndex(e => e.Guid)
                    .HasName("ck_organisation_guid")
                    .IsUnique();

                entity.HasOne(d => d.PhysicalAddress)
                    .WithMany()
                    .HasForeignKey(d => d.PhysicalAddressId)
                    .HasConstraintName("fk_organisation_address_physicaladdressid");

                entity.HasOne(d => d.PostalAddress)
                    .WithMany()
                    .HasForeignKey(d => d.PostalAddressId)
                    .HasConstraintName("organisation_postaladdressid_fkey");
            });
        }
    }
}
