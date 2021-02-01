using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class MainMenu : Form
    {
        private Sudoku Sudoku;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void jouerAuSudokuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sudoku = new Sudoku();
            Sudoku.Show();
            this.Hide();
        }

        private void MainMenu_Closing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
            
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
