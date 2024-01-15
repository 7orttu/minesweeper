using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lopputyö___Minesweeper;
using System.Reflection.Emit;

namespace Lopputyö___Minesweeper
{
    public partial class Minesweeper : Form
    {
        private Gameboard gameboard;

        public Button clickedButton;
        private int currentTime = 0;
        List<int> scores = new List<int>();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        internal bool usedCheats = false;


        public Minesweeper()
        {
            InitializeComponent();
            gameboard = new Gameboard(this);
            int rows = gameboard.Rows;
            int columns = gameboard.Columns;
            int bombCount = gameboard.MineCount;

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            comboBoxScores.Items.Clear();
            comboBoxScores.Visible = false;
        }

        //#############################//
        // Vaikeustasot
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }
        // Vaikeustasot
        //#############################//


        //#############################//
        // Vaikeustasojen asetukset
        public void SetDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    gameboard.Rows = 9;   // Rivien määrä
                    gameboard.Columns = 9;    // Kolumnien määrä
                    gameboard.MineCount = 10; // Miinojen määrä
                    break;
                case Difficulty.Medium:
                    gameboard.Rows = 16;
                    gameboard.Columns = 16;
                    gameboard.MineCount = 40;
                    break;
                case Difficulty.Hard:
                    gameboard.Rows = 30;
                    gameboard.Columns = 16;
                    gameboard.MineCount = 99;
                    break;
                default:
                    break;
            }
            gameLayoutPanel.RowCount = gameboard.Rows;
            gameLayoutPanel.ColumnCount = gameboard.Columns;

            gameLayoutPanel.Controls.Clear();
            gameLayoutPanel.ColumnStyles.Clear();
            gameLayoutPanel.RowStyles.Clear();
        }
        // Vaikeustasojen asetukset
        //#############################//


        // --- //
        public void btn_Click(object sender, EventArgs e)
        {
            clickedButton = (Button)sender;
            string buttonName = clickedButton.Name;

            if (buttonName.StartsWith("btn_"))
            {
                string[] parts = buttonName.Split('_');
                if (parts.Length == 3)
                {
                    int row = int.Parse(parts[1]);
                    int col = int.Parse(parts[2]);

                    if (gameboard.IsBomb(row, col))
                    {
                        gameboard.Lose();
                    }
                    else
                    {
                        if (gameboard.gridButtons[row, col].BackColor == Color.LightGreen)
                        {
                            return;
                        }
                        int count = gameboard.CountAndRevealAdjacentCells(row, col);
                        if (count == 0)
                        {
                            gameboard.RecursiveSafeCellReveal(row, col);
                        }
                    }
                }
            }
            gameboard.CheckWinCondition();
        }
        // --- //


        // --- //
        public void btn_MouseDown(object sender, MouseEventArgs e)
        {
            // Nappien liputus
            if (e.Button == MouseButtons.Right)
            {

                if (((Button)sender).BackColor == Color.Red)    // Jos on jo punainen, muuttaa värin takaisin
                {
                    ((Button)sender).BackColor = Color.Transparent;
                }

                else if (((Button)sender).BackColor == Color.LightGreen) { }  // Vihreää ei voi liputtaa
                else if (((Button)sender).BackColor == Color.Orange) { }  // Oransseja ei tarvitse liputtaa

                else
                {
                    ((Button)sender).BackColor = Color.Red; //  Muussa tapauksessa muuttaa punaiseksi
                }

            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                F5Reveal();
            }
        }
        // --- //


        //#############################//
        // Vaikeustasot
        private void easy_Click(object sender, EventArgs e)
        {
            SetDifficulty(Difficulty.Easy);
            gameboard.SetupGameBoard();
            StartTimer();
        }

        private void medium_Click(object sender, EventArgs e)
        {
            SetDifficulty(Difficulty.Medium);
            gameboard.SetupGameBoard();
            StartTimer();
        }

        private void hard_Click(object sender, EventArgs e)
        {
            SetDifficulty(Difficulty.Hard);
            gameboard.SetupGameBoard();
            StartTimer();
        }
        // Vaikeustasot
        //#############################//


        //#############################//
        // Cheats
        private void revealMenuItem_Click(object sender, EventArgs e)
        {
            RevealCheat();
            usedCheats = true;
            StopTimer();
            MessageBox.Show("You used a cheat");
        }
        private void RevealCheat()
        {
            for (int row = 0; row < gameboard.Rows; row++)
            {
                for (int col = 0; col < gameboard.Columns; col++)
                {
                    if (gameboard.IsBomb(row, col))
                    {
                        gameboard.gridButtons[row, col].BackColor = Color.Orange;
                    }
                }
            }
        }
        private void F5Reveal()
        {
            RevealCheat();
        }
        // Cheats
        //#############################//


        //#############################//
        // Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTime++;
            labelTime.Text = currentTime.ToString();
        }
        public void StartTimer()
        {
            currentTime = 0;
            timer.Start();
        }
        public void StopTimer()
        {
            timer.Stop();
        }
        // Timer
        //#############################//


        //#############################//
        // Score
        public void Score()
        {
            int newScore = currentTime;
            scores.Add(newScore);

            comboBoxScores.Items.Add(newScore);
        }
        private void scoresMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxScores.Visible == true)
            {
                comboBoxScores.Visible = false;
            }
            else
            {
                comboBoxScores.Visible = true;
            }
        }
        // Score
        //#############################//

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}