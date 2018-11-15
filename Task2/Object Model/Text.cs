using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Text: IText
    {
        public List<ISentence> Sentences { get; private set; }

        public int Count { get { return Sentences.Count; } }

        public void AddSentence(Sentence sentence)
        {
            Sentences.Add(sentence);
        }

        public void RemoveSentence(int index)
        {
            Sentences.RemoveAt(index);
        }

        public Text()
        {
            Sentences = new List<ISentence>();
        }

        public Text(List<ISentence> sentences)
        {
            Sentences = sentences;
        }

        public string OutputText()
        {
            string result="";
            foreach (ISentence sentence in Sentences)
            {
                result = sentence.ToString();
            }
            return result;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
