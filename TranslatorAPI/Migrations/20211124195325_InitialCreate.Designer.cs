﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslatorAPI;

namespace TranslatorAPI.Migrations
{
    [DbContext(typeof(TranslatorAPIContext))]
    [Migration("20211124195325_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TranslatorAPI.Models.FileToTranslate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FileToTranslate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4bb64c01-5a9f-4c06-b370-eb5136f538ba"),
                            Comments = "comment 1",
                            Content = "this is a sentence that is ending#LW-Test#This is another sentence that is included in the file#LW-Test#why would you repeat a whole sentence?",
                            Name = "file 1",
                            ProjectId = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"),
                            Type = "txt"
                        },
                        new
                        {
                            Id = new Guid("dd22cbda-f64f-4aaa-bcdd-4cca567f9aee"),
                            Comments = "2 dummy comment 2",
                            Content = "this sentence is going to be repeated#LW-Test#this sentence is going to be repeated",
                            Name = "file 2",
                            ProjectId = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"),
                            Type = "pdf"
                        });
                });

            modelBuilder.Entity("TranslatorAPI.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"),
                            Code = "es-ES"
                        });
                });

            modelBuilder.Entity("TranslatorAPI.Models.TranslationBasket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TranslationBasket");

                    b.HasData(
                        new
                        {
                            Id = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"),
                            CustomerId = new Guid("53b03af6-75ca-4ee7-9a2d-5f4d35881b44"),
                            DueDate = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("fb31c0e6-82c1-4944-b10c-21eac32848c1"),
                            CustomerId = new Guid("eb8a9cfb-a2bf-446f-8195-405e534f966e"),
                            DueDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 0m
                        });
                });

            modelBuilder.Entity("TranslatorAPI.Models.TranslationBasketLanguage", b =>
                {
                    b.Property<Guid>("TranslationBasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TranslationBasketId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("TranslationBasketLanguage");

                    b.HasData(
                        new
                        {
                            TranslationBasketId = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"),
                            LanguageId = new Guid("81484f30-49ac-4c3d-b794-ced9a886201c")
                        },
                        new
                        {
                            TranslationBasketId = new Guid("fb31c0e6-82c1-4944-b10c-21eac32848c1"),
                            LanguageId = new Guid("81484f30-49ac-4c3d-b794-ced9a886201c")
                        });
                });

            modelBuilder.Entity("TranslatorAPI.Models.FileToTranslate", b =>
                {
                    b.HasOne("TranslatorAPI.Models.TranslationBasket", "TranslationBasket")
                        .WithMany("Files")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TranslationBasket");
                });

            modelBuilder.Entity("TranslatorAPI.Models.TranslationBasketLanguage", b =>
                {
                    b.HasOne("TranslatorAPI.Models.Language", "Language")
                        .WithMany("TranslationBaskets")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TranslatorAPI.Models.TranslationBasket", "TranslationBasket")
                        .WithMany("Languages")
                        .HasForeignKey("TranslationBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("TranslationBasket");
                });

            modelBuilder.Entity("TranslatorAPI.Models.Language", b =>
                {
                    b.Navigation("TranslationBaskets");
                });

            modelBuilder.Entity("TranslatorAPI.Models.TranslationBasket", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
