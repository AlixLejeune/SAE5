using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class customobjectmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_customobject_cus",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    cus_posx = table.Column<double>(type: "double precision", nullable: false),
                    cus_posy = table.Column<double>(type: "double precision", nullable: false),
                    cus_posz = table.Column<double>(type: "double precision", nullable: false),
                    cus_rotx = table.Column<double>(type: "double precision", nullable: false),
                    cus_roty = table.Column<double>(type: "double precision", nullable: false),
                    cus_rotz = table.Column<double>(type: "double precision", nullable: false),
                    cus_sizex = table.Column<double>(type: "double precision", nullable: false),
                    cus_sizey = table.Column<double>(type: "double precision", nullable: false),
                    cus_sizez = table.Column<double>(type: "double precision", nullable: false),
                    cus_color = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_customobject_cus", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_customobject_cus_t_e_roomboject_rob_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_roomboject_rob",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_customobject_cus");
        }
    }
}
