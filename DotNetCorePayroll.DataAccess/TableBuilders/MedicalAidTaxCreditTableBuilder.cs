using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.DataAccess.TableBuilders
{
    public class MedicalAidTaxCreditTableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAidTaxCredit>(entity =>
            {
                entity.ToTable("medical_aid_tax_credit", "sars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sars.medical_aid_tax_credit_id_seq'::regclass)");

                entity.Property(e => e.CreditAmount)
                    .HasColumnName("credit_amount")
                    .HasColumnType("money");

                entity.Property(e => e.MemberType)
                    .IsRequired()
                    .HasColumnName("member_type")
                    .HasMaxLength(100);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            modelBuilder.HasSequence<int>("medical_aid_tax_credit_id_seq");
        }
    }
}
