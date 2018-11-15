using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Part2
    {
        public static void OutputDataInFile(string fileName)
        {

        }

        private void FillTheDictionary(Dictionary<string, WordData> dictionary,IText text)
        {
            int page = 1;
            foreach (ISentence sentence in text.Sentences)
            {
                foreach (IWord word in sentence.Words)
                {
                    if (dictionary.ContainsKey(word.WordStr))
                    {
                        dictionary[word.WordStr].SetNumberOfInputs(1);
                        if (dictionary[word.WordStr].PagesNumbers.Find(x => x==page)==-1)
                        {
                            dictionary[word.WordStr].PagesNumbers.Add(page);
                        }
                    }
                    else
                    {
                        dictionary.Add(word.WordStr, new WordData(1, new List<int>()));
                        dictionary[word.WordStr].PagesNumbers.Add(page);
                    }
                }
                page++;
            }
            dictionary.OrderBy((x=> x.Key), new StringComparer());
        }

        public Part2(IText text)
        {
            Dictionary<string, WordData> dictionary = new Dictionary<string, WordData>();
            FillTheDictionary(dictionary,text);
        }
    }
}
