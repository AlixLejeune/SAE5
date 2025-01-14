using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class connectedobjectfix2leretour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cobj_id",
                table: "t_e_connectedobjects_cobj",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cobj_id",
                table: "t_e_connectedobjects_cobj",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
