using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    //TODO : changer le graphisme
    public partial class Sudoku : Form
    {
        //private List>> tabRect;
        private List<Label> tabLabel;
        Grille grille = new Grille();
        public Sudoku()
        {
            InitializeComponent();
            Console.Write("Intialisation");
            grille = GenerateurGrille.ViderGrilleUnique(50);
            tabLabel = new List<Label>();
            
            for (int i = 0; i < 81; i++)
            {
                Label l = new Label();
                l.Height = 50;
                l.Width = 100;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Font = new Font("Arial", 20);

                l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                l.Click += new EventHandler(changeValueLabel);
                tabLabel.Add(l);
                this.Grid.Controls.Add(l, i % 9, i / 9);
            }
            initialisationLabel(grille);            
            this.Invalidate();    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cases"></param>
        void initialisationLabel(Grille g)
        {
            var liste = g.GetAllValues();
            for (int i = 0; i < liste.Count; i++)
            {
                tabLabel[i].Text = liste[i].ToString();
                if (tabLabel[i].Text != "0")
                {
                    //tabLabel[i].BackColor = Color.Transparent;
                    tabLabel[i].Click -= new EventHandler(changeValueLabel);
                }
                else
                {
                    tabLabel[i].Text = "";
                    //tabLabel[i].BackColor = Color.White;
                }
                GriserLabel(tabLabel[i], i / 9, i % 9);               
            }
        }

        private void GriserLabel(Label l,int x,int y)
        {
            if (((x>=3)&& (x <= 5)) && (y >= 0) && (y <= 2))
            {
                l.BackColor = Color.White;
            } else if (((x >= 3) && (x <= 5)) && (y >= 6) && (y <= 8))
            {
                l.BackColor = Color.White;

            }
            else if (((x >= 0) && (x <= 2)) && (y >= 3) && (y <= 5))
            {
                l.BackColor = Color.White;

            }
            else if (((x >= 6) && (x <= 8)) && (y >= 3) && (y <= 5))
            {
                l.BackColor = Color.White;
            }
            else
            {
                l.BackColor = Color.LightGray;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                
            }
        }

        private void Vérifier_Click(object sender, EventArgs e)
        {
            if ((Control)sender != this)
            {
                if (grille.CheckSudoku())
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
                        grille = GenerateurGrille.ViderGrilleUnique(50);
                        this.initialisationLabel(grille);
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

        private void changeValueLabel(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                var tabValue = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Label l = (Label)sender;
                var position = this.getPositionOfLabel(l);                
                l.ForeColor = Color.Blue;
                var lastValueLabel = l.Text;
                Console.WriteLine("Entrez un chiffre");
                NumberSudoku ns = new NumberSudoku(l);
                ns.ShowDialog();

                Console.WriteLine("le label à été changé");
                if (lastValueLabel != l.Text)
                {
                    grille.SetCaseValue(position.Item2, position.Item1, Int32.Parse(l.Text));

                }

                try
                {
                    int number;
                    bool success = Int32.TryParse(l.Text, out number);
                    if (success)
                    {
                        var value = Int32.Parse(l.Text);

                        if (tabValue.Contains(value))
                        {
                            grille.SetCaseValue(position.Item2, position.Item1, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }



            }

        }

      
       
        public void Changement(object sender, EventArgs e)
        {
            if ((Control)sender != this)
            {
                TextBox tb = ((TextBox)sender);
                tb.LostFocus -= new EventHandler(Changement);
                TableLayoutPanelCellPosition pos = this.Grid.GetCellPosition(tb);
                grille.SetCaseValue(pos.Row, pos.Column, Int16.Parse(tb.Text));
                if (grille.CheckSudoku())
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
                        grille = GenerateurGrille.GenererGrilleAléatoire(10);
                        this.initialisationLabel(grille);
                    }
                }
            }
        }

        private void helpClick(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Une case du sudoku va être rempli. Voulez-vous utilisez l'aide ?",
                                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (x == DialogResult.No)
            {

            }
            else
            {
                if (isGrilleEgale(this.grille,this.grille.Solution))
                {

                }
                else
                {
                    bool trouve = true;
                    do
                    {
                        Random rnd = new Random();
                        int pos = rnd.Next(1, 81);
                        int value = grille.GetCaseValue(pos / 9, pos % 9);
                        if (value == 0)
                        {
                            grille.SetCaseValue(pos / 9, pos % 9, grille.Solution.GetCaseValue(pos / 9, pos % 9));
                            trouve = false;
                            this.tabLabel[pos].Text = grille.Solution.GetCaseValue(pos / 9, pos % 9).ToString();
                        }
                    } while (trouve);
                }
               
            }
        }
        private bool isGrilleEgale(Grille g1, Grille g2)
        {
            for (var i=0;i<81;i++)
            {
                if (g1.GetCase(i % 9, i / 9).Value != g2.GetCase(i % 9, i / 9).Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
