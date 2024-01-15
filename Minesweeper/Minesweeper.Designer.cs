namespace Lopputyö___Minesweeper
{
    partial class Minesweeper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameLayoutPanel = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            difficultyToolStripMenuItem = new ToolStripMenuItem();
            easy = new ToolStripMenuItem();
            medium = new ToolStripMenuItem();
            hard = new ToolStripMenuItem();
            revealMenuItem = new ToolStripMenuItem();
            scoresMenuItem = new ToolStripMenuItem();
            labelTime = new Label();
            comboBoxScores = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gameLayoutPanel
            // 
            gameLayoutPanel.AutoSize = true;
            gameLayoutPanel.ColumnCount = 2;
            gameLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gameLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gameLayoutPanel.Location = new Point(12, 42);
            gameLayoutPanel.Name = "gameLayoutPanel";
            gameLayoutPanel.RowCount = 2;
            gameLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gameLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gameLayoutPanel.Size = new Size(648, 790);
            gameLayoutPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { difficultyToolStripMenuItem, revealMenuItem, scoresMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(754, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // difficultyToolStripMenuItem
            // 
            difficultyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { easy, medium, hard });
            difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            difficultyToolStripMenuItem.Size = new Size(67, 20);
            difficultyToolStripMenuItem.Text = "Difficulty";
            // 
            // easy
            // 
            easy.Name = "easy";
            easy.Size = new Size(119, 22);
            easy.Text = "Easy";
            easy.Click += easy_Click;
            // 
            // medium
            // 
            medium.Name = "medium";
            medium.Size = new Size(119, 22);
            medium.Text = "Medium";
            medium.Click += medium_Click;
            // 
            // hard
            // 
            hard.Name = "hard";
            hard.Size = new Size(119, 22);
            hard.Text = "Hard";
            hard.Click += hard_Click;
            // 
            // revealMenuItem
            // 
            revealMenuItem.Name = "revealMenuItem";
            revealMenuItem.Size = new Size(53, 20);
            revealMenuItem.Text = "Reveal";
            revealMenuItem.Click += revealMenuItem_Click;
            // 
            // scoresMenuItem
            // 
            scoresMenuItem.Name = "scoresMenuItem";
            scoresMenuItem.Size = new Size(53, 20);
            scoresMenuItem.Text = "Scores";
            scoresMenuItem.Click += scoresMenuItem_Click;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            labelTime.Location = new Point(666, 42);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(38, 46);
            labelTime.TabIndex = 3;
            labelTime.Text = "0";
            // 
            // comboBoxScores
            // 
            comboBoxScores.FormattingEnabled = true;
            comboBoxScores.Location = new Point(666, 91);
            comboBoxScores.Name = "comboBoxScores";
            comboBoxScores.Size = new Size(76, 23);
            comboBoxScores.TabIndex = 4;
            // 
            // Minesweeper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(754, 861);
            Controls.Add(labelTime);
            Controls.Add(comboBoxScores);
            Controls.Add(gameLayoutPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Minesweeper";
            Text = "Minesweeper";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem difficultyToolStripMenuItem;
        private ToolStripMenuItem easy;
        private ToolStripMenuItem medium;
        private ToolStripMenuItem hard;
        private ToolStripMenuItem revealMenuItem;
        private Label labelTime;
        private ToolStripMenuItem scoresMenuItem;
        private ComboBox comboBoxScores;
        internal TableLayoutPanel gameLayoutPanel;
    }
}