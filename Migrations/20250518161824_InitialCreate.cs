using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaoXuanHau0072767.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store0072767De1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store0072767De1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier0072767De1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier0072767De1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreSupplier0072767De1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Intimate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSupplier0072767De1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSupplier0072767De1_Store0072767De1_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store0072767De1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreSupplier0072767De1_Supplier0072767De1_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier0072767De1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store0072767De1_Name",
                table: "Store0072767De1",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreSupplier0072767De1_StoreId",
                table: "StoreSupplier0072767De1",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSupplier0072767De1_SupplierId",
                table: "StoreSupplier0072767De1",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier0072767De1_Name",
                table: "Supplier0072767De1",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreSupplier0072767De1");

            migrationBuilder.DropTable(
                name: "Store0072767De1");

            migrationBuilder.DropTable(
                name: "Supplier0072767De1");
        }
    }
}
