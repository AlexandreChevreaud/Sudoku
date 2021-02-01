using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{    public static class GenerateurGrille
    {
        /// <summary>
        /// Permet de générer la grille et de mettre des cases vides
        /// </summary>
        /// <param name="nbCases">Nombre de cases à afficher</param>
        /// <returns>Une grille avec des 0 sur les cases à deviner</returns>
        public static Grille genererGrilleAléatoire(int nbCases)
        {
            //TODO : faire une méthode pour un aléatoire total
            Grille grille = GenerateurGrille.genererGrilleValide();
            for (int i = 1;i <= 81 - nbCases;i++)
            {
                int x;
                int y; 
                do
                {
                    Random rnd = new Random();
                    x = rnd.Next(9);
                    y = rnd.Next(9);
                } while (grille.getCaseValue(x,y)==0);
                grille.setCaseValue(x, y, 0);
                grille.getCase(x, y).IsChecked = true;
                

            }
            return grille;
        }
        /// <summary>
        /// Permet de générer une grille de sudoku valide
        /// </summary>
        /// <returns>return une Grille valide</returns>
        public static Grille genererGrilleValide()
        {
            Grille grille = new Grille();   
                                                    
            int[] tab = { 1, 2, 3, 7, 5, 6, 4, 8, 9, 
                          7, 5, 6, 4, 8, 9, 1, 2, 3, 
                          9, 8, 4, 1, 2, 3, 7, 6, 5,
                          4, 3, 5, 8, 6, 7, 2, 9, 1, 
                          2, 6, 7, 5, 9, 1, 8, 3, 4, 
                          8, 9, 1, 2, 3, 4, 6, 5, 7, 
                          3, 4, 9, 6, 7, 8, 5, 1, 2, 
                          5, 7, 8, 9, 1, 2, 3, 4, 6,
                          6, 1, 2, 3, 4, 5, 9, 7, 8 };

            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    grille.setCaseValue(i, j, tab[i * 9 + j]);
                }
            }

            return grille;
        }



    }
}
