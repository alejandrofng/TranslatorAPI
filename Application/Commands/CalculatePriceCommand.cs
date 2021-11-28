using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application
{
    public class CalculatePriceCommand : Command<decimal>
    {
        private TranslationBasket Basket { get; set; }
        private static decimal StandardWordPrice => 0.07M;
        private static decimal PriceForWordRepeatedInAnotherSentenceForSameFile => 0.02M;
        private static decimal PriceForWordRepeatedInAnotherFile => 0.05M;
        private static decimal PriceForSentenceRepeatedInAnotherFile => 0.01M;
        private static string SentenceSeparator => "#LW-Test#";
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
                PriceAlterator languagePriceAlterator = language.PriceAlterator;
                foreach (FileToTranslate file in files)
                {
                    decimal FilePriceCalculation = 0M;
                    List<string> fileWordsMemory = new();
                    List<string> sentences = new(file.Content.Split(SentenceSeparator, StringSplitOptions.RemoveEmptyEntries));
                    //Repeated sentences in a single file will not be taken into account since they are not charged
                    List<string> fileSentences = (from x in sentences
                                                  group x by x into g
                                                  select g.Key.ToLower()).ToList();

                    PriceAlterator FileTypePriceAlterator = file.FileType.PriceAlterator;
                    foreach (string sentence in fileSentences)
                    {
                        List<string> sentenceWords = new(sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        if (IsSentenceInAnotherFileOfTheBasket(basketSentenceMemory, sentence))
                        {
                            FilePriceCalculation += sentenceWords.Count * PriceForSentenceRepeatedInAnotherFile;
                        }
                        else
                        {
                            foreach (string word in sentenceWords)
                            {
                                if (IsWordInAnotherSentenceOfTheFile(fileWordsMemory, word))
                                {
                                    FilePriceCalculation += PriceForWordRepeatedInAnotherSentenceForSameFile;
                                }
                                else
                                {
                                    if (IsWordInAnotherFileOfTheBasket(basketWordsMemory, word))
                                        FilePriceCalculation += PriceForWordRepeatedInAnotherFile;
                                    else FilePriceCalculation += StandardWordPrice;
                                    fileWordsMemory.Add(word);
                                }
                            }
                        }
                    }

                    if (FileTypePriceAlterator != null)
                        FilePriceCalculation = ApplyPriceAlterator(FileTypePriceAlterator, FilePriceCalculation);
                    FilesPriceCalculation += FilePriceCalculation;
                    StoreSentencesInBasketSentenceMemory(basketSentenceMemory, fileSentences);
                    StoreWordInBasketWordMemory(basketWordsMemory, fileWordsMemory);
                }
                if (languagePriceAlterator != null)
                    LanguagePriceCalculation = ApplyPriceAlterator(languagePriceAlterator, FilesPriceCalculation);
                price += LanguagePriceCalculation;
            }
            return price;
        }

        private static void StoreWordInBasketWordMemory(List<string> basketWordsMemory, List<string> fileWordsMemory)
        {
            basketWordsMemory.AddRange(fileWordsMemory.Where(x => !basketWordsMemory.Any(y => y == x)));
        }

        private static void StoreSentencesInBasketSentenceMemory(List<string> basketSentenceMemory, List<string> fileSentences)
        {
            basketSentenceMemory.AddRange(fileSentences.Where(x => !basketSentenceMemory.Any(y => y == x)));
        }

        private static bool IsSentenceInAnotherFileOfTheBasket(List<string> basketSentenceMemory, string sentence)
        {
            return basketSentenceMemory.Count > 0 && basketSentenceMemory.Any(x => x == sentence);
        }

        private static bool IsWordInAnotherSentenceOfTheFile(List<string> fileWordsMemory, string word)
        {
            return fileWordsMemory.Count > 0 && fileWordsMemory.Any(x => x == word);
        }

        private static bool IsWordInAnotherFileOfTheBasket(List<string> basketWordsMemory, string word)
        {
            return basketWordsMemory.Count > 0 && basketWordsMemory.Any(x => x == word);
        }
    }
}
