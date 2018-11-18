using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    public class Parser
    {
        public Text Text { get; set; }

        private string ClearText(string text, string clearString)
        {
            Regex regex;
            string newText= text;
            foreach (char c in clearString)
            {
                regex = new Regex($"[{c}]+");
                newText=regex.Replace(newText, c.ToString());
            }
            return newText;
        }

        private void DivideText(ref string text)
        {
                string[] sentences = Regex.Split(text, @"(?<=[!.?])");
                string[] words;
                List<string> dividers;
                string signStr = ",.!?";
                foreach (string sentence in sentences)
                {
                    dividers = new List<string>();
                    words = sentence.Split(' ');
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!IsWordContainsSign(ref words[i], ref dividers, signStr))
                        {
                            dividers.Add(" ");
                        }
                    }
                    foreach (string word in words)
                    {
                        if (new Word(word).ConsistsLetter())
                        {
                            Text.AddSentence(new Sentence(words, dividers));
                            break;
                        }
                    }

                }
        }

        private bool IsWordContainsSign(ref string word, ref List<string> dividers, string signString)
        {
            foreach (char c in signString)
            {
                if (word.Contains(c))
                {
                    word = word.Remove(word.IndexOf(c), 1);
                    dividers.Add(c.ToString());
                    return true;
                }
            }
            return false;
        }

        public Parser(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string text;
                Text = new Text();
                while (!sr.EndOfStream)
                {
                    text = ClearText(sr.ReadLine(), " ,.!?");
                    DivideText(ref text);
                }
                sr.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
            }
            
        }
    }
}
