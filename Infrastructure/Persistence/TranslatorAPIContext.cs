using Microsoft.EntityFrameworkCore;
using System;
using Infrastructure.Persistence.Configurations;
using Domain.Entities;

namespace TranslatorAPI.Infrastructure
{
    public class TranslatorAPIContext:DbContext
    {
        private readonly string _connectionString;
        public TranslatorAPIContext()
        {
        }
        public TranslatorAPIContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                sqlOptions =>
                {
                    //sqlOptions.MigrationsAssembly("Translator.Infrastructure.Migrations");
                    sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(3), null);
                });
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileToTranslateConfiguration).Assembly);
            ////dummy data to test the database
            ///

            Language LanguageSpanish = new (new Guid("81484F30-49AC-4C3D-B794-CED9A886201C"), "es-es", new Guid("AA502C8D-2A63-4267-B65A-29DABC6FDFCB"));
            Language LanguageEnglish = new(Guid.NewGuid(), "en-us", null);
            Language LanguageChinesse = new(Guid.NewGuid(), "zh-cn", null);

            FileType Pdf = new (new Guid("269A6E63-F58C-493C-9F0B-3DD81ECE3FD6"), "pdf", new Guid("7198D221-9ED2-4174-AC21-68708E80EC3F"));
            FileType Psd = new (new Guid("991A253C-C55E-4F09-8D1B-6062E288A391"), "psd", new Guid("9C4478E4-784C-47C8-A96E-2661D6B33574"));
            FileType Txt = new (Guid.NewGuid(), "txt",null);
            FileType Doc = new (new Guid("4A9F0F9A-9B67-4FE1-9EB2-7F3B796C42CF"), "doc",null);

            PriceAlterator DiscountSpanish = new(new Guid("AA502C8D-2A63-4267-B65A-29DABC6FDFCB"), true, 20M);
            PriceAlterator OverpricePdf = new(new Guid("7198D221-9ED2-4174-AC21-68708E80EC3F"), false, 20M);
            PriceAlterator OverpricePsd = new(new Guid("9C4478E4-784C-47C8-A96E-2661D6B33574"), false, 35M);

            TranslationBasket translationBasket1 = new (new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),new Guid("53B03AF6-75CA-4EE7-9A2D-5F4D35881B44"),new DateTime(2021, 12, 01));
            
            TranslationBasket translationBasket2 = new (new Guid("FB31C0E6-82C1-4944-B10C-21EAC32848C1"),new Guid("EB8A9CFB-A2BF-446F-8195-405E534F966E"),new DateTime(2021, 12, 31));

            FileToTranslate fileToTranslate1 = new(new Guid("4BB64C01-5A9F-4C06-B370-EB5136F538BA"),
                new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),
                "file 1",
                new Guid("269A6E63-F58C-493C-9F0B-3DD81ECE3FD6"),
                "this is a sentence that is ending#LW-Test#This is another sentence that is included in the file#LW-Test#why would you repeat a whole sentence?",
                "comment 1");
            FileToTranslate fileToTranslate2 = new(new Guid("DD22CBDA-F64F-4AAA-BCDD-4CCA567F9AEE"),
                new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),
                "file 2",
                new Guid("991A253C-C55E-4F09-8D1B-6062E288A391"),
                "this sentence is going to be repeated#LW-Test#this sentence is going to be repeated",
                "2 dummy comment 2");

            FileToTranslate fileToTranslate3 = new(Guid.NewGuid(),
                new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),
                "file 3",
                new Guid("4A9F0F9A-9B67-4FE1-9EB2-7F3B796C42CF"),
                "Let there be night in the softest of days#LW-Test#why would you try to play games at this time?",
                "3 dummy comment 3");

            TranslationBasketLanguage translationBasketLanguage1 = new(new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"), new Guid("81484F30-49AC-4C3D-B794-CED9A886201C"));

            TranslationBasketLanguage translationBasketLanguage2 = new(new Guid("FB31C0E6-82C1-4944-B10C-21EAC32848C1"), new Guid("81484F30-49AC-4C3D-B794-CED9A886201C"));

            modelBuilder.Entity<PriceAlterator>().HasData(DiscountSpanish, OverpricePdf, OverpricePsd);

            modelBuilder.Entity<Language>().HasData(LanguageSpanish,LanguageChinesse,LanguageEnglish);
            
            modelBuilder.Entity<FileType>().HasData(Pdf, Psd, Txt, Doc);

            modelBuilder.Entity<TranslationBasket>().HasData(translationBasket1,translationBasket2);
            
            modelBuilder.Entity<FileToTranslate>().HasData(fileToTranslate1, fileToTranslate2, fileToTranslate3);

            modelBuilder.Entity<TranslationBasketLanguage>().HasData(translationBasketLanguage1, translationBasketLanguage2);
            
        }
        public DbSet<FileToTranslate> FileToTranslate { get; set; } = null!;
        public DbSet<TranslationBasket> TranslationBasket { get; set; } = null!;
        public DbSet<Language> Language { get; set; } = null!;
        public DbSet<FileType> FileType { get; set; } = null!;
        public DbSet<PriceAlterator> PriceAlterator { get; set; } = null!;
    }
}
