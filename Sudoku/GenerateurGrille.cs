using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class GenerateurGrille
    {
        public static Grille generer(int n)
        {
            Grille grille = new Grille();

            int[] tab = { 1, 2, 3, 7, 5, 6, 4, 8, 9, 7, 5, 6, 4, 8, 9, 1, 2, 3, 9, 8, 4, 1, 2, 3, 7, 6, 5, 4, 3, 5, 8, 6, 7, 2, 9, 1, 2, 6, 7, 5, 9, 1, 8, 3, 4, 8, 9, 1, 2, 3, 4, 6, 5, 7, 3, 4, 9, 6, 7, 8, 5, 1, 2, 5, 7, 8, 9, 1, 2, 3, 4, 6, 6, 1, 2, 3, 4, 5, 9, 7, 8 };

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    grille.setCase(i, j, tab[i * 9 + j]);
                    Console.Write(tab[i * 9 + j]);
                }
                Console.WriteLine();
            }

            for (int i = 1;i <= 81 - n;i++)
            {
                int x;
                int y; 
                do
                {
                    Random rnd = new Random();
                    x = rnd.Next(9);
                    y = rnd.Next(9);
                } while (grille.getCase(x,y)==0); ;
            }

            return grille;
        }
    }
}
