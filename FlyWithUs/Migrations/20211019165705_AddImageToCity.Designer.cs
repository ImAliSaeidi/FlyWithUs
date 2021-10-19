﻿// <auto-generated />
using System;
using FlyWithUs.Hosted.Service.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlyWithUs.Hosted.Service.Migrations
{
    [DbContext(typeof(FlyWithUsContext))]
    [Migration("20211019165705_AddImageToCity")]
    partial class AddImageToCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Agancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Agancies");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgancyId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("AgancyId");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("TrackingCode")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Orders.PaymentResultView", b =>
                {
                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MovingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MovingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToView("PaymentResultViews");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.OrderTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TicketId");

                    b.ToTable("OrderTickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgancyId")
                        .HasColumnType("int");

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ArrivingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationAirportId")
                        .HasColumnType("int");

                    b.Property<int>("DestinationCityId")
                        .HasColumnType("int");

                    b.Property<int>("DestinationCountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MovingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OriginAirportId")
                        .HasColumnType("int");

                    b.Property<int>("OriginCityId")
                        .HasColumnType("int");

                    b.Property<int>("OriginCountryId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("AgancyId");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("DestinationAirportId");

                    b.HasIndex("DestinationCityId");

                    b.HasIndex("DestinationCountryId");

                    b.HasIndex("OriginAirportId");

                    b.HasIndex("OriginCityId");

                    b.HasIndex("OriginCountryId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.TravelView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgancyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirplaneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ArrivingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationCountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MovingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("TravelCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToView("TravelViews");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = "1af962a6-d464-467f-8fea-8f6e9c4be780",
                            ConcurrencyStamp = "1ddaccdc-f6e7-45cf-9859-b014c0b76d85",
                            IsDeleted = false,
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "586faa77-67b7-477e-849f-e174c7924f95",
                            ConcurrencyStamp = "7b8f1fce-5c26-454c-b7a8-4a61d518de01",
                            IsDeleted = false,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstNameEnglish")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstNamePersian")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Gender")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastNameEnglish")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastNamePersian")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalityCode")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("PassportExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PassportIssunaceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportNumber")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ISO2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ISO3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PersianName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<short>("PhoneCode")
                        .HasMaxLength(5)
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Airplane", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Airplanes.Agancy", "Agancy")
                        .WithMany("Airplanes")
                        .HasForeignKey("AgancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agancy");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Orders.Order", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Users.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.OrderTicket", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Orders.Order", "Order")
                        .WithMany("OrderTickets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", "Ticket")
                        .WithMany("OrderTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Travels.Travel", "Travel")
                        .WithMany("Tickets")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.Travel", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Airplanes.Agancy", "Agancy")
                        .WithMany("Travels")
                        .HasForeignKey("AgancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.Airplanes.Airplane", "Airplane")
                        .WithMany("Travels")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Airport", "DestinationAirport")
                        .WithMany("IncomingTravels")
                        .HasForeignKey("DestinationAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.City", "DestinationCity")
                        .WithMany("IncomingTravels")
                        .HasForeignKey("DestinationCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Country", "DestinationCountry")
                        .WithMany("IncomingTravels")
                        .HasForeignKey("DestinationCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Airport", "OriginAirport")
                        .WithMany("OutboundTravels")
                        .HasForeignKey("OriginAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.City", "OriginCity")
                        .WithMany("OutboundTravels")
                        .HasForeignKey("OriginCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Country", "OriginCountry")
                        .WithMany("OutboundTravels")
                        .HasForeignKey("OriginCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agancy");

                    b.Navigation("Airplane");

                    b.Navigation("DestinationAirport");

                    b.Navigation("DestinationCity");

                    b.Navigation("DestinationCountry");

                    b.Navigation("OriginAirport");

                    b.Navigation("OriginCity");

                    b.Navigation("OriginCountry");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.ApplicationUserRole", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Users.ApplicationRole", "Role")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyWithUs.Hosted.Service.Models.Users.ApplicationUser", "User")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Airport", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.City", "City")
                        .WithMany("Airports")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.City", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Agancy", b =>
                {
                    b.Navigation("Airplanes");

                    b.Navigation("Travels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Airplane", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Orders.Order", b =>
                {
                    b.Navigation("OrderTickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", b =>
                {
                    b.Navigation("OrderTickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.Travel", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Airport", b =>
                {
                    b.Navigation("IncomingTravels");

                    b.Navigation("OutboundTravels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.City", b =>
                {
                    b.Navigation("Airports");

                    b.Navigation("IncomingTravels");

                    b.Navigation("OutboundTravels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("IncomingTravels");

                    b.Navigation("OutboundTravels");
                });
#pragma warning restore 612, 618
        }
    }
}
