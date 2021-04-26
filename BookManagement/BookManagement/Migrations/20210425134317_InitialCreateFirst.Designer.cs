﻿// <auto-generated />
using System;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookManagement.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20210425134317_InitialCreateFirst")]
    partial class InitialCreateFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookManagement.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookManagement.Models.BookRequest", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ApprovalUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRequest")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RejectUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestUserId")
                        .HasColumnType("int");

                    b.Property<Guid?>("RequestUserUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ReturnRequest")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("RequestId");

                    b.HasIndex("RequestUserUserId");

                    b.ToTable("BookRequests");
                });

            modelBuilder.Entity("BookManagement.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("dccf6c8c-5673-4940-bfee-cf9a1f8ac2d8"),
                            CategoryName = "Novel"
                        },
                        new
                        {
                            CategoryId = new Guid("1b1cbe6f-61bb-422e-b825-06b1f48da627"),
                            CategoryName = "Sciene"
                        });
                });

            modelBuilder.Entity("BookManagement.Models.RequestDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestDetails");
                });

            modelBuilder.Entity("BookManagement.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("52774f82-fc9f-40c6-bf27-d749999342eb"),
                            DoB = new DateTime(2001, 4, 25, 20, 43, 16, 279, DateTimeKind.Local).AddTicks(5072),
                            Name = "Nguyen Van A",
                            Password = "123",
                            Role = 0,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = new Guid("a7616e28-4bfb-4237-8fd3-9cc6ca7ae7bf"),
                            DoB = new DateTime(1991, 4, 25, 20, 43, 16, 281, DateTimeKind.Local).AddTicks(3093),
                            Name = "Nguyen Van B",
                            Password = "123",
                            Role = 1,
                            Username = "user"
                        });
                });

            modelBuilder.Entity("BookManagement.Models.Book", b =>
                {
                    b.HasOne("BookManagement.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookManagement.Models.BookRequest", b =>
                {
                    b.HasOne("BookManagement.Models.User", "RequestUser")
                        .WithMany("BookRequests")
                        .HasForeignKey("RequestUserUserId");

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("BookManagement.Models.RequestDetail", b =>
                {
                    b.HasOne("BookManagement.Models.Book", "Book")
                        .WithMany("RequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookManagement.Models.BookRequest", "Request")
                        .WithMany("RequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("BookManagement.Models.Book", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("BookManagement.Models.BookRequest", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("BookManagement.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookManagement.Models.User", b =>
                {
                    b.Navigation("BookRequests");
                });
#pragma warning restore 612, 618
        }
    }
}