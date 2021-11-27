using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceAlterator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDiscount = table.Column<bool>(type: "bit", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.1m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceAlterator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationBasket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationBasket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PriceAlteratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileType_PriceAlterator_PriceAlteratorId",
                        column: x => x.PriceAlteratorId,
                        principalTable: "PriceAlterator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PriceAlteratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Language_PriceAlterator_PriceAlteratorId",
                        column: x => x.PriceAlteratorId,
                        principalTable: "PriceAlterator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileToTranslate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    FileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToTranslate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileToTranslate_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileToTranslate_TranslationBasket_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TranslationBasket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranslationBasketLanguage",
                columns: table => new
                {
                    TranslationBasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationBasketLanguage", x => new { x.TranslationBasketId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_TranslationBasketLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationBasketLanguage_TranslationBasket_TranslationBasketId",
                        column: x => x.TranslationBasketId,
                        principalTable: "TranslationBasket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "Code", "PriceAlteratorId" },
                values: new object[,]
                {
                    { new Guid("e2a4f70c-6851-4d48-8409-11ef36bff2c7"), "txt", null },
                    { new Guid("4a9f0f9a-9b67-4fe1-9eb2-7f3b796c42cf"), "doc", null }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Code", "PriceAlteratorId" },
                values: new object[,]
                {
                    { new Guid("b1c541f7-136c-413a-a81f-0060a702ab96"), "zh-cn", null },
                    { new Guid("3d0bc921-1688-4cc1-864b-d2ecc2ae42da"), "en-us", null }
                });

            migrationBuilder.InsertData(
                table: "PriceAlterator",
                columns: new[] { "Id", "IsDiscount", "Percentage" },
                values: new object[,]
                {
                    { new Guid("aa502c8d-2a63-4267-b65a-29dabc6fdfcb"), true, 20m },
                    { new Guid("7198d221-9ed2-4174-ac21-68708e80ec3f"), false, 20m },
                    { new Guid("9c4478e4-784c-47c8-a96e-2661d6b33574"), false, 35m }
                });

            migrationBuilder.InsertData(
                table: "TranslationBasket",
                columns: new[] { "Id", "CustomerId", "DueDate" },
                values: new object[,]
                {
                    { new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"), new Guid("53b03af6-75ca-4ee7-9a2d-5f4d35881b44"), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb31c0e6-82c1-4944-b10c-21eac32848c1"), new Guid("eb8a9cfb-a2bf-446f-8195-405e534f966e"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FileToTranslate",
                columns: new[] { "Id", "Comments", "Content", "FileTypeId", "Name", "ProjectId" },
                values: new object[] { new Guid("34e77c0e-a4f6-4d93-88df-9e9beb4b20f5"), "3 dummy comment 3", "Let there be night in the softest of days#LW-Test#why would you try to play games at this time?", new Guid("4a9f0f9a-9b67-4fe1-9eb2-7f3b796c42cf"), "file 3", new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f") });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "Code", "PriceAlteratorId" },
                values: new object[,]
                {
                    { new Guid("269a6e63-f58c-493c-9f0b-3dd81ece3fd6"), "pdf", new Guid("7198d221-9ed2-4174-ac21-68708e80ec3f") },
                    { new Guid("991a253c-c55e-4f09-8d1b-6062e288a391"), "psd", new Guid("9c4478e4-784c-47c8-a96e-2661d6b33574") }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Code", "PriceAlteratorId" },
                values: new object[] { new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), "es-es", new Guid("aa502c8d-2a63-4267-b65a-29dabc6fdfcb") });

            migrationBuilder.InsertData(
                table: "FileToTranslate",
                columns: new[] { "Id", "Comments", "Content", "FileTypeId", "Name", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("4bb64c01-5a9f-4c06-b370-eb5136f538ba"), "comment 1", "this is a sentence that is ending#LW-Test#This is another sentence that is included in the file#LW-Test#why would you repeat a whole sentence?", new Guid("269a6e63-f58c-493c-9f0b-3dd81ece3fd6"), "file 1", new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f") },
                    { new Guid("dd22cbda-f64f-4aaa-bcdd-4cca567f9aee"), "2 dummy comment 2", "this sentence is going to be repeated#LW-Test#this sentence is going to be repeated", new Guid("991a253c-c55e-4f09-8d1b-6062e288a391"), "file 2", new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f") }
                });

            migrationBuilder.InsertData(
                table: "TranslationBasketLanguage",
                columns: new[] { "LanguageId", "TranslationBasketId" },
                values: new object[,]
                {
                    { new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f") },
                    { new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), new Guid("fb31c0e6-82c1-4944-b10c-21eac32848c1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileToTranslate_FileTypeId",
                table: "FileToTranslate",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FileToTranslate_ProjectId",
                table: "FileToTranslate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FileType_Code",
                table: "FileType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileType_PriceAlteratorId",
                table: "FileType",
                column: "PriceAlteratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_Code",
                table: "Language",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Language_PriceAlteratorId",
                table: "Language",
                column: "PriceAlteratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationBasketLanguage_LanguageId",
                table: "TranslationBasketLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToTranslate");

            migrationBuilder.DropTable(
                name: "TranslationBasketLanguage");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "TranslationBasket");

            migrationBuilder.DropTable(
                name: "PriceAlterator");
        }
    }
}
