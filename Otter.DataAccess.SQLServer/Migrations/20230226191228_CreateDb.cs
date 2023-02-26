using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LatinName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    AbsoluteDiscount = table.Column<long>(type: "bigint", nullable: true),
                    PercentDiscount = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountUsageType = table.Column<int>(type: "int", nullable: false),
                    LimitedCount = table.Column<int>(type: "int", nullable: true),
                    RemainingLimitedCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Callsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerTestNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerTestNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Base",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Base",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    GuarantyStatus = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    IsMobileConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    OtpExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imei = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BirthDateString = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PolicyState = table.Column<int>(type: "int", nullable: false),
                    BasePremium = table.Column<long>(type: "bigint", nullable: false),
                    FinalPremium = table.Column<long>(type: "bigint", nullable: false),
                    Discount = table.Column<long>(type: "bigint", nullable: false),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremiumRate = table.Column<double>(type: "float", nullable: false),
                    SpeakerTestAttempt = table.Column<int>(type: "int", nullable: false),
                    SpeakerTestState = table.Column<bool>(type: "bit", nullable: false),
                    MicrophoneTestState = table.Column<bool>(type: "bit", nullable: false),
                    ScreenTestState = table.Column<bool>(type: "bit", nullable: false),
                    ImeiFileState = table.Column<bool>(type: "bit", nullable: false),
                    PhoneFileBoxState = table.Column<bool>(type: "bit", nullable: false),
                    CameraFileState = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ModelId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    SpeakerTestNumberId = table.Column<long>(type: "bigint", nullable: false),
                    MarketerCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsSendTrackingSms = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Base",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policies_Models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "Base",
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_SpeakerTestNumbers_SpeakerTestNumberId",
                        column: x => x.SpeakerTestNumberId,
                        principalTable: "SpeakerTestNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiumAmount = table.Column<long>(type: "bigint", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayerCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RetrievalReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SystemTraceAuditNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyFileType = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyFiles_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, "PremiumRate", "0.04" },
                    { 2L, "IPGTerminalId", "08069161" },
                    { 3L, "IPGAcceptorId", "992180008069161" },
                    { 4L, "IPGPassPhrase", "76FEB0F316883B83" },
                    { 5L, "IPGAccountNumber", "0000113939400" },
                    { 6L, "IPGRsaPublicKey", "-----BEGIN PUBLIC KEY-----\r\nMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDfA/K5iF5s7GqNpBm+mRdZQvmA\r\nmSMpO+65h4jrIEEbS+HoMGWVZsBz+Kmh7PUZX48bqSqIUcIOlF0glxLENGwCaQU2\r\nlMrw1CNODqhEKbP4j2VjZisGgUSGv8fmBEpqBjwT1us6r+z0JwlCXeJ46BLAIyzg\r\n003PX0iRNjhnzSOx7QIDAQAB\r\n-----END PUBLIC KEY-----" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                schema: "Base",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                schema: "Base",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PolicyId",
                table: "Payments",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CityId",
                table: "Policies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_ModelId",
                table: "Policies",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_SpeakerTestNumberId",
                table: "Policies",
                column: "SpeakerTestNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyFiles_PolicyId",
                table: "PolicyFiles",
                column: "PolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PolicyFiles");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Models",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "SpeakerTestNumbers");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "Base");
        }
    }
}
