using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoFinal1205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 210, 255, 190, 70, 233, 190, 207, 36, 138, 38, 23, 169, 50, 76, 37, 135, 124, 28, 230, 222, 142, 13, 237, 150, 130, 235, 131, 245, 42, 254, 240, 4, 125, 126, 157, 67, 201, 169, 255, 40, 253, 106, 185, 156, 238, 26, 236, 4, 110, 117, 205, 135, 11, 45, 25, 94, 250, 198, 123, 199, 236, 246, 13, 179 }, new byte[] { 53, 220, 46, 184, 183, 208, 49, 135, 92, 27, 39, 11, 148, 51, 165, 142, 47, 69, 111, 53, 225, 99, 107, 121, 184, 186, 250, 45, 55, 218, 27, 189, 140, 118, 134, 202, 234, 170, 105, 6, 107, 157, 47, 197, 31, 64, 134, 177, 203, 130, 55, 100, 37, 253, 137, 88, 187, 2, 239, 209, 71, 77, 39, 150, 124, 3, 204, 79, 244, 150, 241, 171, 26, 24, 223, 146, 228, 63, 76, 162, 254, 77, 203, 129, 33, 53, 100, 158, 124, 6, 60, 222, 109, 13, 226, 18, 86, 139, 178, 24, 201, 112, 91, 10, 164, 253, 143, 108, 2, 153, 108, 70, 105, 159, 144, 194, 181, 163, 35, 72, 50, 247, 243, 113, 255, 109, 108, 88 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 0, 94, 212, 78, 110, 7, 239, 129, 135, 67, 252, 166, 36, 34, 192, 234, 235, 52, 8, 219, 219, 17, 247, 50, 72, 1, 66, 34, 122, 55, 63, 172, 236, 252, 2, 171, 219, 99, 156, 233, 99, 249, 43, 131, 194, 16, 66, 120, 165, 191, 42, 57, 104, 99, 56, 184, 213, 222, 136, 87, 112, 223, 136, 100 }, new byte[] { 232, 226, 158, 81, 70, 42, 24, 174, 207, 155, 163, 225, 89, 229, 10, 22, 254, 93, 32, 24, 205, 172, 67, 202, 29, 128, 254, 49, 228, 127, 62, 142, 7, 149, 223, 246, 101, 192, 166, 83, 196, 110, 201, 198, 77, 45, 229, 158, 69, 95, 158, 196, 94, 17, 132, 176, 255, 201, 247, 248, 212, 82, 229, 61, 240, 9, 214, 119, 9, 14, 142, 223, 145, 151, 155, 240, 238, 35, 248, 199, 35, 28, 45, 14, 143, 21, 67, 200, 58, 208, 236, 209, 250, 46, 218, 100, 11, 33, 214, 154, 130, 226, 253, 46, 149, 171, 14, 192, 77, 238, 121, 214, 93, 25, 220, 18, 113, 145, 159, 147, 109, 70, 161, 78, 144, 231, 136, 78 } });
        }
    }
}
