﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGameLibrary.Data;

#nullable disable

namespace GameLibraryWebApp.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20230223163946_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameLibraryWebApp.Models.BoardGameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublishersId");

                    b.ToTable("BoardGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Control one fantasy race after another to expand throught the land",
                            ImageURL = "https://cf.geekdo-images.com/aoPM07XzoceB-RydLh08zA__imagepage/img/lHmv0ddOrUvpiLcPeQbZdT5yCEA=/fit-in/900x600/filters:no_upscale():strip_icc()/pic428828.jpg",
                            Name = "SmallWorld",
                            PublishersId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Attract a beautiful and diversecollection of birds to your wildlife preserve.",
                            ImageURL = "https://cf.geekdo-images.com/yLZJCVLlIx4c7eJEWUNJ7w__imagepagezoom/img/yS4vL6iTCvHSvGySxyOjV_-R3dI=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic4458123.jpg",
                            Name = "WingSpan",
                            PublishersId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Hasbro Gaming Trouble Board Game for Kids Ages 5 and Up 2-4 Players",
                            ImageURL = "https://m.media-amazon.com/images/I/81MdgnO4l9L._AC_UL400_.jpg",
                            Name = "Trouble",
                            PublishersId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Hasbro Gaming The Game of Life Board Game Ages 8 & Up",
                            ImageURL = "https://m.media-amazon.com/images/I/81yQxkx3vwL._AC_UL640_QL65_.jpg",
                            Name = "The Game of Life",
                            PublishersId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Hasbro Gaming Candy Land Kingdom Of Sweet Adventures Board Game For Kids Ages",
                            ImageURL = "https://m.media-amazon.com/images/I/91yUG40gv0L._AC_UL400_.jpg",
                            Name = "Candy Land",
                            PublishersId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "Hasbro Gaming Risk Military Wargame",
                            ImageURL = "https://m.media-amazon.com/images/I/91jsvpbPP3L._AC_UL400_.jpg",
                            Name = "Risk",
                            PublishersId = 3
                        },
                        new
                        {
                            Id = 7,
                            Description = "Ticket to Ride Board Game | Family Board Game | Board Game for Adults and Family",
                            ImageURL = "https://m.media-amazon.com/images/I/91YNJM4oyhL._AC_UL400_.jpg",
                            Name = "Ticket to ride",
                            PublishersId = 1
                        },
                        new
                        {
                            Id = 8,
                            Description = "SORRY Classic Family Board Game Indoor Outdoor Retro Party Activity Summer Toy with Oversized Gameboard",
                            ImageURL = "https://m.media-amazon.com/images/I/81ItkRyOaaL._AC_UL400_.jpg",
                            Name = "Sorry",
                            PublishersId = 4
                        });
                });

            modelBuilder.Entity("GameLibraryWebApp.Models.PublisherModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Days of Wonder"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Stonemaier Games"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hasbro"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Spin Master"
                        });
                });

            modelBuilder.Entity("GameLibraryWebApp.Models.BoardGameModel", b =>
                {
                    b.HasOne("GameLibraryWebApp.Models.PublisherModel", "Publishers")
                        .WithMany("BoardGames")
                        .HasForeignKey("PublishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("GameLibraryWebApp.Models.PublisherModel", b =>
                {
                    b.Navigation("BoardGames");
                });
#pragma warning restore 612, 618
        }
    }
}
