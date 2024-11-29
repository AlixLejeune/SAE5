﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SAE501_Blazor_API.Models.EntityFramework;

#nullable disable

namespace SAE501_Blazor_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241129094949_Update1")]
    partial class Update1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("bui_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<char>("Letter")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("bui_letter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("bui_name");

                    b.HasKey("Id");

                    b.ToTable("t_e_building_bui");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Door", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("doo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_height");

                    b.Property<double>("Length")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_length");

                    b.Property<int>("WallId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_doo_wallid");

                    b.HasKey("Id");

                    b.HasIndex("WallId");

                    b.ToTable("t_e_door_doo");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("fur_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FurnitureTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_fur_furnituretypeid");

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("fur_height");

                    b.Property<double>("Length")
                        .HasColumnType("double precision")
                        .HasColumnName("fur_length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("fur_name");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_fur_roomid");

                    b.Property<double>("Width")
                        .HasColumnType("double precision")
                        .HasColumnName("fur_width");

                    b.Property<double>("X")
                        .HasColumnType("double precision")
                        .HasColumnName("fur_x");

                    b.Property<double>("Y")
                        .HasColumnType("double precision")
                        .HasColumnName("fur_y");

                    b.Property<double>("Z")
                        .HasColumnType("double precision")
                        .HasColumnName("fur_Z");

                    b.HasKey("Id");

                    b.HasIndex("FurnitureTypeId");

                    b.HasIndex("RoomId");

                    b.ToTable("t_e_furniture_fur");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.FurnitureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("frt_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("frt_name");

                    b.HasKey("Id");

                    b.ToTable("t_e_furnituretype_frt");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("roo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_roo_buildingid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("roo_code");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_roo_roomtypeid");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("t_e_room_roo");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rty_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("rty_name");

                    b.HasKey("Id");

                    b.ToTable("t_e_roomtype_rty");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sen_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("sen_height");

                    b.Property<double>("Length")
                        .HasColumnType("double precision")
                        .HasColumnName("sen_length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sen_name");

                    b.Property<double>("Width")
                        .HasColumnType("double precision")
                        .HasColumnName("sen_width");

                    b.Property<double>("X")
                        .HasColumnType("double precision")
                        .HasColumnName("sen_x");

                    b.Property<double>("Y")
                        .HasColumnType("double precision")
                        .HasColumnName("sen_y");

                    b.Property<double>("Z")
                        .HasColumnType("double precision")
                        .HasColumnName("sen_Z");

                    b.HasKey("Id");

                    b.ToTable("t_e_sensor_sen");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Wall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("wal_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("wal_height");

                    b.Property<double>("Length")
                        .HasColumnType("double precision")
                        .HasColumnName("wal_length");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_wal_roomid");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("t_e_wall_wal");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Window", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("win_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("win_height");

                    b.Property<double>("Length")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_length");

                    b.Property<int>("WallId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_win_wallid");

                    b.HasKey("Id");

                    b.HasIndex("WallId");

                    b.ToTable("t_e_window_win");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Door", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Wall", "Wall")
                        .WithMany("DoorsOfWall")
                        .HasForeignKey("WallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wall");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Furniture", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.FurnitureType", "Type")
                        .WithMany("FurnituresOfSuchType")
                        .HasForeignKey("FurnitureTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Room", "Room")
                        .WithMany("FurnituresOfRoom")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Room", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Building", "BuildingRoom")
                        .WithMany("RoomsOfBuilding")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomType", "RoomTypeOfRoom")
                        .WithMany("RoomsOfSuchRoomType")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingRoom");

                    b.Navigation("RoomTypeOfRoom");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Wall", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Room", "Room")
                        .WithMany("WallsOfRoom")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Window", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Wall", "Wall")
                        .WithMany("WindowsOfWall")
                        .HasForeignKey("WallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wall");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Building", b =>
                {
                    b.Navigation("RoomsOfBuilding");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.FurnitureType", b =>
                {
                    b.Navigation("FurnituresOfSuchType");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Room", b =>
                {
                    b.Navigation("FurnituresOfRoom");

                    b.Navigation("WallsOfRoom");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomType", b =>
                {
                    b.Navigation("RoomsOfSuchRoomType");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Wall", b =>
                {
                    b.Navigation("DoorsOfWall");

                    b.Navigation("WindowsOfWall");
                });
#pragma warning restore 612, 618
        }
    }
}
