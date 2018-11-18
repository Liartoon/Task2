using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public static class Part1
    {
        //1
        public static void SortSentencesByWordCount(IText text)
        {
            Console.WriteLine("1.1");
            var sentences = (from sentence in text.Sentences
                             //where sentence.Words[0].WordStr!=""
                             orderby sentence.Count
                             select sentence);

            foreach (ISentence sentence in sentences)
            {
                if (sentence.ToString()[0]==' ')
                {
                    Console.WriteLine(sentence.ToString().TrimStart(' '));
                    continue;
                }
                Console.WriteLine(sentence.ToString());
            }
        }
        //2
        public static void SortQuestionSentencesByLength(IText text, int wordLength)
        {
            List<IWord> reqWords = new List<IWord>();
            Dictionary<IWord, int> dictWords = new Dictionary<IWord, int>(new WordEqualityComparer());
                foreach (ISentence sentence in text.Sentences)
                {
                    if (sentence.SentenceType is Question)
                    {
                        foreach (IWord word in sentence.Words)
                        {
                            if (word.Count==wordLength)
                            {
                                reqWords.Add(word);
                            }
                        }
                    }
                }

            foreach (IWord word in reqWords)
            {
                if (dictWords.ContainsKey(word))
                {
                    dictWords[word]++;
                }
                else
                {
                    dictWords.Add(word,1);
                }
            }

            Console.WriteLine("1.2");
            foreach (KeyValuePair<IWord,int> key in dictWords)
            {
                Console.Write(key.Key+" ");
            }
            Console.WriteLine();
        }
        //3
        public static void DeleteWordsByLengthAndConsonantFirstLetter(IText text, int wordLength)
        {
            IText newText=new Text();
            Sentence newSentence;
            string vowelString = "AEIOUY";
            string consonantString = "BCDFGHJKLMNPQRSTVWXZ";
            foreach (ISentence sentence in text.Sentences)
            {
                newSentence = new Sentence();
                foreach (IWord word in sentence.Words)
                {
                    foreach (char c in consonantString)
                    {
                        if (word.Count != 0)
                            if (((word.WordStr[0] == c) || (word.WordStr[0] == char.ToLower(c))) && (wordLength != word.WordStr.Length))
                            {
                                newSentence.AddWord(word, sentence.Dividers[sentence.Words.IndexOf(word)]);
                                break;
                            }             
                    }
                    foreach (char c in vowelString)
                    {
                        if (word.Count != 0)
                            if (((word.WordStr[0] == c) || (word.WordStr[0] == char.ToLower(c))))
                        {
                            newSentence.AddWord(word, sentence.Dividers[sentence.Words.IndexOf(word)]);
                            break;
                        }
                    }
                }
                newText.AddSentence(newSentence);
            }
            Console.WriteLine("1.3");
            Console.Write(newText.OutputText());
        }
        //4
        public static void ChangeWordBySubstring(IText text,int sentenceNum,int length,string substring)
        {
            Console.WriteLine("1.4");
            if (text.Sentences.Count >= sentenceNum)
            {
                for (int i = 0; i < text.Sentences[sentenceNum - 1].Count; i++)
                {
                    if (text.Sentences[sentenceNum - 1].Words[i].Count == length)
                    {
                        text.Sentences[sentenceNum - 1].Words[i].WordStr = substring;
                    }
                }

                Console.WriteLine("{0} sentence",sentenceNum);
                Console.WriteLine(text.Sentences[sentenceNum - 1].ToString());
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }
}
