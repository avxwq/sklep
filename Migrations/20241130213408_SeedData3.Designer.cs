﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sklep.Models;

#nullable disable

namespace sklep.Migrations
{
    [DbContext(typeof(SklepContext))]
    [Migration("20241130213408_SeedData3")]
    partial class SeedData3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("sklep.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("sklep.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("sklep.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Indoor Plants"
                        });
                });

            modelBuilder.Entity("sklep.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("sklep.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("sklep.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Description for plant 1",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 1",
                            Price = 1.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Description for plant 2",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 2",
                            Price = 3m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Description for plant 3",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 3",
                            Price = 4.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Description for plant 4",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 4",
                            Price = 6m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Description for plant 5",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 5",
                            Price = 7.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "Description for plant 6",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 6",
                            Price = 9m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Description for plant 7",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 7",
                            Price = 10.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Description = "Description for plant 8",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 8",
                            Price = 12m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "Description for plant 9",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 9",
                            Price = 13.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "Description for plant 10",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 10",
                            Price = 15m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Description = "Description for plant 11",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 11",
                            Price = 16.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Description = "Description for plant 12",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 12",
                            Price = 18m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "Description for plant 13",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 13",
                            Price = 19.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 1,
                            Description = "Description for plant 14",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 14",
                            Price = 21m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 1,
                            Description = "Description for plant 15",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 15",
                            Price = 22.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            Description = "Description for plant 16",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 16",
                            Price = 24m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            Description = "Description for plant 17",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 17",
                            Price = 25.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            Description = "Description for plant 18",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 18",
                            Price = 27m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            Description = "Description for plant 19",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 19",
                            Price = 28.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 1,
                            Description = "Description for plant 20",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 20",
                            Price = 30m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 1,
                            Description = "Description for plant 21",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 21",
                            Price = 31.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 1,
                            Description = "Description for plant 22",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 22",
                            Price = 33m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 1,
                            Description = "Description for plant 23",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 23",
                            Price = 34.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 1,
                            Description = "Description for plant 24",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 24",
                            Price = 36m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 1,
                            Description = "Description for plant 25",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 25",
                            Price = 37.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 1,
                            Description = "Description for plant 26",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 26",
                            Price = 39m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 1,
                            Description = "Description for plant 27",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 27",
                            Price = 40.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 1,
                            Description = "Description for plant 28",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 28",
                            Price = 42m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 29,
                            CategoryId = 1,
                            Description = "Description for plant 29",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 29",
                            Price = 43.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 30,
                            CategoryId = 1,
                            Description = "Description for plant 30",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 30",
                            Price = 45m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 31,
                            CategoryId = 1,
                            Description = "Description for plant 31",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 31",
                            Price = 46.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 32,
                            CategoryId = 1,
                            Description = "Description for plant 32",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 32",
                            Price = 48m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 33,
                            CategoryId = 1,
                            Description = "Description for plant 33",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 33",
                            Price = 49.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 34,
                            CategoryId = 1,
                            Description = "Description for plant 34",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 34",
                            Price = 51m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 35,
                            CategoryId = 1,
                            Description = "Description for plant 35",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 35",
                            Price = 52.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 36,
                            CategoryId = 1,
                            Description = "Description for plant 36",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 36",
                            Price = 54m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 37,
                            CategoryId = 1,
                            Description = "Description for plant 37",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 37",
                            Price = 55.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 38,
                            CategoryId = 1,
                            Description = "Description for plant 38",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 38",
                            Price = 57m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 39,
                            CategoryId = 1,
                            Description = "Description for plant 39",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 39",
                            Price = 58.5m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 40,
                            CategoryId = 1,
                            Description = "Description for plant 40",
                            ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                            Name = "Plant 40",
                            Price = 60m,
                            StockQuantity = 10
                        });
                });

            modelBuilder.Entity("sklep.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("sklep.Models.Cart", b =>
                {
                    b.HasOne("sklep.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("sklep.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("sklep.Models.CartItem", b =>
                {
                    b.HasOne("sklep.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sklep.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("sklep.Models.Order", b =>
                {
                    b.HasOne("sklep.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("sklep.Models.OrderItem", b =>
                {
                    b.HasOne("sklep.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sklep.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("sklep.Models.Product", b =>
                {
                    b.HasOne("sklep.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("sklep.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("sklep.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("sklep.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("sklep.Models.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}