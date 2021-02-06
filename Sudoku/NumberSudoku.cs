﻿using System;
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
        public NumberSudoku(Label l)
        {
            InitializeComponent();
            label = l;
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
                    label.Text = "";
                    break;
                default:
                    this.Close();
                    break;

            }
            label.BackColor = Color.Transparent;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
