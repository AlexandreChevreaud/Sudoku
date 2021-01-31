using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Case : INotifyPropertyChanged
    {
        private int value;

        public event PropertyChangedEventHandler PropertyChanged;

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
