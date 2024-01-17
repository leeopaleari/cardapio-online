using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioOnline.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DS_PASSWORD",
                table: "T_USER");

            migrationBuilder.RenameColumn(
                name: "DT_BIRTH_DATE",
                table: "T_USER",
                newName: "DT_BIRTHDATE");

            migrationBuilder.AddColumn<byte[]>(
                name: "DS_PASSWORD_HASH",
                table: "T_USER",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "DS_PASSWORD_SALT",
                table: "T_USER",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DS_PASSWORD_HASH",
                table: "T_USER");

            migrationBuilder.DropColumn(
                name: "DS_PASSWORD_SALT",
                table: "T_USER");

            migrationBuilder.RenameColumn(
                name: "DT_BIRTHDATE",
                table: "T_USER",
                newName: "DT_BIRTH_DATE");

            migrationBuilder.AddColumn<string>(
                name: "DS_PASSWORD",
                table: "T_USER",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
