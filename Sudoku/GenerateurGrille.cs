using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sudoku
{    public static class GenerateurGrille
    {
        /// <summary>
        /// Permet de générer la grille et de mettre des cases vides
        /// </summary>
        /// <param name="nbCases">Nombre de cases à afficher</param>
        /// <returns>Une grille avec des 0 sur les cases à deviner</returns>
        public static Grille GenererGrilleAléatoire(int nbCases)
        {
            Grille grille = GenerateurGrille.Generation();
            for (int i = 1;i <= 81 - nbCases;i++)
            {
                int x;
                int y; 
                do
                {
                    Random rnd = new Random();
                    x = rnd.Next(9);
                    y = rnd.Next(9);
                } while (grille.GetCaseValue(x,y)==0);
                grille.SetCaseValue(x, y, 0);
                grille.GetCase(x, y).IsChecked = true;
                

            }
            return grille;
        }

        /// <summary>
        /// Méthode permettant de vider la grille tout en respectant le principe d'unicité
        /// </summary>
        /// <returns>Une grille valide ayant une seule solution</returns>
        public static Grille ViderGrilleUnique(int nbEssais)
        {
            Grille grille = GenerateurGrille.Generation();
            grille.Solution = new Grille(grille);
            for (int i = 1; i < nbEssais; i++)
            {
                Random rnd = new Random();
                Thread.Sleep(10);
                int nb = rnd.Next(1, 81);
                TesterCase(grille, nb);
            }
            return grille;
        }

        /// <summary>
        /// Méthode permettant de tester si une case d'une grille est nécessaire pour valider le principe d'unicité 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private static bool TesterCase(Grille g, int position)
        {
            int compteurReussite = 0;
            int x = position / 9;
            int y = position % 9;
            for (int chiffre = 1; chiffre <= 9; chiffre++)
            {
                if (chiffre != g.GetCaseValue(x, y))
                {
                    Grille aTester = new Grille(g);
                    aTester.SetCaseValue(x, y, chiffre);
                    if (CaseValide(aTester, 0) && aTester.CheckSudoku())
                    {
                        compteurReussite += 1;
                        if (compteurReussite == 1)
                            return false;
                    }
                }
            }
            if (compteurReussite == 0)
            {
                g.SetCaseValue(x, y, 0);
            }

            return true;
        }

        /// <summary>
        /// Méthode permettant de générer une grille valide
        /// On génère 3 carré aléatoire en diagonal.
        /// On génère ensuite les autres grâce a un algorithme backward.
        /// </summary>
        /// <returns> Retourne une grille valide</returns>
        private static Grille Generation()
        {
            Grille grille = new Grille();
            GenerateurGrille.AddMiddleAnd2CornerSquare(grille);
            CaseValide(grille, 0);
            return grille;
        }

        /// <summary>
        /// Méthode permettant de remplir la grille de sudoku
        /// </summary>
        /// <param name="grille">Grille</param>
        /// <param name="coordonnee">Coordonnée de la case</param>
        /// <returns>Grille rempli</returns>
        private static bool CaseValide(Grille grille, int coordonnee)
        {
            if (coordonnee == 9 * 9)
                return true;

            int i = coordonnee / 9;
            int j = coordonnee % 9;

            if (grille.GetCaseValue(i, j) != 0)
                return CaseValide(grille, coordonnee + 1);

            for (int chiffre = 1; chiffre <= 9; chiffre++)
            {
                if (AbsentSurLigne(chiffre, grille, i) && AbsentSurColonne(chiffre, grille, j) && AbsentSurBloc(chiffre, grille, i, j))
                {
                    grille.SetCaseValue(i, j, chiffre);

                    if (CaseValide(grille, coordonnee + 1))
                        return true;
                }
            }
            grille.SetCaseValue(i, j, 0);

            return false;
        }
        /// <summary>
        /// Méthode permettant de savoir si un chiffre est présent sur la ligne donnée
        /// </summary>
        /// <param name="chiffre">Chiffre a vérifier</param>
        /// <param name="g">Grille sur laquelle se trouve la ligne</param>
        /// <param name="i">Ligne a vérifier</param>
        /// <returns>True si absent, false sinon </returns>
        private static bool AbsentSurLigne(int chiffre, Grille g, int i)
        {
            for (int j = 0; j < 9; j++)
                if (g.GetCaseValue(i, j) == chiffre)
                    return false;
            return true;
        }

        /// <summary>
        /// Méthode permettant de savoir si un chiffre un déjà présent sur une colonne donnée
        /// </summary>
        /// <param name="chiffre">Chiffre a vérifier</param>
        /// <param name="g">Grille sur laquelle se trouve la colonne</param>
        /// <param name="j">Colonne a vérifier</param>
        /// <returns></returns>
        private static bool AbsentSurColonne(int chiffre, Grille g, int j)
        {
            for (int i = 0; i < 9; i++)
                if (g.GetCaseValue(i, j) == chiffre)
                    return false;
            return true;
        }

        /// <summary>
        /// Méthode permettant de check si un chiffre est présent dans un carré
        /// </summary>
        /// <param name="chiffre">Chiffre a vérifier</param>
        /// <param name="g">Grille sur laquelle se trouve le carré</param>
        /// <param name="i">position en x</param>
        /// <param name="j">position en y</param>
        /// <returns></returns>
        private static bool AbsentSurBloc(int chiffre, Grille g, int i, int j)
        {
            int _i = i - (i % 3), _j = j - (j % 3);  
            for (i = _i; i < _i + 3; i++)
                for (j = _j; j < _j + 3; j++)
                    if (g.GetCaseValue(i, j) == chiffre)
                        return false;
            return true;
        }

        /// <summary>
        /// Permet d'ajouter 3 carré de 3*3 aléatoires 
        /// </summary>
        /// <param name="g">Grille</param>
        private static void AddMiddleAnd2CornerSquare(Grille g)
        {
            GenerateurGrille.AddNormalSquarre(g,0);
            GenerateurGrille.AddNormalSquarre(g,4);
            GenerateurGrille.AddNormalSquarre(g,8);
        }
  

        /// <summary>
        /// Permet l'ajout d'un carré aléatoire
        /// <param name="g">Grille g sur laquelle on ajoute le carré</param>
        /// <param name="pos">position du carré</param>
        private static void AddNormalSquarre(Grille g,int pos)
        {
            int ligne = (pos / 3) * 3;
            int colonne = (pos % 3) * 3;
            List<int> l = new List<int>();
            l = GenerateurGrille.GénérerLigneValide();
            for (int i = ligne; i < ligne +3; i++)
            {
                for (int j = colonne; j < colonne +3; j++)
                {
                    g.SetCaseValue(i, j, l.First());
                    l.Remove(l.First());
                }
            }
        }
        
        /// <summary>
        /// Méthode permettant de génerer une ligne valide de sudoku
        /// </summary>
        /// <returns>Une liste de valeur valide pour une grille de sudoku List<int> taille 9</returns>
        private static List<int> GénérerLigneValide()
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
