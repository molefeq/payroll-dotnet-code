using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class CompanyBankDetailTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyBankDetail>(entity =>
            {
                entity.ToTable("companybankdetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountHolderName)
                    .IsRequired()
                    .HasColumnName("accountholdername")
                    .HasMaxLength(200);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("accountnumber")
                    .HasMaxLength(50);

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasColumnName("accounttype")
                    .HasMaxLength(50);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bankname")
                    .HasMaxLength(50);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchcode")
                    .HasMaxLength(50);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchname")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyId).HasColumnName("companyid");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyBankDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companybankdetail_company_companyid");
            });
        }
    }
}
