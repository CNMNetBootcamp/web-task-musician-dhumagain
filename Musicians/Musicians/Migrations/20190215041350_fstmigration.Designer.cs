﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Musicians.Data;
using System;

namespace Musicians.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20190215041350_fstmigration")]
    partial class fstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Musicians.Models.Album", b =>
                {
                    b.Property<int>("AlbumID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumIdentifier");

                    b.Property<string>("AlbumTitle");

                    b.Property<DateTime>("CopyrightDate");

                    b.Property<string>("Format");

                    b.Property<int?>("MusicianID");

                    b.Property<string>("Producer");

                    b.HasKey("AlbumID");

                    b.HasIndex("MusicianID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Musicians.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InstrumentName");

                    b.Property<string>("MusicalFlat");

                    b.Property<int?>("PlayID");

                    b.HasKey("InstrumentID");

                    b.HasIndex("PlayID");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("Musicians.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("PhoneNum");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Musicians.Models.Musician", b =>
                {
                    b.Property<int>("MusicianID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LocationID");

                    b.Property<string>("Name");

                    b.Property<int>("Ssn");

                    b.HasKey("MusicianID");

                    b.HasIndex("LocationID");

                    b.ToTable("Musician");
                });

            modelBuilder.Entity("Musicians.Models.Performance", b =>
                {
                    b.Property<int>("PerformanceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MusicianID");

                    b.HasKey("PerformanceID");

                    b.HasIndex("MusicianID");

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("Musicians.Models.Play", b =>
                {
                    b.Property<int>("PlayID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MusicianID");

                    b.HasKey("PlayID");

                    b.HasIndex("MusicianID");

                    b.ToTable("Play");
                });

            modelBuilder.Entity("Musicians.Models.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int?>("PerformanceID");

                    b.Property<string>("Title");

                    b.HasKey("SongID");

                    b.HasIndex("PerformanceID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("Musicians.Models.Album", b =>
                {
                    b.HasOne("Musicians.Models.Musician", "Musician")
                        .WithMany()
                        .HasForeignKey("MusicianID");
                });

            modelBuilder.Entity("Musicians.Models.Instrument", b =>
                {
                    b.HasOne("Musicians.Models.Play", "Play")
                        .WithMany("Instrument")
                        .HasForeignKey("PlayID");
                });

            modelBuilder.Entity("Musicians.Models.Musician", b =>
                {
                    b.HasOne("Musicians.Models.Location", "Location")
                        .WithMany("Musician")
                        .HasForeignKey("LocationID");
                });

            modelBuilder.Entity("Musicians.Models.Performance", b =>
                {
                    b.HasOne("Musicians.Models.Musician", "Musician")
                        .WithMany("Performance")
                        .HasForeignKey("MusicianID");
                });

            modelBuilder.Entity("Musicians.Models.Play", b =>
                {
                    b.HasOne("Musicians.Models.Musician", "Musician")
                        .WithMany("Play")
                        .HasForeignKey("MusicianID");
                });

            modelBuilder.Entity("Musicians.Models.Song", b =>
                {
                    b.HasOne("Musicians.Models.Performance", "Performance")
                        .WithMany("Song")
                        .HasForeignKey("PerformanceID");
                });
#pragma warning restore 612, 618
        }
    }
}