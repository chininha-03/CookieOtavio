using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieOtavio.Data.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoNoavmente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "ItemVenda",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ClienteId",
                table: "ItemVenda",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Cliente_ClienteId",
                table: "ItemVenda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Cliente_ClienteId",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ClienteId",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ItemVenda");
        }
    }
}
