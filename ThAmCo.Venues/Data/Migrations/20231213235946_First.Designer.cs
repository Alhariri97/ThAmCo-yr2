﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Venues.Data;

#nullable disable

namespace ThAmCo.Venues.Data.Migrations
{
    [DbContext(typeof(VenuesDbContext))]
    [Migration("20231213235946_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("ThAmCo.Venues.Data.Availability", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("VenueCode")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<double>("CostPerHour")
                        .HasColumnType("REAL");

                    b.HasKey("Date", "VenueCode");

                    b.HasIndex("VenueCode");

                    b.ToTable("Availabilities");

                    b.HasData(
                        new
                        {
                            Date = new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 51.789999999999999
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 46.770000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 72.069999999999993
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 57.18
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 91.030000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 61.130000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 139.55000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 96.379999999999995
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 92.689999999999998
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 59.859999999999999
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 95.010000000000005
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 57.450000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 55.439999999999998
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 79.260000000000005
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 80.489999999999995
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 97.650000000000006
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 57.399999999999999
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 58.020000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 50.630000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 78.489999999999995
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 94.670000000000002
                        },
                        new
                        {
                            Date = new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 32.43
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 68.049999999999997
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 92.519999999999996
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 53.119999999999997
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 49.280000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 104.76000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 30.91
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 99.439999999999998
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 69.359999999999999
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 76.140000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 64.019999999999996
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 51.479999999999997
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 112.88
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 109.15000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 115.89
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 64.030000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 53.840000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 40.109999999999999
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 92.319999999999993
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 76.810000000000002
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 43.719999999999999
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 80.659999999999997
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 42.299999999999997
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 51.560000000000002
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 87.870000000000005
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 48.590000000000003
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 84.980000000000004
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 35.850000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 80.769999999999996
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 83.709999999999994
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 91.530000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 132.13
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 104.41
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 114.65000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 50.390000000000001
                        },
                        new
                        {
                            Date = new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 95.829999999999998
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 62.539999999999999
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 78.430000000000007
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 77.700000000000003
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 33.030000000000001
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 110.11
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 77.640000000000001
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 130.16999999999999
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 35.670000000000002
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 101.31999999999999
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 53.219999999999999
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 74.150000000000006
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 102.22
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 44.049999999999997
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 99.879999999999995
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 115.3
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 53.810000000000002
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "CRKHL",
                            CostPerHour = 72.340000000000003
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "FDLCK",
                            CostPerHour = 52.939999999999998
                        },
                        new
                        {
                            Date = new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VenueCode = "TNDMR",
                            CostPerHour = 112.63
                        });
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.EventType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            Id = "CON",
                            Title = "Conference"
                        },
                        new
                        {
                            Id = "MET",
                            Title = "Meeting"
                        },
                        new
                        {
                            Id = "PTY",
                            Title = "Party"
                        },
                        new
                        {
                            Id = "WED",
                            Title = "Wedding"
                        });
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Reservation", b =>
                {
                    b.Property<string>("Reference")
                        .HasMaxLength(13)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VenueCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<DateTime>("WhenMade")
                        .HasColumnType("TEXT");

                    b.HasKey("Reference");

                    b.HasIndex("EventDate", "VenueCode")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Suitability", b =>
                {
                    b.Property<string>("EventTypeId")
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<string>("VenueCode")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.HasKey("EventTypeId", "VenueCode");

                    b.HasIndex("VenueCode");

                    b.ToTable("Suitabilities");

                    b.HasData(
                        new
                        {
                            EventTypeId = "WED",
                            VenueCode = "CRKHL"
                        },
                        new
                        {
                            EventTypeId = "CON",
                            VenueCode = "CRKHL"
                        },
                        new
                        {
                            EventTypeId = "PTY",
                            VenueCode = "CRKHL"
                        },
                        new
                        {
                            EventTypeId = "WED",
                            VenueCode = "TNDMR"
                        },
                        new
                        {
                            EventTypeId = "CON",
                            VenueCode = "TNDMR"
                        },
                        new
                        {
                            EventTypeId = "MET",
                            VenueCode = "TNDMR"
                        },
                        new
                        {
                            EventTypeId = "WED",
                            VenueCode = "FDLCK"
                        },
                        new
                        {
                            EventTypeId = "PTY",
                            VenueCode = "FDLCK"
                        });
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Venue", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT")
                        .IsFixedLength();

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            Code = "CRKHL",
                            Capacity = 150,
                            Description = "Once the residence of Lord and Lady Crackling, this lavish dwelling remains a prime example of 18th century fine living.",
                            Name = "Crackling Hall"
                        },
                        new
                        {
                            Code = "TNDMR",
                            Capacity = 450,
                            Description = "Refurbished manor house with fully equipped facilities ready to help you have a good time in business or pleasure.",
                            Name = "Tinder Manor"
                        },
                        new
                        {
                            Code = "FDLCK",
                            Capacity = 85,
                            Description = "Rustic pub set in ideallic countryside, the original venue of a notorious local musician and his parrot.",
                            Name = "The Fiddler's Cockatoo"
                        });
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Availability", b =>
                {
                    b.HasOne("ThAmCo.Venues.Data.Venue", "Venue")
                        .WithMany("AvailableDates")
                        .HasForeignKey("VenueCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Reservation", b =>
                {
                    b.HasOne("ThAmCo.Venues.Data.Availability", "Availability")
                        .WithOne("Reservation")
                        .HasForeignKey("ThAmCo.Venues.Data.Reservation", "EventDate", "VenueCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Availability");
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Suitability", b =>
                {
                    b.HasOne("ThAmCo.Venues.Data.EventType", "EventType")
                        .WithMany("SuitableVenues")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Venues.Data.Venue", "Venue")
                        .WithMany("SuitableEventTypes")
                        .HasForeignKey("VenueCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Availability", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.EventType", b =>
                {
                    b.Navigation("SuitableVenues");
                });

            modelBuilder.Entity("ThAmCo.Venues.Data.Venue", b =>
                {
                    b.Navigation("AvailableDates");

                    b.Navigation("SuitableEventTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
