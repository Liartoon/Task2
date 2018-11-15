using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length>y.Length)
            {
                foreach (char c1 in x)
                {
                    foreach (char c2 in y)
                    {
                        if (c1 != c2)
                            if (c1 > c2)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                    }
                }
                return 0;
            }
            else
            {
                foreach (char c1 in y)
                {
                    foreach (char c2 in x)
                    {
                        if (c1 != c2)
                            if (c1 > c2)
                            {
                                return -1;
                            }
                            else
                            {
                                return 1;
                            }
                    }
                }
                return 0;
            }
        }
    }
}
