﻿// <auto-generated />
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TreWishApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250112201837_AddPaymentStatusToWish")]
    partial class AddPaymentStatusToWish
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TreWishApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "User 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "User 5"
                        });
                });

            modelBuilder.Entity("TreWishApi.Models.Wish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("PurchaserId")
                        .HasColumnType("int");

                    b.Property<string>("WebPageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaserId");

                    b.HasIndex("WisherId");

                    b.ToTable("Wishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Wish 1 Description",
                            Name = "Wish 1",
                            PaymentStatus = 0,
                            Price = 1.1000000000000001,
                            WisherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Wish 2 Description",
                            Name = "Wish 2",
                            PaymentStatus = 0,
                            Price = 2.2000000000000002,
                            PurchaserId = 2,
                            WisherId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Wish 3 Description",
                            Name = "Wish 3",
                            PaymentStatus = 0,
                            Price = 3.2999999999999998,
                            PurchaserId = 2,
                            WisherId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Wish 4 Description",
                            Name = "Wish 4",
                            PaymentStatus = 0,
                            Price = 4.4000000000000004,
                            PurchaserId = 3,
                            WisherId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Wish 5 Description",
                            Name = "Wish 5",
                            PaymentStatus = 0,
                            Price = 5.5,
                            PurchaserId = 1,
                            WisherId = 3
                        });
                });

            modelBuilder.Entity("TreWishApi.Models.Wish", b =>
                {
                    b.HasOne("TreWishApi.Models.User", "Purchaser")
                        .WithMany("PurchasedWishes")
                        .HasForeignKey("PurchaserId");

                    b.HasOne("TreWishApi.Models.User", "Wisher")
                        .WithMany("WishedWishes")
                        .HasForeignKey("WisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchaser");

                    b.Navigation("Wisher");
                });

            modelBuilder.Entity("TreWishApi.Models.User", b =>
                {
                    b.Navigation("PurchasedWishes");

                    b.Navigation("WishedWishes");
                });
#pragma warning restore 612, 618
        }
    }
}
