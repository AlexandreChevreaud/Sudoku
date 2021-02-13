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

        public static Grille generationV3()
        {
            Grille grille = new Grille();
            GenerateurGrille.addMiddleAnd2CornerSquare(grille);
            caseValide(grille, 0);
            return grille;
        }

        private static bool caseValide(Grille grille, int coordonnee)
        {
            if (coordonnee == 9 * 9)
                return true;

            int i = coordonnee / 9;
            int j = coordonnee % 9;

            if (grille.getCaseValue(i, j) != 0)
                return caseValide(grille, coordonnee + 1);

            for (int chiffre = 1; chiffre <= 9; chiffre++)
            {
                if (absentSurLigne(chiffre, grille, i) && absentSurColonne(chiffre, grille, j) && absentSurBloc(chiffre, grille, i, j))
                {
                    grille.setCaseValue(i, j, chiffre);

                    if (caseValide(grille, coordonnee + 1))
                        return true;
                }
            }
            grille.setCaseValue(i, j, 0);

            return false;
        }

        private static bool absentSurLigne(int chiffre, Grille g, int i)
        {
            for (int j = 0; j < 9; j++)
                if (g.getCaseValue(i, j) == chiffre)
                    return false;
            return true;
        }

        private static bool absentSurColonne(int chiffre, Grille g, int j)
        {
            for (int i = 0; i < 9; i++)
                if (g.getCaseValue(i, j) == chiffre)
                    return false;
            return true;
        }

        private static bool absentSurBloc(int chiffre, Grille g, int i, int j)
        {
            int _i = i - (i % 3), _j = j - (j % 3);  // ou encore : _i = 3*(i/3), _j = 3*(j/3);
            for (i = _i; i < _i + 3; i++)
                for (j = _j; j < _j + 3; j++)
                    if (g.getCaseValue(i, j) == chiffre)
                        return false;
            return true;
        }

        private static void addMiddleAnd2CornerSquare(Grille g)
        {
            GenerateurGrille.addNormalSquarre(g,0);
            GenerateurGrille.addNormalSquarre(g,4);
            GenerateurGrille.addNormalSquarre(g,8);
        }
  

        /// <summary>
        /// Permet l'ajout d'un carré aléatoire
        /// <param name="g">Grille g sur laquelle on ajoute le carré</param>
        /// <param name="pos">position du carré</param>
        private static void addNormalSquarre(Grille g,int pos)
        {
            int ligne = (pos / 3) * 3;
            int colonne = (pos % 3) * 3;
            List<int> l = new List<int>();
            l = GenerateurGrille.générerLigneValide();
            for (int i = ligne; i < ligne +3; i++)
            {
                for (int j = colonne; j < colonne +3; j++)
                {
                    g.setCaseValue(i, j, l.First());
                    l.Remove(l.First());
                }
            }
        }
        
        /// <summary>
        /// Méthode permettant de génerer une ligne valide de sudoku
        /// </summary>
        /// <returns>Une liste de valeur valide pour une grille de sudoku List<int> taille 9</returns>
        private static List<int> générerLigneValide()
        {
            Random rnd = new Random();
            List<int> ligne = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                int nb = rnd.Next(1, 10);
                while (ligne.Contains(nb))
                    nb = rnd.Next(1, 10);
                ligne.Add(nb);
            }
            
            return ligne;
        }
    }
}
