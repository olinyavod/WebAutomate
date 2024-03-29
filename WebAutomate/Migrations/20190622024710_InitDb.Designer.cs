﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAutomate;

namespace WebAutomate.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190622024710_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAutomate.Models.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<bool>("IsBlocked");

                    b.Property<decimal>("Nominal");

                    b.HasKey("Id");

                    b.ToTable("Coins");

                    b.HasData(
                        new { Id = 1, Count = 100, IsBlocked = false, Nominal = 1m },
                        new { Id = 2, Count = 100, IsBlocked = false, Nominal = 2m },
                        new { Id = 3, Count = 50, IsBlocked = false, Nominal = 5m },
                        new { Id = 4, Count = 30, IsBlocked = false, Nominal = 10m }
                    );
                });

            modelBuilder.Entity("WebAutomate.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Count = 10, ImageUrl = "images\\coca-cola.svg", Name = "Coca-Cola", Price = 60m },
                        new { Id = 2, Count = 20, ImageUrl = "images\\sprite.svg", Name = "Sprite", Price = 50m },
                        new { Id = 3, Count = 5, ImageUrl = "images\\fanta.svg", Name = "Fanta", Price = 55m },
                        new { Id = 4, Count = 0, ImageUrl = "images\\7-Up.svg", Name = "7-up", Price = 0m }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
