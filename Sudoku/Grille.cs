using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Grille
    {
        private Case[][] List_cases = new Case[9][];
        private List<int> list_nb = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Grille()
        {
            InitialiserGrille();
        }
        
        private void InitialiserGrille()
        {
           for (int i =0; i<9;i++)
           {
                for (int j=0; j<9;j++)
                {
                    List_cases[i][j] = new Case(0);
                }
           }
        }

        public bool checkOneLine(int i)
        {
            var containsAll = false;
            var tab = new List<int>();
            foreach(Case c in List_cases[i])
            {
                tab.Add(c.value);
            }
            if (tab == list_nb)
            {
                containsAll = true;
            }
            return containsAll;
        }


    }
}
