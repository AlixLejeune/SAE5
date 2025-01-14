using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class connectedobjectfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rob_name",
                table: "t_e_roomboject_rob",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "cobj_id",
                table: "t_e_connectedobjects_cobj",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cobj_id",
                table: "t_e_connectedobjects_cobj");

            migrationBuilder.AlterColumn<string>(
                name: "rob_name",
                table: "t_e_roomboject_rob",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
