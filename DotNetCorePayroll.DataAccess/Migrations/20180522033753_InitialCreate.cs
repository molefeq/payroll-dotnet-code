using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    code = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    code = table.Column<string>(nullable: true),
                    countryid = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    code = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    city = table.Column<string>(nullable: true),
                    countryid = table.Column<long>(nullable: true),
                    line1 = table.Column<string>(nullable: false),
                    line2 = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    postalcode = table.Column<string>(nullable: true),
                    provinceid = table.Column<long>(nullable: true),
                    suburb = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_country_countryid",
                        column: x => x.countryid,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_address_province_provinceid",
                        column: x => x.provinceid,
                        principalTable: "province",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "organisation",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    contactnumber = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    emailaddress = table.Column<string>(nullable: true),
                    faxnumber = table.Column<string>(nullable: true),
                    guid = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    logofilename = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    physicaladdressid = table.Column<long>(nullable: false),
                    postaladdressid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisation", x => x.id);
                    table.ForeignKey(
                        name: "fk_organisation_address_physicaladdressid",
                        column: x => x.physicaladdressid,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "organisation_postaladdressid_fkey",
                        column: x => x.postaladdressid,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    companyregistrationnumber = table.Column<string>(nullable: true),
                    guid = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    logofilename = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    natureofbusiness = table.Column<string>(nullable: false),
                    organisationid = table.Column<long>(nullable: false),
                    payereferencenumber = table.Column<string>(nullable: true),
                    paysdlind = table.Column<short>(nullable: false, defaultValueSql: "0"),
                    registeredname = table.Column<string>(nullable: false),
                    sarsuifnumber = table.Column<string>(nullable: true),
                    taxnumber = table.Column<string>(nullable: true),
                    tradingname = table.Column<string>(nullable: false),
                    uifcompanyreferencenumber = table.Column<string>(nullable: true),
                    uifreferencenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_organisation_organisationid",
                        column: x => x.organisationid,
                        principalTable: "organisation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    companyid = table.Column<long>(nullable: true),
                    contactnumber = table.Column<string>(nullable: true),
                    createdate = table.Column<DateTime>(nullable: false),
                    createuserid = table.Column<long>(nullable: true),
                    disabledate = table.Column<DateTime>(nullable: true),
                    emailaddress = table.Column<string>(nullable: false),
                    firstname = table.Column<string>(nullable: false),
                    guid = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    isfirsttimelogin = table.Column<bool>(type: "bit", nullable: false),
                    lastname = table.Column<string>(nullable: false),
                    organisationid = table.Column<long>(nullable: false),
                    password = table.Column<byte[]>(nullable: false),
                    passwordresetkey = table.Column<Guid>(nullable: true),
                    passwordsalt = table.Column<byte[]>(nullable: false),
                    roleid = table.Column<long>(nullable: false),
                    username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_account_account_accountid",
                        column: x => x.createuserid,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_account_organisation_organisationid",
                        column: x => x.organisationid,
                        principalTable: "organisation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_account_role_roleid",
                        column: x => x.roleid,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_companyid",
                table: "account",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_account_createuserid",
                table: "account",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "ck_account_guid",
                table: "account",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_organisationid",
                table: "account",
                column: "organisationid");

            migrationBuilder.CreateIndex(
                name: "IX_account_roleid",
                table: "account",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ck_account_username",
                table: "account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_countryid",
                table: "address",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_address_provinceid",
                table: "address",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "ck_company_guid",
                table: "company",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_organisationid",
                table: "company",
                column: "organisationid");

            migrationBuilder.CreateIndex(
                name: "ck_country_code",
                table: "country",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ck_organisation_guid",
                table: "organisation",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organisation_physicaladdressid",
                table: "organisation",
                column: "physicaladdressid");

            migrationBuilder.CreateIndex(
                name: "IX_organisation_postaladdressid",
                table: "organisation",
                column: "postaladdressid");

            migrationBuilder.CreateIndex(
                name: "ck_province_code",
                table: "province",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ck_role_code",
                table: "role",
                column: "code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "organisation");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "province");
        }
    }
}
