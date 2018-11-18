using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser("text.txt");
            Part1.SortSentencesByWordCount(parser.Text);
            Part1.SortQuestionSentencesByLength(parser.Text,3);
            Part1.DeleteWordsByLengthAndConsonantFirstLetter(parser.Text, 3);
            Part1.ChangeWordBySubstring(parser.Text,1,3,"goodees");
            Part2 part2=new Part2(parser.Text,1);
            Console.ReadKey();
        }
    }
}
