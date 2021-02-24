
namespace Sudoku
{
    partial class NumberSudoku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.GridButtons = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entrez un nombre entre 1 et 9(via votre clavier ou utilisez le clavier ci-dessus)" +
    "";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GridButtons
            // 
            this.GridButtons.AutoSize = true;
            this.GridButtons.ColumnCount = 3;
            this.GridButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GridButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GridButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GridButtons.Location = new System.Drawing.Point(65, 44);
            this.GridButtons.Margin = new System.Windows.Forms.Padding(0);
            this.GridButtons.Name = "GridButtons";
            this.GridButtons.RowCount = 3;
            this.GridButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GridButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GridButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GridButtons.Size = new System.Drawing.Size(428, 276);
            this.GridButtons.TabIndex = 1;
            this.GridButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.Grid_Paint);
            // 
            // NumberSudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 338);
            this.Controls.Add(this.GridButtons);
            this.Controls.Add(this.label1);
            this.Name = "NumberSudoku";
            this.Text = "Entrez un chiffre";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NumberSudoku_FormClosing);
            this.Load += new System.EventHandler(this.NumberSudoku_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberSudoku_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel GridButtons;
    }
}