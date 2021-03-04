using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Case 
    {
        private int value;
        private bool isChecked = false;

        public bool IsChecked { get => isChecked; set => this.isChecked = value; }
        public int Value { get => value; set => this.value = value; }

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
