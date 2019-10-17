﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Migrations
{
    [DbContext(typeof(SlotContext))]
    partial class SlotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingAppAPI.Slot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<int>("posX")
                        .HasColumnType("int");

                    b.Property<int>("posY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("slots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("894a69be-592f-42bf-b01f-813fe991a916"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 0
                        },
                        new
                        {
                            Id = new Guid("5975e9c8-b086-4277-a5e7-23d9160b5625"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 1
                        },
                        new
                        {
                            Id = new Guid("5fc199eb-b015-4203-ae99-022d47ebfa34"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 2
                        },
                        new
                        {
                            Id = new Guid("4afb706a-1d15-4d4c-b8e8-0f5a6a255235"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 3
                        },
                        new
                        {
                            Id = new Guid("0a1682d7-cab4-4aa9-8281-3adeeccc6e1a"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
