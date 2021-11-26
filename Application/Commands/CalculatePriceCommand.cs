using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorAPI.Domain.Entities;

namespace Application
{
    public class CalculatePriceCommand: Command<decimal>
    {
        private static decimal StandardWordPrice => 0.07M;
        public override decimal Execute(List<FileToTranslate> files)
        {
            decimal price = 0M;
            List<string> basketWordsMemory = new();
            List<string> basketSentenceMemory = new();
            foreach (FileToTranslate file in files)
            {
                List<string> fileWordsMemory = new();
                List<string> sentences = new(file.Content.Split("#LW-Test#", StringSplitOptions.RemoveEmptyEntries));
                List<string> fileSentences = (from x in sentences
                                       group x by x into g
                                       select g.Key).ToList();

                //FileType fileType = FileType.Types.Where(x => x.Code == file.Type.ToLower()).First();
                //PriceAlteratorByFileType p = PriceAlteratorByFileType.PriceAlterators.Where(x => x.FileType == fileType).First();

                foreach (string sentence in fileSentences)
                {
                    List<string> sentenceWords = new(sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    if (basketSentenceMemory.Count > 0 && basketSentenceMemory.Any(x => x == sentence))
                    {
                        price += sentenceWords.Count * 0.01M;
                    }
                    else
                    {
                        foreach (string word in sentenceWords)
                        {
                            if (fileWordsMemory.Count > 0 && fileWordsMemory.Any(x => x == word))
                            {
                                price += 0.02M;
                            }
                            else if (basketWordsMemory.Count > 0 && basketWordsMemory.Any(x => x == word))
                            {
                                price += 0.05M;
                                fileWordsMemory.Add(word);
                            }
                            else
                            {
                                price += StandardWordPrice;
                                fileWordsMemory.Add(word);
                            }
                        }
                    }
                }
                basketSentenceMemory.AddRange(fileSentences.Where(x => !basketSentenceMemory.Any(y => y == x)));
                basketWordsMemory.AddRange(fileWordsMemory.Where(x => !basketWordsMemory.Any(y => y == x)));
            }
            return price;
        }
    }
}
