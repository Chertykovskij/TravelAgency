﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgency.Data;

#nullable disable

namespace TravelAgency.Migrations
{
    [DbContext(typeof(TravelAgencyContext))]
    [Migration("20230427161755_AddTitleInTour")]
    partial class AddTitleInTour
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelHotelFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HotelFacilityId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelFacilityId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelHotelFacility");
                });

            modelBuilder.Entity("HotelRoomAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomAmenityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomAmenityId");

                    b.ToTable("HotelRoomAmenity");
                });

            modelBuilder.Entity("TourTravelService", b =>
                {
                    b.Property<int>("IncludedServicesId")
                        .HasColumnType("int");

                    b.Property<int>("NotIcludedToursId")
                        .HasColumnType("int");

                    b.HasKey("IncludedServicesId", "NotIcludedToursId");

                    b.HasIndex("NotIcludedToursId");

                    b.ToTable("TourIncludedServices", (string)null);
                });

            modelBuilder.Entity("TourTravelService1", b =>
                {
                    b.Property<int>("IncludedToursId")
                        .HasColumnType("int");

                    b.Property<int>("NotIncludedServicesId")
                        .HasColumnType("int");

                    b.HasKey("IncludedToursId", "NotIncludedServicesId");

                    b.HasIndex("NotIncludedServicesId");

                    b.ToTable("TourNotIncludedServices", (string)null);
                });

            modelBuilder.Entity("TravelAgency.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelAgency.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("HotelStarRatingId")
                        .HasColumnType("int");

                    b.Property<int>("MealTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("HotelStarRatingId");

                    b.HasIndex("MealTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAgency.Models.HotelFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("HotelFacility");
                });

            modelBuilder.Entity("TravelAgency.Models.HotelStarRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HotelStarRating");
                });

            modelBuilder.Entity("TravelAgency.Models.MealType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("TravelAgency.Models.RoomAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("RoomAmenity");
                });

            modelBuilder.Entity("TravelAgency.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("IncludedServicesId")
                        .HasColumnType("int");

                    b.Property<int>("NotIncludedServicesId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TravelAgency.Models.TravelService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("TravelService");
                });

            modelBuilder.Entity("HotelHotelFacility", b =>
                {
                    b.HasOne("TravelAgency.Models.HotelFacility", null)
                        .WithMany()
                        .HasForeignKey("HotelFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelRoomAmenity", b =>
                {
                    b.HasOne("TravelAgency.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Models.RoomAmenity", null)
                        .WithMany()
                        .HasForeignKey("RoomAmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TourTravelService", b =>
                {
                    b.HasOne("TravelAgency.Models.TravelService", null)
                        .WithMany()
                        .HasForeignKey("IncludedServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("NotIcludedToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TourTravelService1", b =>
                {
                    b.HasOne("TravelAgency.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("IncludedToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Models.TravelService", null)
                        .WithMany()
                        .HasForeignKey("NotIncludedServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Models.Hotel", b =>
                {
                    b.HasOne("TravelAgency.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Models.HotelStarRating", "HotelStarRating")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelStarRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Models.MealType", "MealType")
                        .WithMany("Hotels")
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("HotelStarRating");

                    b.Navigation("MealType");
                });

            modelBuilder.Entity("TravelAgency.Models.Tour", b =>
                {
                    b.HasOne("TravelAgency.Models.Hotel", "Hotel")
                        .WithMany("Tour")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAgency.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TravelAgency.Models.Hotel", b =>
                {
                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TravelAgency.Models.HotelStarRating", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TravelAgency.Models.MealType", b =>
                {
                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}
