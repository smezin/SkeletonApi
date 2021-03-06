// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkeletonApi.Contexts;

namespace SkeletonApi.Migrations
{
    [DbContext(typeof(SkeletonContext))]
    [Migration("20220606193441_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkeletonApi.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Cars",
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6005)
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Planes",
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6459)
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Trucks",
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6468)
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Boats",
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6469)
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Rockets",
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 854, DateTimeKind.Utc).AddTicks(6471)
                        });
                });

            modelBuilder.Entity("SkeletonApi.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(10000);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(337),
                            Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included).Power it up and let it go!",
                            ImagePath = "carconvert.png",
                            ProductName = "Convertible Car",
                            UnitPrice = 22.5
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(488),
                            Description = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                            ImagePath = "carearly.png",
                            ProductName = "Old-time Car",
                            UnitPrice = 15.949999999999999
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 1,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(491),
                            Description = "Yes this car is fast, but it also floats in water.",
                            ImagePath = "carfast.png",
                            ProductName = "Fast Car",
                            UnitPrice = 32.990000000000002
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 1,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(532),
                            Description = "Use this super fast car to entertain guests. Lights and doors work!",
                            ImagePath = "carfaster.png",
                            ProductName = "Super Fast Car",
                            UnitPrice = 8.9499999999999993
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 1,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(533),
                            Description = "This old style racer can fly (with user assistance). Gravity controls flight duration.No batteries required.",
                            ImagePath = "carracer.png",
                            ProductName = "Old Style Racer",
                            UnitPrice = 34.950000000000003
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 2,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(538),
                            Description = "Authentic airplane toy. Features realistic color and details.",
                            ImagePath = "planeace.png",
                            ProductName = "Ace Plane",
                            UnitPrice = 95.0
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryID = 2,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(540),
                            Description = "This fun glider is made from real balsa wood. Some assembly required.",
                            ImagePath = "planeglider.png",
                            ProductName = "Glider",
                            UnitPrice = 4.9500000000000002
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryID = 2,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(541),
                            Description = "This paper plane is like no other paper plane. Some folding required.",
                            ImagePath = "planepaper.png",
                            ProductName = "Paper Plane",
                            UnitPrice = 2.9500000000000002
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryID = 2,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(542),
                            Description = "Rubber band powered plane features two wheels.",
                            ImagePath = "planeprop.png",
                            ProductName = "Propeller Plane",
                            UnitPrice = 32.950000000000003
                        },
                        new
                        {
                            ProductID = 10,
                            CategoryID = 3,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(545),
                            Description = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                            ImagePath = "truckearly.png",
                            ProductName = "Early Truck",
                            UnitPrice = 15.0
                        },
                        new
                        {
                            ProductID = 11,
                            CategoryID = 3,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(546),
                            Description = "You will have endless fun with this one quarter sized fire truck.",
                            ImagePath = "truckfire.png",
                            ProductName = "Fire Truck",
                            UnitPrice = 26.0
                        },
                        new
                        {
                            ProductID = 12,
                            CategoryID = 3,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(548),
                            Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                            ImagePath = "truckbig.png",
                            ProductName = "Big Truck",
                            UnitPrice = 29.0
                        },
                        new
                        {
                            ProductID = 13,
                            CategoryID = 4,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(549),
                            Description = "Is it a boat or a ship. Let this floating vehicle decide by using its artifically intelligent computer brain!",
                            ImagePath = "boatbig.png",
                            ProductName = "Big Ship",
                            UnitPrice = 95.0
                        },
                        new
                        {
                            ProductID = 14,
                            CategoryID = 4,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(550),
                            Description = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!Some folding required.",
                            ImagePath = "boatpaper.png",
                            ProductName = "Paper Boat",
                            UnitPrice = 4.9500000000000002
                        },
                        new
                        {
                            ProductID = 15,
                            CategoryID = 4,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(551),
                            Description = "Put this fun toy sail boat in the water and let it go!",
                            ImagePath = "boatsail.png",
                            ProductName = "Sail Boat",
                            UnitPrice = 42.950000000000003
                        },
                        new
                        {
                            ProductID = 16,
                            CategoryID = 5,
                            CreatedAt = new DateTime(2022, 6, 6, 19, 34, 40, 858, DateTimeKind.Utc).AddTicks(553),
                            Description = "This fun rocket will travel up to a height of 200 feet.",
                            ImagePath = "rocket.png",
                            ProductName = "Rocket",
                            UnitPrice = 122.95
                        });
                });

            modelBuilder.Entity("SkeletonApi.Models.Entities.Product", b =>
                {
                    b.HasOne("SkeletonApi.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
