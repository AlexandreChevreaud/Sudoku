using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Grille
    {
        private Case[,] List_cases = new Case[9, 9];

        public Grille()
        {
            InitialiserGrille();
        }

        /// <summary>
        /// Méthode permettant d'initialiser une grille vide
        /// </summary>
        private void InitialiserGrille()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    List_cases[i, j] = new Case(0);
                }
            }
        }

        /// <summary>
        /// Méthode permettant de vérifier si une ligne est bonne ou non
        /// </summary>
        /// <param name="i">ligne à vérifier</param>
        /// <returns>booléan représentant si la ligne est correct</returns>
        public bool checkOneLine(int i)
        {
            var tab = new List<int>();
            for (int j = 0; j < 9; j++)
            {
                if (tab.Contains(List_cases[i, j].Value))
                {
                    return false;
                }
                tab.Add(List_cases[i, j].Value);
            }
            return true;
        }

        /// <summary>
        /// Méthode permettant de vérifier si une colonne est bonne ou non
        /// </summary>
        /// <param name="i">colonne à vérifier</param>
        /// <returns>booléan représentant si la colonne est correct</returns>
        public bool checkOneColumn(int j)
        {
            var tab = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (tab.Contains(List_cases[i, j].Value))
                {
                    return false;
                }
                tab.Add(List_cases[i, j].Value);
            }
            return true;
        }

        /// <summary>
        /// Méthode permettant de vérifier si une carré de 3*3 est bon ou non
        /// </summary>
        /// <param name="nb">carré à vérifier</param>
        /// <returns>booléan représentant si le carré est correct</returns>
        public bool checkOneSquare(int nb)
        {
            int ligne = (nb / 3) * 3;
            int colonne = (nb % 3) * 3;
            var tab = new List<int>();
            for (int i = ligne; i < ligne + 3; i++)
            {
                for (int j = colonne; j < colonne + 3; j++)
                {
                    if (tab.Contains(List_cases[i, j].Value) || List_cases[i, j].Value == 0)
                    {
                        return false;
                    }
                    tab.Add(List_cases[i, j].Value);

                }
            }
            return true;
        }

        /// <summary>
        /// Méthode permettant de vérifier toutes les lignes du code
        /// </summary>
        /// <returns>Boolean représentant si toutes les lignes sont bonnes</returns>
        public bool checkAllLine()
        {
            for (int i = 0; i < 9; i++)
            {
                if (!checkOneLine(i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Méthode permettant de vérifier toutes les colonnes du code
        /// </summary>
        /// <returns>Boolean représentant si toutes les colonnes sont bonnes</returns>
        public bool checkAllColumn()
        {
            for (int j = 0; j < 9; j++)
            {
                if (!checkOneColumn(j))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Méthode permettant de vérifier tout les carrés du code
        /// </summary>
        /// <returns>Boolean représentant si toutes les carrés sont bons</returns>
        public bool checkAllSquare()
        {
            for (int j = 0; j < 9; j++)
            {
                if (!checkOneSquare(j))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Méthode qui permet de vérifier si le sudoku est valide ou non
        /// </summary>
        /// <returns></returns>
        public bool checkSudoku()
        {
            if (checkAllSquare() && checkAllColumn() && checkAllLine())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Méthode permettant de changer la valeur d'une case
        /// </summary>
        /// <param name="i">ligne de la case</param>
        /// <param name="j">colonne de la case</param>
        /// <param name="value">Valeur à mettre dans la case</param>
        public void setCaseValue(int i, int j, int value)
        {
            List_cases[i, j].Value = value;
        }

        /// <summary>
        /// Permet de recuperer la valeur d'une case
        /// </summary>
        /// <param name="i">ligne de la case</param>
        /// <param name="j">colonne de la case</param>
        /// <returns></returns>
        public int getCaseValue(int i, int j)
        {
            return List_cases[i, j].Value;
        }
        /// <summary>
        /// To string
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string s = "";
            var count = 0;
            foreach (var c in this.List_cases)
            {
                s += c.Value + " ";
                count++;
                if (count%9==0)
                {
                    s += "\n";
                }
            }
            return s;
        }

        /// <summary>
        /// get all value 
        /// </summary>
        /// <returns></returns>
        public List<int> getAllValues()
        {
            List<int> l = new List<int>();
            foreach (var c in this.List_cases)
            {
                l.Add(c.Value);
            }
            return l;
        }

        public Case getCase(int x, int y)
        {
            return this.List_cases[x,y];
        }
    }
}
