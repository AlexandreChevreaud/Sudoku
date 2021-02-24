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
    public partial class NumberSudoku : Form
    {
        private Label label;
        private List<Button> buttons = new List<Button>();
        public NumberSudoku(Label l)
        {
            InitializeComponent();
            label = l;
            int[,] value = {
                    {1, 2,3},
                    { 4,5,6},
                    {7,8,9}
                };
            for (int i=1;i<4;i++)
            {
                for (int j=1; j<4;j++)
                {
                    var b = new Button();
                    var sum = j + i * (i - 1);
                    b.Text = value[i - 1, j - 1].ToString();
                    b.Height = 75;
                    b.Width  = 75;
                    this.buttons.Add(b);
                    b.KeyPress += new KeyPressEventHandler(NumberSudoku_KeyPress);
                    b.Click += new EventHandler(ButtonsClick);

                    this.GridButtons.Controls.Add(b, j-1, i-1);
                }
                
            }
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Button")
            {
                Button b = (Button)sender;
                label.Text = b.Text;
            }
            this.Close();
        }

        private void NumberSudoku_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case '1':
                    label.Text = "1";
                    break;
                case '2':
                    label.Text = "2";
                    break;
                case '3':
                    label.Text = "3";
                    break;
                case '4':
                    label.Text = "4";
                    break;
                case '5':
                    label.Text = "5";
                    break;
                case '6':
                    label.Text = "6";
                    break;
                case '7':
                    label.Text = "7";
                    break;
                case '8':
                    label.Text = "8";
                    break;
                case '9':
                    label.Text = "9";
                    break;
                default:
                    this.Close();
                    break;

            }
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void affectValueToLabel(int i)
        {
            this.label.Text = i.ToString();
        }



        private void NumberSudoku_FormClosing(object sender, FormClosingEventArgs e)
        {
            label.BackColor = Color.White;

        }

        private void NumberSudoku_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void Grid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
