﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslatorAPI.Infrastructure;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TranslatorAPIContext))]
    partial class TranslatorAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.FileToTranslate", b =>
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

                    b.Property<Guid>("FileTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("FileToTranslate");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4bb64c01-5a9f-4c06-b370-eb5136f538ba"),
                            Comments = "comment 1",
                            Content = "this is a sentence that is ending#LW-Test#This is another sentence that is included in the file#LW-Test#why would you repeat a whole sentence?",
                            FileTypeId = new Guid("269a6e63-f58c-493c-9f0b-3dd81ece3fd6"),
                            Name = "file 1",
                            ProjectId = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f")
                        },
                        new
                        {
                            Id = new Guid("dd22cbda-f64f-4aaa-bcdd-4cca567f9aee"),
                            Comments = "2 dummy comment 2",
                            Content = "this sentence is going to be repeated#LW-Test#this sentence is going to be repeated",
                            FileTypeId = new Guid("991a253c-c55e-4f09-8d1b-6062e288a391"),
                            Name = "file 2",
                            ProjectId = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f")
                        },
                        new
                        {
                            Id = new Guid("56843dcf-64f6-468e-b1ef-365b2c54820e"),
                            Comments = "3 dummy comment 3",
                            Content = "Let there be night in the softest of days#LW-Test#why would you try to play games at this time?",
                            FileTypeId = new Guid("4a9f0f9a-9b67-4fe1-9eb2-7f3b796c42cf"),
                            Name = "file 3",
                            ProjectId = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f")
                        });
                });

            modelBuilder.Entity("Domain.Entities.FileType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("PriceAlteratorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PriceAlteratorId");

                    b.ToTable("FileType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("269a6e63-f58c-493c-9f0b-3dd81ece3fd6"),
                            Code = "pdf",
                            PriceAlteratorId = new Guid("7198d221-9ed2-4174-ac21-68708e80ec3f")
                        },
                        new
                        {
                            Id = new Guid("991a253c-c55e-4f09-8d1b-6062e288a391"),
                            Code = "psd",
                            PriceAlteratorId = new Guid("9c4478e4-784c-47c8-a96e-2661d6b33574")
                        },
                        new
                        {
                            Id = new Guid("ab2b3a13-b45d-413f-9ca8-24a704e5b5a5"),
                            Code = "txt"
                        },
                        new
                        {
                            Id = new Guid("4a9f0f9a-9b67-4fe1-9eb2-7f3b796c42cf"),
                            Code = "doc"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<Guid?>("PriceAlteratorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PriceAlteratorId");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81484f30-49ac-4c3d-b794-ced9a886201c"),
                            Code = "es-ES",
                            PriceAlteratorId = new Guid("aa502c8d-2a63-4267-b65a-29dabc6fdfcb")
                        },
                        new
                        {
                            Id = new Guid("c2846219-7669-4b16-a586-e231bae168ae"),
                            Code = "zh-cn"
                        },
                        new
                        {
                            Id = new Guid("42dbd1cf-3528-44f9-b407-7a86c17cce63"),
                            Code = "en-us"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PriceAlterator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDiscount")
                        .HasColumnType("bit");

                    b.Property<decimal>("Percentage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("PriceAlterator");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa502c8d-2a63-4267-b65a-29dabc6fdfcb"),
                            IsDiscount = true,
                            Percentage = 20m
                        },
                        new
                        {
                            Id = new Guid("7198d221-9ed2-4174-ac21-68708e80ec3f"),
                            IsDiscount = false,
                            Percentage = 20m
                        },
                        new
                        {
                            Id = new Guid("9c4478e4-784c-47c8-a96e-2661d6b33574"),
                            IsDiscount = false,
                            Percentage = 35m
                        });
                });

            modelBuilder.Entity("Domain.Entities.TranslationBasket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TranslationBasket");

                    b.HasData(
                        new
                        {
                            Id = new Guid("653910ac-3fc1-4d18-b471-ad496ab6425f"),
                            CustomerId = new Guid("53b03af6-75ca-4ee7-9a2d-5f4d35881b44"),
                            DueDate = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("fb31c0e6-82c1-4944-b10c-21eac32848c1"),
                            CustomerId = new Guid("eb8a9cfb-a2bf-446f-8195-405e534f966e"),
                            DueDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.TranslationBasketLanguage", b =>
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

            modelBuilder.Entity("Domain.Entities.FileToTranslate", b =>
                {
                    b.HasOne("Domain.Entities.FileType", "FileType")
                        .WithMany("FileToTranslates")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TranslationBasket", "TranslationBasket")
                        .WithMany("Files")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FileType");

                    b.Navigation("TranslationBasket");
                });

            modelBuilder.Entity("Domain.Entities.FileType", b =>
                {
                    b.HasOne("Domain.Entities.PriceAlterator", "PriceAlterator")
                        .WithMany("FileTypes")
                        .HasForeignKey("PriceAlteratorId");

                    b.Navigation("PriceAlterator");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.HasOne("Domain.Entities.PriceAlterator", "PriceAlterator")
                        .WithMany("Languages")
                        .HasForeignKey("PriceAlteratorId");

                    b.Navigation("PriceAlterator");
                });

            modelBuilder.Entity("Domain.Entities.TranslationBasketLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Language", "Language")
                        .WithMany("TranslationBaskets")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TranslationBasket", "TranslationBasket")
                        .WithMany("Languages")
                        .HasForeignKey("TranslationBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("TranslationBasket");
                });

            modelBuilder.Entity("Domain.Entities.FileType", b =>
                {
                    b.Navigation("FileToTranslates");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Navigation("TranslationBaskets");
                });

            modelBuilder.Entity("Domain.Entities.PriceAlterator", b =>
                {
                    b.Navigation("FileTypes");

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("Domain.Entities.TranslationBasket", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
