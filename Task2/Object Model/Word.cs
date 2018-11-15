using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Word : IWord
    {
        public string WordStr { get; set; }
        public int Count { get { return WordStr.Length; } }

        public override string ToString()
        {
            return WordStr;
        }

        public Word(string word)
        {
            WordStr = word;
        }

        public bool ConsistsLetter()
        {
            foreach (char c in WordStr)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public Word()
        {
            
        }
    }
}
