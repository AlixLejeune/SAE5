using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                    bui_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_building_bui", x => x.bui_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_roomtype_rty",
                columns: table => new
                {
                    rty_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rty_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_roomtype_rty", x => x.rty_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_room_roo",
                columns: table => new
                {
                    roo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roo_name = table.Column<string>(type: "text", nullable: false),
                    roo_northorientation = table.Column<double>(type: "double precision", nullable: false),
                    roo_height = table.Column<double>(type: "double precision", nullable: false),
                    fk_roo_buildingid = table.Column<int>(type: "integer", nullable: false),
                    fk_roo_idroomtype = table.Column<int>(type: "integer", nullable: false),
                    Base = table.Column<string>(type: "jsonb", nullable: true)
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
                        name: "FK_t_e_room_roo_t_e_roomtype_rty_fk_roo_idroomtype",
                        column: x => x.fk_roo_idroomtype,
                        principalTable: "t_e_roomtype_rty",
                        principalColumn: "rty_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_roomboject_rob",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rob_name = table.Column<string>(type: "text", nullable: false),
                    rob_roomid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_roomboject_rob", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_roomboject_rob_t_e_room_roo_rob_roomid",
                        column: x => x.rob_roomid,
                        principalTable: "t_e_room_roo",
                        principalColumn: "roo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_connectedobjects_cobj",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_connectedobjects_cobj", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_connectedobjects_cobj_t_e_roomboject_rob_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_roomboject_rob",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_door_doo",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    doo_posx = table.Column<double>(type: "double precision", nullable: false),
                    doo_posy = table.Column<double>(type: "double precision", nullable: false),
                    doo_posz = table.Column<double>(type: "double precision", nullable: false),
                    doo_orientation = table.Column<double>(type: "double precision", nullable: false),
                    doo_sizex = table.Column<double>(type: "double precision", nullable: false),
                    doo_sizey = table.Column<double>(type: "double precision", nullable: false),
                    doo_sizez = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_door_doo", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_door_doo_t_e_roomboject_rob_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_roomboject_rob",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_heater_hea",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    hea_posx = table.Column<double>(type: "double precision", nullable: false),
                    hea_posy = table.Column<double>(type: "double precision", nullable: false),
                    hea_posz = table.Column<double>(type: "double precision", nullable: false),
                    hea_orientation = table.Column<double>(type: "double precision", nullable: false),
                    hea_sizex = table.Column<double>(type: "double precision", nullable: false),
                    hea_sizey = table.Column<double>(type: "double precision", nullable: false),
                    hea_sizez = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_heater_hea", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_heater_hea_t_e_roomboject_rob_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_roomboject_rob",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_table_tab",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    tab_posx = table.Column<double>(type: "double precision", nullable: false),
                    tab_posy = table.Column<double>(type: "double precision", nullable: false),
                    tab_posz = table.Column<double>(type: "double precision", nullable: false),
                    tab_orientation = table.Column<double>(type: "double precision", nullable: false),
                    tab_sizex = table.Column<double>(type: "double precision", nullable: false),
                    tab_sizey = table.Column<double>(type: "double precision", nullable: false),
                    tab_sizez = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_table_tab", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_table_tab_t_e_roomboject_rob_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_roomboject_rob",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_window_win",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    win_posx = table.Column<double>(type: "double precision", nullable: false),
                    win_posy = table.Column<double>(type: "double precision", nullable: false),
                    win_posz = table.Column<double>(type: "double precision", nullable: false),
                    win_orientation = table.Column<double>(type: "double precision", nullable: false),
                    win_sizex = table.Column<double>(type: "double precision", nullable: false),
                    win_sizey = table.Column<double>(type: "double precision", nullable: false),
                    win_sizez = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_window_win", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_window_win_t_e_roomboject_rob_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_roomboject_rob",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_lamp_lam",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    lam_posx = table.Column<double>(type: "double precision", nullable: false),
                    lam_posy = table.Column<double>(type: "double precision", nullable: false),
                    lam_posz = table.Column<double>(type: "double precision", nullable: false),
                    lam_rotx = table.Column<double>(type: "double precision", nullable: false),
                    lam_roty = table.Column<double>(type: "double precision", nullable: false),
                    lam_rotz = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_lamp_lam", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_lamp_lam_t_e_connectedobjects_cobj_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_connectedobjects_cobj",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_plug_plu",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    plu_posx = table.Column<double>(type: "double precision", nullable: false),
                    plu_posy = table.Column<double>(type: "double precision", nullable: false),
                    plu_posz = table.Column<double>(type: "double precision", nullable: false),
                    plu_rotx = table.Column<double>(type: "double precision", nullable: false),
                    plu_roty = table.Column<double>(type: "double precision", nullable: false),
                    plu_rotz = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_plug_plu", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_plug_plu_t_e_connectedobjects_cobj_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_connectedobjects_cobj",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_sensor6in1_sio",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    sio_posx = table.Column<double>(type: "double precision", nullable: false),
                    sio_posy = table.Column<double>(type: "double precision", nullable: false),
                    sio_posz = table.Column<double>(type: "double precision", nullable: false),
                    sio_rotx = table.Column<double>(type: "double precision", nullable: false),
                    sio_roty = table.Column<double>(type: "double precision", nullable: false),
                    sio_rotz = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_sensor6in1_sio", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_sensor6in1_sio_t_e_connectedobjects_cobj_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_connectedobjects_cobj",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_sensor9in1_nio",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    nio_posx = table.Column<double>(type: "double precision", nullable: false),
                    nio_posy = table.Column<double>(type: "double precision", nullable: false),
                    nio_posz = table.Column<double>(type: "double precision", nullable: false),
                    nio_rotx = table.Column<double>(type: "double precision", nullable: false),
                    nio_roty = table.Column<double>(type: "double precision", nullable: false),
                    nio_rotz = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_sensor9in1_nio", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_sensor9in1_nio_t_e_connectedobjects_cobj_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_connectedobjects_cobj",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_sensorco2_co2",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    co2_posx = table.Column<double>(type: "double precision", nullable: false),
                    co2_posy = table.Column<double>(type: "double precision", nullable: false),
                    co2_posz = table.Column<double>(type: "double precision", nullable: false),
                    co2_rotx = table.Column<double>(type: "double precision", nullable: false),
                    co2_roty = table.Column<double>(type: "double precision", nullable: false),
                    co2_rotz = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_sensorco2_co2", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_sensorco2_co2_t_e_connectedobjects_cobj_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_connectedobjects_cobj",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_siren_sir",
                columns: table => new
                {
                    rob_id = table.Column<int>(type: "integer", nullable: false),
                    sir_posx = table.Column<double>(type: "double precision", nullable: false),
                    sir_posy = table.Column<double>(type: "double precision", nullable: false),
                    sir_posz = table.Column<double>(type: "double precision", nullable: false),
                    sir_rotx = table.Column<double>(type: "double precision", nullable: false),
                    sir_roty = table.Column<double>(type: "double precision", nullable: false),
                    sir_rotz = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_siren_sir", x => x.rob_id);
                    table.ForeignKey(
                        name: "FK_t_e_siren_sir_t_e_connectedobjects_cobj_rob_id",
                        column: x => x.rob_id,
                        principalTable: "t_e_connectedobjects_cobj",
                        principalColumn: "rob_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_room_roo_fk_roo_buildingid",
                table: "t_e_room_roo",
                column: "fk_roo_buildingid");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_room_roo_fk_roo_idroomtype",
                table: "t_e_room_roo",
                column: "fk_roo_idroomtype");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_roomboject_rob_rob_roomid",
                table: "t_e_roomboject_rob",
                column: "rob_roomid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_door_doo");

            migrationBuilder.DropTable(
                name: "t_e_heater_hea");

            migrationBuilder.DropTable(
                name: "t_e_lamp_lam");

            migrationBuilder.DropTable(
                name: "t_e_plug_plu");

            migrationBuilder.DropTable(
                name: "t_e_sensor6in1_sio");

            migrationBuilder.DropTable(
                name: "t_e_sensor9in1_nio");

            migrationBuilder.DropTable(
                name: "t_e_sensorco2_co2");

            migrationBuilder.DropTable(
                name: "t_e_siren_sir");

            migrationBuilder.DropTable(
                name: "t_e_table_tab");

            migrationBuilder.DropTable(
                name: "t_e_window_win");

            migrationBuilder.DropTable(
                name: "t_e_connectedobjects_cobj");

            migrationBuilder.DropTable(
                name: "t_e_roomboject_rob");

            migrationBuilder.DropTable(
                name: "t_e_room_roo");

            migrationBuilder.DropTable(
                name: "t_e_building_bui");

            migrationBuilder.DropTable(
                name: "t_e_roomtype_rty");
        }
    }
}
