﻿// <auto-generated />
using System;
using DVar.PList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DVar.PList.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240520191834_RemovePricelistFromCustomColumn")]
    partial class RemovePricelistFromCustomColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DVar.PList.Domain.Entities.CustomColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PricelistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PricelistId");

                    b.ToTable("CustomColumns");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.Pricelist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pricelists");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PricelistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PricelistId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.ProductCustomValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomColumnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomColumnId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCustomValues");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.CustomColumn", b =>
                {
                    b.HasOne("DVar.PList.Domain.Entities.Pricelist", null)
                        .WithMany("CustomColumns")
                        .HasForeignKey("PricelistId");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.Product", b =>
                {
                    b.HasOne("DVar.PList.Domain.Entities.Pricelist", null)
                        .WithMany("Products")
                        .HasForeignKey("PricelistId");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.ProductCustomValue", b =>
                {
                    b.HasOne("DVar.PList.Domain.Entities.CustomColumn", "CustomColumn")
                        .WithMany()
                        .HasForeignKey("CustomColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DVar.PList.Domain.Entities.Product", "Product")
                        .WithMany("ProductCustomValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomColumn");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.Pricelist", b =>
                {
                    b.Navigation("CustomColumns");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DVar.PList.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductCustomValues");
                });
#pragma warning restore 612, 618
        }
    }
}
