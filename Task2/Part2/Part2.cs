using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    public class Part2
    {
        public static void OutputDataInFile(string fileName, Dictionary<string, WordData> dictionary)
        {
            char prevFirstLetter='@',currentFirstLetter;
            StreamWriter sr = new StreamWriter(fileName);
            foreach (KeyValuePair<string, WordData> pair in dictionary)
            {
                if (pair.Key[0]!=char.ToLower(prevFirstLetter))
                {
                    prevFirstLetter = pair.Key[0];
                    sr.WriteLine(prevFirstLetter);
                }
                    sr.Write("{0}............{1} : ", pair.Key, pair.Value.NumberOfInputs);
                    foreach (int number in pair.Value.PagesNumbers)
                    {
                        sr.Write("{0} ", number);
                    }
                    sr.WriteLine();
            }
            sr.Close();
        }

        private Dictionary<string, WordData> FillTheDictionary(Dictionary<string, WordData> dictionary,IText text)
        {
            int page = 1;
            int numberOfInputs;
            var sort = from pair in dictionary
                       orderby pair.Key
                       select pair;
            Dictionary<string, WordData> sortedDictionary = new Dictionary<string, WordData>();
            foreach (ISentence sentence in text.Sentences)
            {
                foreach (IWord word in sentence.Words)
                {
                    if (word.ToLower()!="")
                    if (dictionary.ContainsKey(word.ToLower()))
                    {
                            dictionary[word.ToLower()].NumberOfInputs++;
                        if (dictionary[word.ToLower()].PagesNumbers.Find(x => x==page)==0)
                        {
                            dictionary[word.ToLower()].PagesNumbers.Add(page);
                        }
                    }
                    else
                    {
                        dictionary.Add(word.ToLower(), new WordData(1, new List<int>()));
                        dictionary[word.ToLower()].PagesNumbers.Add(page);
                    }
                }
                page++;
            }

            
            foreach (KeyValuePair<string,WordData> pair in sort)
            {
                sortedDictionary.Add(pair.Key,pair.Value);
            }
            return sortedDictionary;
        }

        public Part2(IText text)
        {
            Dictionary<string, WordData> dictionary = new Dictionary<string, WordData>();
            OutputDataInFile("output.txt", FillTheDictionary(dictionary, text));
        }
    }
}
