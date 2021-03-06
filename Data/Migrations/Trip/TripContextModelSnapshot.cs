﻿// <auto-generated />
using Data.Trips;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data.Migrations.Trip
{
    [DbContext(typeof(TripContext))]
    partial class TripContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Trips.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(500);

                    b.Property<DateTime>("EndDateUtc");

                    b.Property<string>("From")
                        .HasMaxLength(64);

                    b.Property<DateTime>("StartDateUtc");

                    b.Property<string>("Title");

                    b.Property<string>("To")
                        .HasMaxLength(64);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
