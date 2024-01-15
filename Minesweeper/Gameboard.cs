using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lopputyö___Minesweeper;

namespace Lopputyö___Minesweeper
{
    public class Gameboard
    {
        private Minesweeper form;

        internal Button[,] gridButtons;
        private int rows, columns, mineCount; // Kolumnien, rivien ja miinojen muuttujien luonti
        public bool[,] bombs { get; private set; }
        private int amountOfLosses = 0;

        public Gameboard(Minesweeper form) 
        {
            this.form = form;
        }

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public int MineCount
        {
            get { return mineCount; }
            set { mineCount = value; }
        }



        // --- //
        public void SetupGameBoard()
        {
            gridButtons = new Button[rows, columns];
            form.gameLayoutPanel.Enabled = true;

            int buttonWidth = 30;
            int buttonHeight = 25;

            // Kutsutaan pommien luonti metodia
            GenerateBombs(rows, columns, mineCount);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Button button = new Button();
                    button.Name = $"btn_{row}_{col}";
                    button.Text = "";
                    button.Width = buttonWidth;
                    button.Height = buttonHeight;
                    button.Click += form.btn_Click;
                    button.MouseDown += form.btn_MouseDown;

                    form.gameLayoutPanel.Controls.Add(button, col, row);

                    gridButtons[row, col] = button;
                }
            }
        }
        // --- //


        // --- //
        public int CountAndRevealAdjacentCells(int row, int col)
        {
            if (gridButtons[row, col] == null)
            {
                return 0;
            }

            if (gridButtons[row, col].BackColor == Color.LightGreen)
            {
                return 0;
            }

            int count = 0;
            // Tarkistaa naapurisolut
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r >= 0 && r < rows && c >= 0 && c < columns)
                    {
                        if (IsBomb(r, c))
                        {
                            count++;
                        }
                    }
                }
            }

            // Jos naapurisoluissa on pommeja, napin teksti näyttää niiden määrän
            if (count > 0)
            {
                gridButtons[row, col].Text = count.ToString();
            }
            // Jos naapuripommeja ei ole, asettaa värin vihreäksi ja rekursiivisesti kutsuu itseään
            else
            {
                gridButtons[row, col].BackColor = Color.LightGreen;

                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        if (r >= 0 && r < rows && c >= 0 && c < columns)
                        {
                            if (gridButtons[r, c].BackColor != Color.LightGreen)
                            {
                                count += CountAndRevealAdjacentCells(r, c);
                            }
                        }
                    }
                }
            }

            return count;
        }
        // --- //


        // --- //
        public void RecursiveSafeCellReveal(int row, int col)
        {

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    // Tarkistaa että onko solu rajojen sisällä ja että onko se jo paljastettu
                    if (r >= 0 && r < rows && c >= 0 && c < columns && gridButtons[r, c].BackColor != Color.LightGreen)
                    {
                        // Kutsutaan metodia laskemaan läheisten pommien määrä
                        int count = CountAndRevealAdjacentCells(r, c);

                        if (count == 0)
                        {
                            // Jos pommeja ei ole niin metodi kutsuu itseään rekursiivisesti
                            RecursiveSafeCellReveal(r, c);
                        }
                    }
                }
            }
        }
        // --- //


        // --- //
        public bool IsBomb(int row, int col)
        {
            return bombs[row, col];
        }

        public void GenerateBombs(int rows, int columns, int bombCount)
        {
            bombs = new bool[rows, columns];
            Random random = new Random();

            for (int i = 0; i < bombCount; i++)
            {
                int row, col;
                do
                {
                    row = random.Next(rows);
                    col = random.Next(columns);
                } while (bombs[row, col]);

                bombs[row, col] = true;
            }
        }
        // --- //


        // --- //
        public void CheckWinCondition()
        {
            int totalButtons = rows * columns;
            int revealedCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (gridButtons[row, col].BackColor == Color.LightGreen ||
                        (gridButtons[row, col].Text != "" && !IsBomb(row, col)))
                    {
                        revealedCount++;
                    }
                }
            }

            if (revealedCount == totalButtons - mineCount)
            {
                Win();
            }
        }
        // --- //


        // --- //
        private void Win()
        {
            if(form.usedCheats == false)
            {
                form.StopTimer();
                MessageBox.Show("You WON! (score saved)");
                form.gameLayoutPanel.Enabled = false;
                form.Score();
            }
            else
            {
                form.StopTimer();
                MessageBox.Show("You WON! (score not saved)");
                form.gameLayoutPanel.Enabled = false;
                form.usedCheats = false;
            }
        }

        public void Lose()
        {
            form.clickedButton.BackColor = Color.Black;
            form.StopTimer();
            MessageBox.Show("Game Over. You clicked a bomb!");
            form.gameLayoutPanel.Enabled = false;
            amountOfLosses++;
            MessageBox.Show("Your number of losses : " + amountOfLosses);
        }
        // --- //
    }
}
