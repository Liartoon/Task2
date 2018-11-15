using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class WordData
    {
        public int NumberOfInputs { get; set; }
        public List<int> PagesNumbers { get; private set; }

        public WordData(int numberOfInputs,List<int> pagesNumbers)
        {
            NumberOfInputs = numberOfInputs;
            PagesNumbers = pagesNumbers;
        }

        internal void SetNumberOfInputs(int count)
        {
            NumberOfInputs += count;
        }
    }
}
