using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Grille
    {
        private Case[,] List_cases = new Case[9,9];
        private List<int> list_nb = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Grille()
        {
            InitialiserGrille();
        }
        
        /// <summary>
        /// Méthode permettant d'initialiser une grille vide
        /// </summary>
        private void InitialiserGrille()
        {
           for (int i =0; i<9;i++)
           {
                for (int j=0; j<9;j++)
                {
                    List_cases[i,j] = new Case(0);
                }
           }
        }

        /// <summary>
        /// Méthode permettant de vérifier si une ligne est bonne ou nom
        /// </summary>
        /// <param name="i">ligne à vérifier</param>
        /// <returns>booléan représentant si la ligne est correct</returns>
        public bool checkOneLine(int i)
        {
            var tab = new List<int>();
            foreach(Case c in List_cases)
            {
                tab.Add(c.Value);
            }            
            return tab.Intersect(list_nb).Count() == list_nb.Count();
        }

        /// <summary>
        /// Méthode permettant de vérifier toutes les lignes du code
        /// </summary>
        /// <returns>Boolean représentant si toutes les lignes sont bonnes</returns>
        public bool checkAllLine()
        {
            for (int i=0; i<9;i++)
            {               
                if (!checkOneLine(i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Méthode permettant de changer la valeur d'une case
        /// </summary>
        /// <param name="i">ligne de la case</param>
        /// <param name="j">colonne de la case</param>
        /// <param name="value">Valeur à mettre dans la case</param>
        public void setCaseValue(int i, int j,int value)
        {
            List_cases[i,j].Value = value;
        }

        /// <summary>
        /// Permet de recuperer la valeur d'une case
        /// </summary>
        /// <param name="i">ligne de la case</param>
        /// <param name="j">colonne de la case</param>
        /// <returns></returns>
        public int getCaseValue(int i,int j)
        {
            return List_cases[i,j].Value;
        }


    }
}
