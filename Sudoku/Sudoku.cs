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
        private List<Label> tabTB;
        Grille grille = new Grille();
        public Sudoku()
        {
            InitializeComponent();
            Console.Write("Intialisation");
            grille = GenerateurGrille.genererGrilleAléatoire(81);
            tabTB = new List<Label>();
            //tabRect = new List<Rectangle>();
            for (int i = 0; i < 81; i++)
            {
                Rectangle r = new Rectangle();
                Label t = new Label();
               
                t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                t.Text = "" + grille.getCaseValue(i / 9, i % 9);               
                t.Click += new EventHandler(changeValueLabel);
                tabTB.Add(t);
                //tabRect.Add(r);
                this.Grid.Controls.Add(t, i % 9, i / 9);
                //this.Grid.Controls.Add(r, i % 9, i / 9);
            }
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
                    tabTB[i].BackColor = Color.White;
                }
                else
                {
                    tabTB[i].Text = "";
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
                        //TODO : Ca marche pas 
                        //tb.LostFocus -= new EventHandler(Changement);
                        grille = GenerateurGrille.genererGrilleAléatoire(10);
                        this.initialisationTextBox(grille);
                        //tb.LostFocus += new EventHandler(Changement);
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
            //Console.Write("Paint");
            //Graphics g = e.Graphics;

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {

            //        g.DrawRectangle(Pens.Black, new Rectangle(50 * i, 50 * j, 100, 100));
            //    }
            //}
        }

        private void Grid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void changeValueLabel(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                Label l = (Label)sender;
                var position = this.getPositionOfLabel(l);
                l.BackColor = Color.CadetBlue;
                Console.WriteLine("Entrez un chiffre");
                NumberSudoku ns = new NumberSudoku(l);
                ns.ShowDialog();

                Console.WriteLine("le label à été changé");
                grille.setCaseValue(position.Item2,position.Item1,Int32.Parse(l.Text));

                //il faut changer la valeur dans le back
                //TODO


                               
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
