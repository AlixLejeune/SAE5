using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class firstDatabasePush : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_building_bui",
                columns: table => new
                {
                    bui_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bui_letter = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    bui_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_building_bui", x => x.bui_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_furnituretype_frt",
                columns: table => new
                {
                    frt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    frt_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_furnituretype_frt", x => x.frt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_roomtype_rty",
                columns: table => new
                {
                    rty_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rty_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_roomtype_rty", x => x.rty_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_sensor_sen",
                columns: table => new
                {
                    sen_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sen_x = table.Column<double>(type: "double precision", nullable: false),
                    sen_y = table.Column<double>(type: "double precision", nullable: false),
                    sen_Z = table.Column<double>(type: "double precision", nullable: false),
                    sen_length = table.Column<double>(type: "double precision", nullable: false),
                    sen_width = table.Column<double>(type: "double precision", nullable: false),
                    sen_height = table.Column<double>(type: "double precision", nullable: false),
                    sen_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_sensor_sen", x => x.sen_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_room_roo",
                columns: table => new
                {
                    roo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roo_code = table.Column<string>(type: "text", nullable: false),
                    fk_roo_buildingid = table.Column<int>(type: "integer", nullable: false),
                    fk_roo_roomtypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_room_roo", x => x.roo_id);
                    table.ForeignKey(
                        name: "FK_t_e_room_roo_t_e_building_bui_fk_roo_buildingid",
                        column: x => x.fk_roo_buildingid,
                        principalTable: "t_e_building_bui",
                        principalColumn: "bui_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_room_roo_t_e_roomtype_rty_fk_roo_roomtypeid",
                        column: x => x.fk_roo_roomtypeid,
                        principalTable: "t_e_roomtype_rty",
                        principalColumn: "rty_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_furniture_fur",
                columns: table => new
                {
                    fur_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fur_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fur_length = table.Column<double>(type: "double precision", nullable: false),
                    fur_width = table.Column<double>(type: "double precision", nullable: false),
                    fur_height = table.Column<double>(type: "double precision", nullable: false),
                    fur_x = table.Column<double>(type: "double precision", nullable: false),
                    fur_y = table.Column<double>(type: "double precision", nullable: false),
                    fur_Z = table.Column<double>(type: "double precision", nullable: false),
                    fk_fur_roomid = table.Column<int>(type: "integer", nullable: false),
                    fk_fur_furnituretypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_furniture_fur", x => x.fur_id);
                    table.ForeignKey(
                        name: "FK_t_e_furniture_fur_t_e_furnituretype_frt_fk_fur_furnituretyp~",
                        column: x => x.fk_fur_furnituretypeid,
                        principalTable: "t_e_furnituretype_frt",
                        principalColumn: "frt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_furniture_fur_t_e_room_roo_fk_fur_roomid",
                        column: x => x.fk_fur_roomid,
                        principalTable: "t_e_room_roo",
                        principalColumn: "roo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_wall_wal",
                columns: table => new
                {
                    wal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wal_length = table.Column<double>(type: "double precision", nullable: false),
                    wal_height = table.Column<double>(type: "double precision", nullable: false),
                    fk_wal_roomid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_wall_wal", x => x.wal_id);
                    table.ForeignKey(
                        name: "FK_t_e_wall_wal_t_e_room_roo_fk_wal_roomid",
                        column: x => x.fk_wal_roomid,
                        principalTable: "t_e_room_roo",
                        principalColumn: "roo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_door_doo",
                columns: table => new
                {
                    doo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doo_length = table.Column<double>(type: "double precision", nullable: false),
                    doo_height = table.Column<double>(type: "double precision", nullable: false),
                    fk_doo_wallid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_door_doo", x => x.doo_id);
                    table.ForeignKey(
                        name: "FK_t_e_door_doo_t_e_wall_wal_fk_doo_wallid",
                        column: x => x.fk_doo_wallid,
                        principalTable: "t_e_wall_wal",
                        principalColumn: "wal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_window_win",
                columns: table => new
                {
                    win_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doo_length = table.Column<double>(type: "double precision", nullable: false),
                    win_height = table.Column<double>(type: "double precision", nullable: false),
                    fk_win_wallid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_window_win", x => x.win_id);
                    table.ForeignKey(
                        name: "FK_t_e_window_win_t_e_wall_wal_fk_win_wallid",
                        column: x => x.fk_win_wallid,
                        principalTable: "t_e_wall_wal",
                        principalColumn: "wal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_door_doo_fk_doo_wallid",
                table: "t_e_door_doo",
                column: "fk_doo_wallid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_furniture_fur_fk_fur_furnituretypeid",
                table: "t_e_furniture_fur",
                column: "fk_fur_furnituretypeid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_furniture_fur_fk_fur_roomid",
                table: "t_e_furniture_fur",
                column: "fk_fur_roomid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_room_roo_fk_roo_buildingid",
                table: "t_e_room_roo",
                column: "fk_roo_buildingid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_room_roo_fk_roo_roomtypeid",
                table: "t_e_room_roo",
                column: "fk_roo_roomtypeid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_wall_wal_fk_wal_roomid",
                table: "t_e_wall_wal",
                column: "fk_wal_roomid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_window_win_fk_win_wallid",
                table: "t_e_window_win",
                column: "fk_win_wallid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_door_doo");

            migrationBuilder.DropTable(
                name: "t_e_furniture_fur");

            migrationBuilder.DropTable(
                name: "t_e_sensor_sen");

            migrationBuilder.DropTable(
                name: "t_e_window_win");

            migrationBuilder.DropTable(
                name: "t_e_furnituretype_frt");

            migrationBuilder.DropTable(
                name: "t_e_wall_wal");

            migrationBuilder.DropTable(
                name: "t_e_room_roo");

            migrationBuilder.DropTable(
                name: "t_e_building_bui");

            migrationBuilder.DropTable(
                name: "t_e_roomtype_rty");
        }
    }
}
