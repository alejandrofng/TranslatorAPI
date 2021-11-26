using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
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
                name: "PriceAlteratorByFileType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDiscount = table.Column<bool>(type: "bit", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceAlteratorByFileType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceAlteratorByFileType_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceAlteratorByLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDiscount = table.Column<bool>(type: "bit", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceAlteratorByLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceAlteratorByLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileToTranslate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToTranslate", x => x.Id);
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
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("269a6e63-f58c-493c-9f0b-3dd81ece3fd6"), "pdf" },
                    { new Guid("991a253c-c55e-4f09-8d1b-6062e288a391"), "psd" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), "es-ES" });

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
                columns: new[] { "Id", "Comments", "Content", "Name", "ProjectId", "Type" },
                values: new object[,]
                {
                    { new Guid("4bb64c01-5a9f-4c06-b370-eb5136f538ba"), "comment 1", "this is a sentence that is ending#LW-Test#This is another sentence that is included in the file#LW-Test#why would you repeat a whole sentence?", "file 1", new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"), "txt" },
                    { new Guid("dd22cbda-f64f-4aaa-bcdd-4cca567f9aee"), "2 dummy comment 2", "this sentence is going to be repeated#LW-Test#this sentence is going to be repeated", "file 2", new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"), "pdf" }
                });

            migrationBuilder.InsertData(
                table: "PriceAlteratorByFileType",
                columns: new[] { "Id", "FileTypeId", "IsDiscount", "Percentage" },
                values: new object[,]
                {
                    { new Guid("d0520ec6-c731-484d-be8c-abc697741e7d"), new Guid("269a6e63-f58c-493c-9f0b-3dd81ece3fd6"), false, 20m },
                    { new Guid("29d2b6cc-52f8-4b35-9e30-433e314a0d53"), new Guid("991a253c-c55e-4f09-8d1b-6062e288a391"), false, 35m }
                });

            migrationBuilder.InsertData(
                table: "PriceAlteratorByLanguage",
                columns: new[] { "Id", "IsDiscount", "LanguageId", "Percentage" },
                values: new object[] { new Guid("768fd54a-c264-4472-9519-734072b093c8"), true, new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), 20m });

            migrationBuilder.InsertData(
                table: "TranslationBasketLanguage",
                columns: new[] { "LanguageId", "TranslationBasketId" },
                values: new object[,]
                {
                    { new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f") },
                    { new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"), new Guid("fb31c0e6-82c1-4944-b10c-21eac32848c1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileToTranslate_ProjectId",
                table: "FileToTranslate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceAlteratorByFileType_FileTypeId",
                table: "PriceAlteratorByFileType",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceAlteratorByLanguage_LanguageId",
                table: "PriceAlteratorByLanguage",
                column: "LanguageId");

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
                name: "PriceAlteratorByFileType");

            migrationBuilder.DropTable(
                name: "PriceAlteratorByLanguage");

            migrationBuilder.DropTable(
                name: "TranslationBasketLanguage");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "TranslationBasket");
        }
    }
}
