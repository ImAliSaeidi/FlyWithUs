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
    [Migration("20210914174017_Mig-Update-Airport2")]
    partial class MigUpdateAirport2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
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

                    b.Property<int?>("AgancyId")
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

                    b.Property<int?>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.UserTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.MultiPartTravel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("MultiPartTravels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.Travel", b =>
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

                    b.Property<int?>("DestinationCityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("OriginCityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationCityId");

                    b.HasIndex("OriginCityId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.TravelDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirplaneId")
                        .HasColumnType("int");

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

                    b.Property<int?>("DestinationAirportId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MovingTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginAirportId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("DestinationAirportId");

                    b.HasIndex("OriginAirportId");

                    b.HasIndex("TravelId");

                    b.ToTable("TravelDetails");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.Role", b =>
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

                    b.ToTable("Role");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BirthdateAD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstNameEnglish")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstNamePersian")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastNameEnglish")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastNamePersian")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("NationalityCode")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("PassportExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportIssunaceDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("NiceName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<short>("NumCode")
                        .HasMaxLength(6)
                        .HasColumnType("smallint");

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
                        .HasForeignKey("AgancyId");

                    b.Navigation("Agancy");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Travels.Travel", "Travel")
                        .WithMany("Tickets")
                        .HasForeignKey("TravelId");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.UserTicket", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", "Ticket")
                        .WithMany("UserTickets")
                        .HasForeignKey("TicketId");

                    b.HasOne("FlyWithUs.Hosted.Service.Models.Users.User", "User")
                        .WithMany("Usertickets")
                        .HasForeignKey("UserId");

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.MultiPartTravel", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Travels.Travel", "Travel")
                        .WithMany("MultiPartTravels")
                        .HasForeignKey("TravelId");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.Travel", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.City", "DestinationCity")
                        .WithMany("IncomingTravels")
                        .HasForeignKey("DestinationCityId");

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.City", "OriginCity")
                        .WithMany("OutboundTravels")
                        .HasForeignKey("OriginCityId");

                    b.Navigation("DestinationCity");

                    b.Navigation("OriginCity");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.TravelDetail", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Airplanes.Airplane", "Airplane")
                        .WithMany("Traveldetails")
                        .HasForeignKey("AirplaneId");

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Airport", "DestinationAirport")
                        .WithMany("IncomingTravelDetails")
                        .HasForeignKey("DestinationAirportId");

                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Airport", "OriginAirport")
                        .WithMany("OutboundTravelDetails")
                        .HasForeignKey("OriginAirportId");

                    b.HasOne("FlyWithUs.Hosted.Service.Models.Travels.Travel", "Travel")
                        .WithMany("TravelDetails")
                        .HasForeignKey("TravelId");

                    b.Navigation("Airplane");

                    b.Navigation("DestinationAirport");

                    b.Navigation("OriginAirport");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.UserRole", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.Users.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("FlyWithUs.Hosted.Service.Models.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Airport", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.City", "City")
                        .WithMany("Airports")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.City", b =>
                {
                    b.HasOne("FlyWithUs.Hosted.Service.Models.World.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Agancy", b =>
                {
                    b.Navigation("Airplanes");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Airplanes.Airplane", b =>
                {
                    b.Navigation("Traveldetails");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Tickets.Ticket", b =>
                {
                    b.Navigation("UserTickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Travels.Travel", b =>
                {
                    b.Navigation("MultiPartTravels");

                    b.Navigation("Tickets");

                    b.Navigation("TravelDetails");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.Users.User", b =>
                {
                    b.Navigation("UserRoles");

                    b.Navigation("Usertickets");
                });

            modelBuilder.Entity("FlyWithUs.Hosted.Service.Models.World.Airport", b =>
                {
                    b.Navigation("IncomingTravelDetails");

                    b.Navigation("OutboundTravelDetails");
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
                });
#pragma warning restore 612, 618
        }
    }
}
