using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sudoku
{
    //TODO : changer le graphisme
    public partial class Form1 : Form
    {
        private List<TextBox> tabTB;
        Grille grille = new Grille();
        public Form1()
        {
            InitializeComponent();
            grille = GenerateurGrille.genererGrilleValide();
            tabTB = new List<TextBox>();
            for (int i = 0; i < 81; i++)
            {
                TextBox t = new TextBox();

                t.Text = "" + grille.getCaseValue(i / 9, i % 9);
                tabTB.Add(t);
                this.Grid.Controls.Add(t, i % 9, i / 9);
            }
            foreach (TextBox t in tabTB)
            {
                t.LostFocus += new EventHandler(Changement);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //TODO : à supprimer
        }
        public void Changement(object sender, EventArgs e)
        {
            if((Control)sender != this) {
                TextBox tb = ((TextBox)sender);
                TableLayoutPanelCellPosition pos = this.Grid.GetCellPosition(tb);
                //TODO : gérer l'observabilité
                grille.setCaseValue(pos.Row, pos.Column, Int16.Parse(tb.Text));
                if(grille.checkSudoku())
                {
                    string message = "Voulez-vous relancer une partie ?";
                    string caption = "Vous avez terminé !";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;    
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        //TODO : Ca marche pas 
                        tb.LostFocus -= new EventHandler(Changement);
                        grille = GenerateurGrille.genererGrilleAléatoire(10);
                        tb.LostFocus += new EventHandler(Changement);
                    }
                }
            }
        }
    }
}
