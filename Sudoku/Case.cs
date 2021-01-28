using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Case
    {
        public int value { get; set; }
        public Case(int n)
        {
            if (n>0 && n<=9)
            {
                value = n;
            }
            else
            {
                value = 0;
            }

        }
    }
    
}
