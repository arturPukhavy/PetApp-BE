﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetApp.WebAPI;

#nullable disable

namespace PetApp.WebAPI.Migrations
{
    [DbContext(typeof(PetAppDbContext))]
    [Migration("20241103142947_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetApp.WebAPI.Models.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdStateId")
                        .HasColumnType("integer");

                    b.Property<int>("AnimalAge")
                        .HasColumnType("integer");

                    b.Property<string>("AnimalBreed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("AnimalPhoto")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int?>("AssignedSitterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VisitTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdStateId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("AssignedSitterId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.AdState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdStates");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.AnimalSitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("SitterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("SitterId");

                    b.ToTable("AnimalSitters");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.Sitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Location")
                        .HasColumnType("integer");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Sitters");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.UnavailableTimeframe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("UnavailableTimeframes");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.UnavailableTimeframeSitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SitterId")
                        .HasColumnType("integer");

                    b.Property<int>("UnavailableTimeframeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SitterId");

                    b.HasIndex("UnavailableTimeframeId");

                    b.ToTable("UnavailableTimeframeSitters");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("SitterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("SitterId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.Ad", b =>
                {
                    b.HasOne("PetApp.WebAPI.Models.AdState", "AdState")
                        .WithMany()
                        .HasForeignKey("AdStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetApp.WebAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetApp.WebAPI.Models.Sitter", "AssignedSitter")
                        .WithMany()
                        .HasForeignKey("AssignedSitterId");

                    b.HasOne("PetApp.WebAPI.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdState");

                    b.Navigation("Animal");

                    b.Navigation("AssignedSitter");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.AnimalSitter", b =>
                {
                    b.HasOne("PetApp.WebAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetApp.WebAPI.Models.Sitter", "Sitter")
                        .WithMany()
                        .HasForeignKey("SitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.UnavailableTimeframeSitter", b =>
                {
                    b.HasOne("PetApp.WebAPI.Models.Sitter", "Sitter")
                        .WithMany()
                        .HasForeignKey("SitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetApp.WebAPI.Models.UnavailableTimeframe", "UnavailableTimeframe")
                        .WithMany()
                        .HasForeignKey("UnavailableTimeframeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sitter");

                    b.Navigation("UnavailableTimeframe");
                });

            modelBuilder.Entity("PetApp.WebAPI.Models.User", b =>
                {
                    b.HasOne("PetApp.WebAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetApp.WebAPI.Models.Sitter", "Sitter")
                        .WithMany()
                        .HasForeignKey("SitterId");

                    b.Navigation("Role");

                    b.Navigation("Sitter");
                });
#pragma warning restore 612, 618
        }
    }
}
