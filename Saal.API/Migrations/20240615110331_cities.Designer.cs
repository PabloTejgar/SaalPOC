﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saal.API.Data;

#nullable disable

namespace Saal.API.Migrations
{
    [DbContext(typeof(SaalContext))]
    [Migration("20240615110331_cities")]
    partial class cities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Saal.API.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Saal.API.Models.City", b =>
                {
                    b.HasOne("Saal.API.Models.City", null)
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("Saal.API.Models.City", b =>
                {
                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}