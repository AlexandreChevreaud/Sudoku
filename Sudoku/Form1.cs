using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sudoku
{
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
                t.LostFocus += new EventHandler(changement);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public void changement(object sender, EventArgs e)
        {
            if((Control)sender != this) { 
                TableLayoutPanelCellPosition pos = this.Grid.GetCellPosition((TextBox)sender);
                grille.setCaseValue(pos.Row, pos.Column, Int16.Parse(((TextBox)sender).Text));
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
                        grille = GenerateurGrille.genererGrilleAvecTrou(10);
                    }
                }
            }
        }
    }
}
