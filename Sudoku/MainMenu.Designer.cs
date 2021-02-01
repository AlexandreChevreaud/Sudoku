
namespace Sudoku
{
    partial class MainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jouerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jouerAuSudokuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jouerAuMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jouerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(260, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jouerToolStripMenuItem
            // 
            this.jouerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jouerAuSudokuToolStripMenuItem,
            this.jouerAuMemoryToolStripMenuItem});
            this.jouerToolStripMenuItem.Name = "jouerToolStripMenuItem";
            this.jouerToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.jouerToolStripMenuItem.Text = "Jouer";
            // 
            // jouerAuSudokuToolStripMenuItem
            // 
            this.jouerAuSudokuToolStripMenuItem.Name = "jouerAuSudokuToolStripMenuItem";
            this.jouerAuSudokuToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.jouerAuSudokuToolStripMenuItem.Text = "Jouer au Sudoku";
            this.jouerAuSudokuToolStripMenuItem.Click += new System.EventHandler(this.jouerAuSudokuToolStripMenuItem_Click);
            // 
            // jouerAuMemoryToolStripMenuItem
            // 
            this.jouerAuMemoryToolStripMenuItem.Name = "jouerAuMemoryToolStripMenuItem";
            this.jouerAuMemoryToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.jouerAuMemoryToolStripMenuItem.Text = "Jouer au memory";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 114);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_Closing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jouerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jouerAuSudokuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jouerAuMemoryToolStripMenuItem;
    }
}