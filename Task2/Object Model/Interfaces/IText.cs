using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface IText : ICount,ICloneable
    {
        List<ISentence> Sentences { get;}

        void AddSentence(Sentence sentence);
        void RemoveSentence(int index);

        string OutputText();
    }
}
