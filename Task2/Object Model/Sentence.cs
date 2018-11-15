using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Sentence : ISentence
    {
        public List<IWord> Words { get; private set; }
        public List<string> Dividers { get; private set; }
        public SentenceType SentenceType { get; private set; }

        public int Count { get { return Words.Count; } }

        public Sentence(string[] words, List<string> dividers): this()
        {
            foreach (string word in words)
            {
                Words.Add(new Word(word));
            }
            
            Dividers = dividers;
            ChooseSentenceType(dividers.Last());
        }

        public void ChooseSentenceType(string endOfSentence)
        {
            switch (endOfSentence)
            {
                case "!": { SentenceType = SentenceType.Exclamation; break; }
                case ".": { SentenceType = SentenceType.Common; break; }
                case "?": { SentenceType = SentenceType.Question; break; }
            }
        }

        public Sentence()
        {
            Words = new List<IWord>();
            Dividers = new List<string>();
        }

        public override string ToString()
        {
            string result="";
            for (int i=0;i<Words.Count;i++)
            {
                if (Dividers[i]==",")
                {
                    result += Words[i].ToString() + Dividers[i]+" ";
                }
                else
                {
                    result += Words[i].ToString() + Dividers[i];
                }
            }
            return result;
        }

        public void AddWord(IWord word,string divider)
        {
            Words.Add(word);
            Dividers.Add(divider);
        }

        public void RemoveWord(int index)
        {
            Words.RemoveAt(index);
            Dividers.RemoveAt(index);
        }

        public void RemoveWord(IWord word)
        {
            Dividers.RemoveAt(Words.IndexOf(word));
            Words.Remove(word);
        }
    }
}
