using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public struct WordData
    {
        public int NumberOfInputs { get; private set; }
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
