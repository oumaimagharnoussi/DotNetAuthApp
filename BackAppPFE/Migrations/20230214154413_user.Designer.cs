﻿// <auto-generated />
using System;
using BackAppPFE.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackAppPFE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230214154413_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackAppPFE.Models.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriorityId"));

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("PriorityId");

                    b.ToTable("Prioritys", "HR");
                });

            modelBuilder.Entity("BackAppPFE.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("DateCible")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int?>("ImageuserId")
                        .HasColumnType("int");

                    b.Property<int?>("PriorityID")
                        .HasColumnType("int");

                    b.Property<string>("TicketSubject")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("site")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("ImageuserId");

                    b.HasIndex("PriorityID");

                    b.HasIndex("TypeId");

                    b.ToTable("Tickets", "HR");
                });

            modelBuilder.Entity("BackAppPFE.Models.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("TypeId");

                    b.ToTable("Types", "HR");
                });

            modelBuilder.Entity("BackAppPFE.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qualification")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("BackAppPFE.Models.Ticket", b =>
                {
                    b.HasOne("BackAppPFE.Models.User", "Image")
                        .WithMany()
                        .HasForeignKey("ImageuserId");

                    b.HasOne("BackAppPFE.Models.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityID");

                    b.HasOne("BackAppPFE.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Image");

                    b.Navigation("Priority");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}