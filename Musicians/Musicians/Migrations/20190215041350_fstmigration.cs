using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Musicians.Migrations
{
    public partial class fstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Musician",
                columns: table => new
                {
                    MusicianID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Ssn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician", x => x.MusicianID);
                    table.ForeignKey(
                        name: "FK_Musician_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumIdentifier = table.Column<string>(nullable: true),
                    AlbumTitle = table.Column<string>(nullable: true),
                    CopyrightDate = table.Column<DateTime>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    MusicianID = table.Column<int>(nullable: true),
                    Producer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Album_Musician_MusicianID",
                        column: x => x.MusicianID,
                        principalTable: "Musician",
                        principalColumn: "MusicianID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    PerformanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MusicianID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.PerformanceID);
                    table.ForeignKey(
                        name: "FK_Performance_Musician_MusicianID",
                        column: x => x.MusicianID,
                        principalTable: "Musician",
                        principalColumn: "MusicianID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Play",
                columns: table => new
                {
                    PlayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MusicianID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Play", x => x.PlayID);
                    table.ForeignKey(
                        name: "FK_Play_Musician_MusicianID",
                        column: x => x.MusicianID,
                        principalTable: "Musician",
                        principalColumn: "MusicianID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    PerformanceID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Song_Performance_PerformanceID",
                        column: x => x.PerformanceID,
                        principalTable: "Performance",
                        principalColumn: "PerformanceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    InstrumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstrumentName = table.Column<string>(nullable: true),
                    MusicalFlat = table.Column<string>(nullable: true),
                    PlayID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.InstrumentID);
                    table.ForeignKey(
                        name: "FK_Instrument_Play_PlayID",
                        column: x => x.PlayID,
                        principalTable: "Play",
                        principalColumn: "PlayID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_MusicianID",
                table: "Album",
                column: "MusicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_PlayID",
                table: "Instrument",
                column: "PlayID");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_LocationID",
                table: "Musician",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_MusicianID",
                table: "Performance",
                column: "MusicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Play_MusicianID",
                table: "Play",
                column: "MusicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Song_PerformanceID",
                table: "Song",
                column: "PerformanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Play");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
