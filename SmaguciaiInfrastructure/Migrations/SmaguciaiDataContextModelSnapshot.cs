﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmaguciaiInfrastructure.Data;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    [DbContext(typeof(SmaguciaiDataContext))]
    partial class SmaguciaiDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("SmaguciaiDomain.Entities.Bid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("TEXT");

                    b.Property<double>("BidSum")
                        .HasColumnType("REAL");

                    b.Property<string>("CVC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AmountOfProducts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.DiscountCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Discount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DiscountcodeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RouteIndex")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("WholeAmount")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("WholePrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiscountcodeId")
                        .IsUnique();

                    b.HasIndex("RouteId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.OrderPorduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderPorducts");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AlterText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("RatingAmount")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("RatingAverage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Reported")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RouteDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeInSeconds")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FlatNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Auction", b =>
                {
                    b.HasBaseType("SmaguciaiDomain.Entities.Product");

                    b.Property<int>("AuctionStatus")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("CategoryId1")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasIndex("CategoryId1");

                    b.HasDiscriminator().HasValue("Auction");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Bid", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Auction", "Auction")
                        .WithMany("Bids")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmaguciaiDomain.Entities.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Order", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.DiscountCode", "DiscountCode")
                        .WithOne("Order")
                        .HasForeignKey("SmaguciaiDomain.Entities.Order", "DiscountcodeId");

                    b.HasOne("SmaguciaiDomain.Entities.Route", "Route")
                        .WithMany("Orders")
                        .HasForeignKey("RouteId");

                    b.HasOne("SmaguciaiDomain.Entities.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DiscountCode");

                    b.Navigation("Route");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.OrderPorduct", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Order", "Order")
                        .WithMany("OrderPorducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmaguciaiDomain.Entities.Product", "Product")
                        .WithMany("OrderPorducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Photo", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Product", "Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Product", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Report", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Review", "Review")
                        .WithMany("Report")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmaguciaiDomain.Entities.User", "User")
                        .WithMany("Report")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Review", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Product", "Product")
                        .WithMany("Review")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmaguciaiDomain.Entities.User", "User")
                        .WithMany("Review")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Auction", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Category", null)
                        .WithMany("Auctions")
                        .HasForeignKey("CategoryId1");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Category", b =>
                {
                    b.Navigation("Auctions");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.DiscountCode", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Order", b =>
                {
                    b.Navigation("OrderPorducts");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Product", b =>
                {
                    b.Navigation("OrderPorducts");

                    b.Navigation("Photos");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Review", b =>
                {
                    b.Navigation("Report");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Route", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.User", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Order");

                    b.Navigation("Report");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Auction", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
