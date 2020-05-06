﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P0;

namespace P0.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20200505183248_InitialCrea")]
    partial class InitialCrea
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("P0.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LasttName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Passowerd")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StoreID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerID");

                    b.HasIndex("StoreID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("P0.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StoreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StoreID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("P0.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderProductID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("P0.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductDis")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("P0.Store", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoreLocation")
                        .HasColumnType("TEXT");

                    b.HasKey("StoreID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("P0.StoreProduct", b =>
                {
                    b.Property<int>("StoreProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StoreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("StoreProductID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StoreID");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("P0.Customer", b =>
                {
                    b.HasOne("P0.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID");
                });

            modelBuilder.Entity("P0.Order", b =>
                {
                    b.HasOne("P0.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("P0.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID");
                });

            modelBuilder.Entity("P0.OrderProduct", b =>
                {
                    b.HasOne("P0.Order", "OrderId")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.HasOne("P0.Product", "ProductId")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("P0.StoreProduct", b =>
                {
                    b.HasOne("P0.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("P0.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID");
                });
#pragma warning restore 612, 618
        }
    }
}
