using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppForo.Migrations
{
    public partial class UserNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Usuarios_UserId",
                table: "Mensajes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mensajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Usuarios_UserId",
                table: "Mensajes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Usuarios_UserId",
                table: "Mensajes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mensajes",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Usuarios_UserId",
                table: "Mensajes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
