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
    [Migration("20250116163553_final")]
    partial class final
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bui_name");

                    b.HasKey("Id");

                    b.ToTable("t_e_building_bui");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("roo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("roo_height");

                    b.Property<int>("IdBuilding")
                        .HasColumnType("integer")
                        .HasColumnName("fk_roo_buildingid");

                    b.Property<int>("IdRoomType")
                        .HasColumnType("integer")
                        .HasColumnName("fk_roo_idroomtype");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("roo_name");

                    b.Property<double>("NorthOrientation")
                        .HasColumnType("double precision")
                        .HasColumnName("roo_northorientation");

                    b.HasKey("Id");

                    b.HasIndex("IdBuilding");

                    b.HasIndex("IdRoomType");

                    b.ToTable("t_e_room_roo");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rob_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomName")
                        .HasColumnType("text")
                        .HasColumnName("rob_name");

                    b.Property<int>("IdRoom")
                        .HasColumnType("integer")
                        .HasColumnName("rob_roomid");

                    b.HasKey("Id");

                    b.HasIndex("IdRoom");

                    b.ToTable("t_e_roomobject_rob");

                    b.UseTptMappingStrategy();
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
                        .HasColumnType("text")
                        .HasColumnName("rty_name");

                    b.HasKey("Id");

                    b.ToTable("t_e_roomtype_rty");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject");

                    b.Property<string>("CustomId")
                        .HasColumnType("text")
                        .HasColumnName("cobj_id");

                    b.ToTable("t_e_connectedobjects_cobj");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.CustomObject", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject");

                    b.Property<int>("Color")
                        .HasColumnType("integer")
                        .HasColumnName("cus_color");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_rotz");

                    b.Property<double>("SizeX")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_sizex");

                    b.Property<double>("SizeY")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_sizey");

                    b.Property<double>("SizeZ")
                        .HasColumnType("double precision")
                        .HasColumnName("cus_sizez");

                    b.ToTable("t_e_customobject_cus");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Door", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject");

                    b.Property<double>("Orientation")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_orientation");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_posz");

                    b.Property<double>("SizeX")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_sizex");

                    b.Property<double>("SizeY")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_sizey");

                    b.Property<double>("SizeZ")
                        .HasColumnType("double precision")
                        .HasColumnName("doo_sizez");

                    b.ToTable("t_e_door_doo");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Heater", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject");

                    b.Property<double>("Orientation")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_orientation");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_posz");

                    b.Property<double>("SizeX")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_sizex");

                    b.Property<double>("SizeY")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_sizey");

                    b.Property<double>("SizeZ")
                        .HasColumnType("double precision")
                        .HasColumnName("hea_sizez");

                    b.ToTable("t_e_heater_hea");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Table", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject");

                    b.Property<double>("Orientation")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_orientation");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_posz");

                    b.Property<double>("SizeX")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_sizex");

                    b.Property<double>("SizeY")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_sizey");

                    b.Property<double>("SizeZ")
                        .HasColumnType("double precision")
                        .HasColumnName("tab_sizez");

                    b.ToTable("t_e_table_tab");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Window", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject");

                    b.Property<double>("Orientation")
                        .HasColumnType("double precision")
                        .HasColumnName("win_orientation");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("win_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("win_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("win_posz");

                    b.Property<double>("SizeX")
                        .HasColumnType("double precision")
                        .HasColumnName("win_sizex");

                    b.Property<double>("SizeY")
                        .HasColumnType("double precision")
                        .HasColumnName("win_sizey");

                    b.Property<double>("SizeZ")
                        .HasColumnType("double precision")
                        .HasColumnName("win_sizez");

                    b.ToTable("t_e_window_win");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Lamp", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("lam_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("lam_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("lam_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("lam_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("lam_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("lam_rotz");

                    b.ToTable("t_e_lamp_lam");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Plug", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("plu_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("plu_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("plu_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("plu_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("plu_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("plu_rotz");

                    b.ToTable("t_e_plug_plu");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Sensor6in1", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("sio_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("sio_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("sio_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("sio_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("sio_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("sio_rotz");

                    b.ToTable("t_e_sensor6in1_sio");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Sensor9in1", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("nio_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("nio_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("nio_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("nio_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("nio_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("nio_rotz");

                    b.ToTable("t_e_sensor9in1_nio");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.SensorCO2", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("co2_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("co2_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("co2_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("co2_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("co2_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("co2_rotz");

                    b.ToTable("t_e_sensorco2_co2");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Siren", b =>
                {
                    b.HasBaseType("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject");

                    b.Property<double>("PosX")
                        .HasColumnType("double precision")
                        .HasColumnName("sir_posx");

                    b.Property<double>("PosY")
                        .HasColumnType("double precision")
                        .HasColumnName("sir_posy");

                    b.Property<double>("PosZ")
                        .HasColumnType("double precision")
                        .HasColumnName("sir_posz");

                    b.Property<double>("RotX")
                        .HasColumnType("double precision")
                        .HasColumnName("sir_rotx");

                    b.Property<double>("RotY")
                        .HasColumnType("double precision")
                        .HasColumnName("sir_roty");

                    b.Property<double>("RotZ")
                        .HasColumnType("double precision")
                        .HasColumnName("sir_rotz");

                    b.ToTable("t_e_siren_sir");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Room", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("IdBuilding")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("IdRoomType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("SAE501_Blazor_API.Models.EntityFramework.Vector2D", "Base", b1 =>
                        {
                            b1.Property<int>("RoomId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<double>("X")
                                .HasColumnType("double precision");

                            b1.Property<double>("Y")
                                .HasColumnType("double precision");

                            b1.HasKey("RoomId", "Id");

                            b1.ToTable("t_e_room_roo");

                            b1.ToJson("Base");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.Navigation("Base");

                    b.Navigation("Building");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.Room", "Room")
                        .WithMany("ObjectsOfRoom")
                        .HasForeignKey("IdRoom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.CustomObject", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.CustomObject", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Door", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Door", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Heater", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Heater", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Table", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Table", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Window", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.RoomObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.Window", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Lamp", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Lamp", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Plug", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Plug", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Sensor6in1", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Sensor6in1", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Sensor9in1", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Sensor9in1", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.SensorCO2", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.SensorCO2", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Siren", b =>
                {
                    b.HasOne("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.ConnectedObject", null)
                        .WithOne()
                        .HasForeignKey("SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects.Siren", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Building", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.Room", b =>
                {
                    b.Navigation("ObjectsOfRoom");
                });

            modelBuilder.Entity("SAE501_Blazor_API.Models.EntityFramework.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
