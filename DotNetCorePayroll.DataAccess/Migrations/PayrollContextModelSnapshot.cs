﻿// <auto-generated />
using DotNetCorePayroll.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace DotNetCorePayroll.DataAccess.Migrations
{
    [DbContext(typeof(PayrollContext))]
    partial class PayrollContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("DotNetCorePayroll.Data.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long?>("CompanyId")
                        .HasColumnName("companyid");

                    b.Property<string>("ContactNumber")
                        .HasColumnName("contactnumber");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("createdate");

                    b.Property<long?>("CreateUserId")
                        .HasColumnName("createuserid");

                    b.Property<DateTime?>("DisableDate")
                        .HasColumnName("disabledate");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("emailaddress");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnName("firstname");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool>("IsFirstTimeLogin")
                        .HasColumnName("isfirsttimelogin")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnName("lastname");

                    b.Property<long>("OrganisationId")
                        .HasColumnName("organisationid");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnName("password");

                    b.Property<Guid?>("PasswordResetKey")
                        .HasColumnName("passwordresetkey");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("passwordsalt");

                    b.Property<long>("RoleId")
                        .HasColumnName("roleid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("Guid")
                        .IsUnique()
                        .HasName("ck_account_guid");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("ck_account_username");

                    b.ToTable("account");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .HasColumnName("city");

                    b.Property<long?>("CountryId")
                        .HasColumnName("countryid");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnName("line1");

                    b.Property<string>("Line2")
                        .HasColumnName("line2");

                    b.Property<string>("Location")
                        .HasColumnName("location");

                    b.Property<string>("PostalCode")
                        .HasColumnName("postalcode");

                    b.Property<long?>("ProvinceId")
                        .HasColumnName("provinceid");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnName("suburb");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Companyregistrationnumber")
                        .HasColumnName("companyregistrationnumber");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Logofilename")
                        .HasColumnName("logofilename");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("Natureofbusiness")
                        .IsRequired()
                        .HasColumnName("natureofbusiness");

                    b.Property<long>("Organisationid")
                        .HasColumnName("organisationid");

                    b.Property<string>("Payereferencenumber")
                        .HasColumnName("payereferencenumber");

                    b.Property<short>("Paysdlind")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("paysdlind")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Registeredname")
                        .IsRequired()
                        .HasColumnName("registeredname");

                    b.Property<string>("Sarsuifnumber")
                        .HasColumnName("sarsuifnumber");

                    b.Property<string>("Taxnumber")
                        .HasColumnName("taxnumber");

                    b.Property<string>("Tradingname")
                        .IsRequired()
                        .HasColumnName("tradingname");

                    b.Property<string>("Uifcompanyreferencenumber")
                        .HasColumnName("uifcompanyreferencenumber");

                    b.Property<string>("Uifreferencenumber")
                        .HasColumnName("uifreferencenumber");

                    b.HasKey("Id");

                    b.HasIndex("Guid")
                        .IsUnique()
                        .HasName("ck_company_guid");

                    b.HasIndex("Organisationid");

                    b.ToTable("company");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("ck_country_code");

                    b.ToTable("country");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Organisation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ContactNumber")
                        .HasColumnName("contactnumber");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("EmailAddress")
                        .HasColumnName("emailaddress");

                    b.Property<string>("FaxNumber")
                        .HasColumnName("faxnumber");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("LogoFilename")
                        .HasColumnName("logofilename");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<long>("PhysicalAddressId")
                        .HasColumnName("physicaladdressid");

                    b.Property<long?>("PostalAddressId")
                        .HasColumnName("postaladdressid");

                    b.HasKey("Id");

                    b.HasIndex("Guid")
                        .IsUnique()
                        .HasName("ck_organisation_guid");

                    b.HasIndex("PhysicalAddressId");

                    b.HasIndex("PostalAddressId");

                    b.ToTable("organisation");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Province", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnName("code");

                    b.Property<long>("CountryId")
                        .HasColumnName("countryid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("ck_province_code");

                    b.ToTable("province");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("ck_role_code");

                    b.ToTable("role");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Account", b =>
                {
                    b.HasOne("DotNetCorePayroll.Data.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("fk_account_company_companyid");

                    b.HasOne("DotNetCorePayroll.Data.Account", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .HasConstraintName("fk_account_account_accountid");

                    b.HasOne("DotNetCorePayroll.Data.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .HasConstraintName("fk_account_organisation_organisationid");

                    b.HasOne("DotNetCorePayroll.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_account_role_roleid");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Address", b =>
                {
                    b.HasOne("DotNetCorePayroll.Data.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("DotNetCorePayroll.Data.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Company", b =>
                {
                    b.HasOne("DotNetCorePayroll.Data.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("Organisationid")
                        .HasConstraintName("fk_company_organisation_organisationid");
                });

            modelBuilder.Entity("DotNetCorePayroll.Data.Organisation", b =>
                {
                    b.HasOne("DotNetCorePayroll.Data.Address", "PhysicalAddress")
                        .WithMany()
                        .HasForeignKey("PhysicalAddressId")
                        .HasConstraintName("fk_organisation_address_physicaladdressid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNetCorePayroll.Data.Address", "PostalAddress")
                        .WithMany()
                        .HasForeignKey("PostalAddressId")
                        .HasConstraintName("organisation_postaladdressid_fkey");
                });
#pragma warning restore 612, 618
        }
    }
}
