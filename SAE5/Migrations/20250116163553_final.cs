using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_connectedobjects_cobj_t_e_roomboject_rob_rob_id",
                table: "t_e_connectedobjects_cobj");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_customobject_cus_t_e_roomboject_rob_rob_id",
                table: "t_e_customobject_cus");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_door_doo_t_e_roomboject_rob_rob_id",
                table: "t_e_door_doo");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_heater_hea_t_e_roomboject_rob_rob_id",
                table: "t_e_heater_hea");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_roomboject_rob_t_e_room_roo_rob_roomid",
                table: "t_e_roomboject_rob");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_table_tab_t_e_roomboject_rob_rob_id",
                table: "t_e_table_tab");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_window_win_t_e_roomboject_rob_rob_id",
                table: "t_e_window_win");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_roomboject_rob",
                table: "t_e_roomboject_rob");

            migrationBuilder.RenameTable(
                name: "t_e_roomboject_rob",
                newName: "t_e_roomobject_rob");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_roomboject_rob_rob_roomid",
                table: "t_e_roomobject_rob",
                newName: "IX_t_e_roomobject_rob_rob_roomid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_roomobject_rob",
                table: "t_e_roomobject_rob",
                column: "rob_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_connectedobjects_cobj_t_e_roomobject_rob_rob_id",
                table: "t_e_connectedobjects_cobj",
                column: "rob_id",
                principalTable: "t_e_roomobject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_customobject_cus_t_e_roomobject_rob_rob_id",
                table: "t_e_customobject_cus",
                column: "rob_id",
                principalTable: "t_e_roomobject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_door_doo_t_e_roomobject_rob_rob_id",
                table: "t_e_door_doo",
                column: "rob_id",
                principalTable: "t_e_roomobject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_heater_hea_t_e_roomobject_rob_rob_id",
                table: "t_e_heater_hea",
                column: "rob_id",
                principalTable: "t_e_roomobject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_roomobject_rob_t_e_room_roo_rob_roomid",
                table: "t_e_roomobject_rob",
                column: "rob_roomid",
                principalTable: "t_e_room_roo",
                principalColumn: "roo_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_table_tab_t_e_roomobject_rob_rob_id",
                table: "t_e_table_tab",
                column: "rob_id",
                principalTable: "t_e_roomobject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_window_win_t_e_roomobject_rob_rob_id",
                table: "t_e_window_win",
                column: "rob_id",
                principalTable: "t_e_roomobject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_connectedobjects_cobj_t_e_roomobject_rob_rob_id",
                table: "t_e_connectedobjects_cobj");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_customobject_cus_t_e_roomobject_rob_rob_id",
                table: "t_e_customobject_cus");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_door_doo_t_e_roomobject_rob_rob_id",
                table: "t_e_door_doo");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_heater_hea_t_e_roomobject_rob_rob_id",
                table: "t_e_heater_hea");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_roomobject_rob_t_e_room_roo_rob_roomid",
                table: "t_e_roomobject_rob");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_table_tab_t_e_roomobject_rob_rob_id",
                table: "t_e_table_tab");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_window_win_t_e_roomobject_rob_rob_id",
                table: "t_e_window_win");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_roomobject_rob",
                table: "t_e_roomobject_rob");

            migrationBuilder.RenameTable(
                name: "t_e_roomobject_rob",
                newName: "t_e_roomboject_rob");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_roomobject_rob_rob_roomid",
                table: "t_e_roomboject_rob",
                newName: "IX_t_e_roomboject_rob_rob_roomid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_roomboject_rob",
                table: "t_e_roomboject_rob",
                column: "rob_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_connectedobjects_cobj_t_e_roomboject_rob_rob_id",
                table: "t_e_connectedobjects_cobj",
                column: "rob_id",
                principalTable: "t_e_roomboject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_customobject_cus_t_e_roomboject_rob_rob_id",
                table: "t_e_customobject_cus",
                column: "rob_id",
                principalTable: "t_e_roomboject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_door_doo_t_e_roomboject_rob_rob_id",
                table: "t_e_door_doo",
                column: "rob_id",
                principalTable: "t_e_roomboject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_heater_hea_t_e_roomboject_rob_rob_id",
                table: "t_e_heater_hea",
                column: "rob_id",
                principalTable: "t_e_roomboject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_roomboject_rob_t_e_room_roo_rob_roomid",
                table: "t_e_roomboject_rob",
                column: "rob_roomid",
                principalTable: "t_e_room_roo",
                principalColumn: "roo_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_table_tab_t_e_roomboject_rob_rob_id",
                table: "t_e_table_tab",
                column: "rob_id",
                principalTable: "t_e_roomboject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_window_win_t_e_roomboject_rob_rob_id",
                table: "t_e_window_win",
                column: "rob_id",
                principalTable: "t_e_roomboject_rob",
                principalColumn: "rob_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
