using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class WordEqualityComparer : IEqualityComparer<IWord>
    {
        public bool Equals(IWord x, IWord y)
        {
            return x.WordStr == y.WordStr;
        }

        public int GetHashCode(IWord obj)
        {
            return obj.Count;
        }
    }
}
