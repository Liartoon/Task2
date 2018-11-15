using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface ISentence: ICount,ISentenceType
    {
        List<IWord> Words { get; }
        List<string> Dividers { get; }

        void AddWord(IWord word,string divider);
        void RemoveWord(int index);
        void RemoveWord(IWord word);
    }
}
