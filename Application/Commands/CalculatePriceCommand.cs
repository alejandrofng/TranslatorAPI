using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application
{
    public class CalculatePriceCommand: Command<decimal>
    { 
        private TranslationBasket Basket { get; set; }
        private static decimal StandardWordPrice => 0.07M;
        public CalculatePriceCommand(TranslationBasket Basket)
        {
            this.Basket = Basket;
        }
        private decimal ApplyPriceAlterator(PriceAlterator PriceAlterator, decimal Price)
        {
            if (PriceAlterator.IsDiscount)
            {
                return Price -= (Price * PriceAlterator.Percentage / 100);
            }
            return Price += (Price * PriceAlterator.Percentage / 100);
        }
        public override decimal Execute()
        {
            var files = Basket.Files;
            var languages = Basket.Languages.Select(x => x.Language).ToList();
            decimal price = 0M;            
            foreach (Language language in languages)
            {
                List<string> basketWordsMemory = new();
                List<string> basketSentenceMemory = new();
                decimal LanguagePriceCalculation = 0M;
                decimal FilesPriceCalculation = 0M;                
                PriceAlterator languagePriceAlterator= language.PriceAlterator;
                foreach (FileToTranslate file in files)
                {
                    decimal FilePriceCalculation = 0M;
                    List<string> fileWordsMemory = new();
                    List<string> sentences = new(file.Content.Split("#LW-Test#", StringSplitOptions.RemoveEmptyEntries));
                    List<string> fileSentences = (from x in sentences
                                                  group x by x into g
                                                  select g.Key).ToList();

                    PriceAlterator FileTypePriceAlterator = file.FileType.PriceAlterator;
                    foreach (string sentence in fileSentences)
                    {
                        List<string> sentenceWords = new(sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        if (basketSentenceMemory.Count > 0 && basketSentenceMemory.Any(x => x == sentence))
                        {
                            FilePriceCalculation += sentenceWords.Count * 0.01M;
                        }
                        else
                        {
                            foreach (string word in sentenceWords)
                            {
                                if (fileWordsMemory.Count > 0 && fileWordsMemory.Any(x => x == word))
                                {
                                    FilePriceCalculation += 0.02M;
                                }
                                else if (basketWordsMemory.Count > 0 && basketWordsMemory.Any(x => x == word))
                                {
                                    FilePriceCalculation += 0.05M;
                                    fileWordsMemory.Add(word);
                                }
                                else
                                {
                                    FilePriceCalculation += StandardWordPrice;
                                    fileWordsMemory.Add(word);
                                }
                            }
                        }
                    }
                    FilePriceCalculation = ApplyPriceAlterator(FileTypePriceAlterator, FilePriceCalculation);
                    FilesPriceCalculation += FilePriceCalculation;
                    basketSentenceMemory.AddRange(fileSentences.Where(x => !basketSentenceMemory.Any(y => y == x)));
                    basketWordsMemory.AddRange(fileWordsMemory.Where(x => !basketWordsMemory.Any(y => y == x)));
                }
                LanguagePriceCalculation = ApplyPriceAlterator(languagePriceAlterator, FilesPriceCalculation);
                price += LanguagePriceCalculation;
            }            
            return price;
        }
    }
}
