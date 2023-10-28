using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_migrationDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstNAme = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PasswordRetryCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    LastActivityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    InsertUserId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IBAN = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    CurrencyCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OpenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    InsertUserId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    AdressLine1 = table.Column<string>(type: "text", nullable: false),
                    AdressLine2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    InsertUserId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReferenceNumber = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    DebitAmount = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    CreditAmount = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    InsertUserId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    CardHolder = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false, defaultValue: "0"),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    CVV = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    ExpiryDate = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    ExpenseLimit = table.Column<int>(type: "integer", nullable: true),
                    InsertUserId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EftTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "text", nullable: false),
                    ReceiverName = table.Column<string>(type: "text", nullable: false, defaultValue: "0"),
                    ReceiverAddress = table.Column<string>(type: "text", nullable: false, defaultValue: "0"),
                    AdressType = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    ChargeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    InsertUserId = table.Column<int>(type: "integer", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EftTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EftTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerId",
                table: "Account",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_AccountId",
                table: "AccountTransaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_AccountId",
                table: "Card",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerNumber",
                table: "Customer",
                column: "CustomerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EftTransaction_AccountId",
                table: "EftTransaction",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransaction");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "EftTransaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
