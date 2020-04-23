﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiratenApp.Data;

namespace PiratenApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200405193618_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PiratenApp.Models.Pirat", b =>
                {
                    b.Property<int>("PiratId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motiv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PiratId");

                    b.ToTable("Piraten");
                });

            modelBuilder.Entity("PiratenApp.Models.PiratSchiff", b =>
                {
                    b.Property<int>("PSID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PiratId")
                        .HasColumnType("int");

                    b.Property<int>("SchiffId")
                        .HasColumnType("int");

                    b.HasKey("PSID");

                    b.HasIndex("PiratId");

                    b.HasIndex("SchiffId");

                    b.ToTable("PiratSchiffe");
                });

            modelBuilder.Entity("PiratenApp.Models.Schiff", b =>
                {
                    b.Property<int>("SchiffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchiffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchiffId");

                    b.ToTable("Schiffe");
                });

            modelBuilder.Entity("PiratenApp.Models.PiratSchiff", b =>
                {
                    b.HasOne("PiratenApp.Models.Pirat", "Pirat")
                        .WithMany("PiratSchiff")
                        .HasForeignKey("PiratId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiratenApp.Models.Schiff", "Schiff")
                        .WithMany("PiratSchiff")
                        .HasForeignKey("SchiffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
