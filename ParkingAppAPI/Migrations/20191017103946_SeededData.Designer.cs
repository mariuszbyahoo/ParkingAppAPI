﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Migrations
{
    [DbContext(typeof(SlotContext))]
    [Migration("20191017103946_SeededData")]
    partial class SeededData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("871bc1d3-b937-4b5f-9899-fe800eefd741"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 0
                        },
                        new
                        {
                            Id = new Guid("e513f252-828e-46d4-9dda-4ffb4172c233"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 1
                        },
                        new
                        {
                            Id = new Guid("812f59e0-2578-4ac4-bed2-a6e6b73db7c2"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 2
                        },
                        new
                        {
                            Id = new Guid("00f31b3b-0fd9-4ec6-8b89-81a9bcce5713"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 3
                        },
                        new
                        {
                            Id = new Guid("64319ac9-8bef-4369-bbfb-5b902da068c1"),
                            IsOccupied = false,
                            posX = 0,
                            posY = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
