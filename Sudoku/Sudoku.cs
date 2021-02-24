﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    //TODO : changer le graphisme
    public partial class Sudoku : Form
    {
        //private List>> tabRect;
        private List<Label> tabTB;
        Grille grille = new Grille();
        public Sudoku()
        {
            InitializeComponent();
            Console.Write("Intialisation");
            grille = GenerateurGrille.genererGrilleAléatoire(10);
            tabTB = new List<Label>();
            
            //tabRect = new List<Rectangle>();
            for (int i = 0; i < 81; i++)
            {
                Label l = new Label();
                l.Height = 50;
                l.Width = 100;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Font = new Font("Arial", 20);

                l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //l.Text = "" + grille.getCaseValue(i / 9, i % 9);
                
                l.Click += new EventHandler(changeValueLabel);
                tabTB.Add(l);
                //tabRect.Add(r);
                this.Grid.Controls.Add(l, i % 9, i / 9);
                //this.Grid.Controls.Add(r, i % 9, i / 9);
            }
            initialisationTextBox(grille);
            
            this.Invalidate();

            
            
        }
        /// <summary>
        /// TODO : changer pour la longueur de la boucle 
        /// </summary>
        /// <param name="cases"></param>
        private void initialisationTextBox(Grille g)
        {
            var liste = g.getAllValues();
            for (int i = 0; i < liste.Count; i++)
            {
                tabTB[i].Text = liste[i].ToString();
                if (tabTB[i].Text != "0")
                {
                    tabTB[i].BackColor = Color.Transparent;
                    tabTB[i].Click -= new EventHandler(changeValueLabel);
                }
                else
                {
                    tabTB[i].Text = "";
                    tabTB[i].BackColor = Color.White;

                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        /// <summary>
        /// change un textbox en label (possibilité de faire marche arrière)
        /// TEST
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb1.ReadOnly = true;
                tb1.BorderStyle = BorderStyle.None;
                tb1.Enabled = false;

            }
            else
            {
                tb1.ReadOnly = false;
                tb1.BorderStyle = BorderStyle.FixedSingle;
                tb1.Enabled = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            var x = MessageBox.Show("Are you sure you want to really exit ? ",
                                     "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (x == DialogResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                e.Cancel = false;
                MainMenu m = new MainMenu();
                m.Show();
            }
        }

        private void Vérifier_Click(object sender, EventArgs e)
        {
            if ((Control)sender != this)
            {
                //TextBox tb = sender;
                //tb.LostFocus -= new EventHandler(Changement);
                //TableLayoutPanelCellPosition pos = this.Grid.GetCellPosition(tb);
                //TODO : gérer l'observabilité
                //tony parker grille.setCaseValue(pos.Row, pos.Column, Int16.Parse(tb.Text));
                if (grille.checkSudoku())
                {
                    string message = "Voulez-vous relancer une partie ?";
                    string caption = "Vous avez terminé !";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        grille = GenerateurGrille.genererGrilleAléatoire(10);
                        this.initialisationTextBox(grille);
                    }
                }
                else
                {
                    var mess = "Le sudoku n'est pas juste ! Corrigez-le";
                    var capt = "Dommage !";
                    var mb = MessageBoxButtons.OK;
                    var result = MessageBox.Show(mess, capt, mb);
                }
            }
        }

        private void Sudoku_Paint(object sender, PaintEventArgs e)
        {
            
        }

        

        private void changeValueLabel(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                var tabValue = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Label l = (Label)sender;
                var position = this.getPositionOfLabel(l);
                l.BackColor = Color.CadetBlue;
                var lastValueLabel = l.Text;
                Console.WriteLine("Entrez un chiffre");
                NumberSudoku ns = new NumberSudoku(l);
                ns.ShowDialog();

                Console.WriteLine("le label à été changé");
                if (lastValueLabel != l.Text)
                {
                    grille.setCaseValue(position.Item2, position.Item1, Int32.Parse(l.Text));

                }

                //il faut changer la valeur dans le back
                //TODO
                try
                {
                    int number;
                    bool success = Int32.TryParse(l.Text, out number);
                    if (success)
                    {
                        var value = Int32.Parse(l.Text);

                        if (tabValue.Contains(value))
                        {
                            grille.setCaseValue(position.Item2, position.Item1, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }



            }

        }

        private void eve(object sender, EventArgs e)
        {
            Console.WriteLine("lostfocus");
        }
   
        private void Sudoku_KeyPress(object sender, EventArgs e)
        {
            
        }

        private void Sudoku_KeyUp(object sender, KeyEventArgs e)
        {           

        }
        public void Changement(object sender, EventArgs e)
        {
            if ((Control)sender != this)
            {
                TextBox tb = ((TextBox)sender);
                tb.LostFocus -= new EventHandler(Changement);
                TableLayoutPanelCellPosition pos = this.Grid.GetCellPosition(tb);
                //TODO : gérer l'observabilité
                grille.setCaseValue(pos.Row, pos.Column, Int16.Parse(tb.Text));
                if (grille.checkSudoku())
                {
                    string message = "Voulez-vous relancer une partie ?";
                    string caption = "Vous avez terminé !";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        //TODO : Ca marche pas 
                        //tb.LostFocus -= new EventHandler(Changement);
                        grille = GenerateurGrille.genererGrilleAléatoire(10);
                        this.initialisationTextBox(grille);
                        //tb.LostFocus += new EventHandler(Changement);
                    }
                }
            }
        }
    }
}
