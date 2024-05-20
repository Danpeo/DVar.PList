using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVar.PList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePricelistFromCustomColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomColumns_Pricelists_PricelistId",
                table: "CustomColumns");

            migrationBuilder.AlterColumn<Guid>(
                name: "PricelistId",
                table: "CustomColumns",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomColumns_Pricelists_PricelistId",
                table: "CustomColumns",
                column: "PricelistId",
                principalTable: "Pricelists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomColumns_Pricelists_PricelistId",
                table: "CustomColumns");

            migrationBuilder.AlterColumn<Guid>(
                name: "PricelistId",
                table: "CustomColumns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomColumns_Pricelists_PricelistId",
                table: "CustomColumns",
                column: "PricelistId",
                principalTable: "Pricelists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
