using Microsoft.EntityFrameworkCore;
using System;
using TranslatorAPI.Infrastructure.Configurations;
using TranslatorAPI.Domain.Models;

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
            Language LanguageSpanish = new (new Guid("81484F30-49AC-4C3D-B794-CED9A886201C"), "es-ES");
            
            TranslationBasket translationBasket1 = new (new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),new Guid("53B03AF6-75CA-4EE7-9A2D-5F4D35881B44"),new DateTime(2021, 12, 01));
            
            TranslationBasket translationBasket2 = new (new Guid("FB31C0E6-82C1-4944-B10C-21EAC32848C1"),new Guid("EB8A9CFB-A2BF-446F-8195-405E534F966E"),new DateTime(2021, 12, 31));

            FileToTranslate fileToTranslate1 = new(new Guid("4BB64C01-5A9F-4C06-B370-EB5136F538BA"),
                new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),
                "file 1",
                "txt",
                "this is a sentence that is ending#LW-Test#This is another sentence that is included in the file#LW-Test#why would you repeat a whole sentence?",
                "comment 1");
            FileToTranslate fileToTranslate2 = new(new Guid("DD22CBDA-F64F-4AAA-BCDD-4CCA567F9AEE"),
                new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"),
                "file 2",
                "pdf",
                "this sentence is going to be repeated#LW-Test#this sentence is going to be repeated",
                "2 dummy comment 2");

            TranslationBasketLanguage translationBasketLanguage1 = new(new Guid("653910AC-3FC1-4D18-B471-AD496AB6425F"), new Guid("81484F30-49AC-4C3D-B794-CED9A886201C"));

            TranslationBasketLanguage translationBasketLanguage2 = new(new Guid("FB31C0E6-82C1-4944-B10C-21EAC32848C1"), new Guid("81484F30-49AC-4C3D-B794-CED9A886201C"));
            modelBuilder.Entity<Language>().HasData(LanguageSpanish);

            modelBuilder.Entity<TranslationBasket>().HasData(translationBasket1,translationBasket2);
            
            modelBuilder.Entity<FileToTranslate>().HasData(fileToTranslate1, fileToTranslate2);

            modelBuilder.Entity<TranslationBasketLanguage>().HasData(translationBasketLanguage1, translationBasketLanguage2);
            
        }
        public DbSet<FileToTranslate> FileToTranslate { get; set; } = null!;
        public DbSet<TranslationBasket> TranslationBasket { get; set; } = null!;
        public DbSet<Language> Language { get; set; } = null!;
    }
}
