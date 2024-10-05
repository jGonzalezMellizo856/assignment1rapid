using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment1rapid
{
    public partial class newgame : Form
    {
        private TicTacToeGame game;

        public newgame()
        {
            InitializeComponent();
            Image xSymbol = Image.FromFile(@"C:\Users\nafia\OneDrive - Bow Valley College\Desktop\assignment1rapid-Nafiyads-branch\Properties\xSymbol.pn.png");
            Image oSymbol = Image.FromFile(@"C:\Users\nafia\OneDrive - Bow Valley College\Desktop\assignment1rapid-Nafiyads-branch\Properties\circleForTIcTacToe.png");
            game = new TicTacToeGame(xSymbol, oSymbol);
            UpdateCurrentPlayerLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.BackgroundImage == null && !game.IsGameOver)
            {
                Image currentPlayerSymbol = game.GetPlayerSymbol();
                clickedButton.BackgroundImage = currentPlayerSymbol;
                clickedButton.Enabled = false;

                int buttonIndex = int.Parse(clickedButton.Name.Substring(6)) - 1;
                game.MakeMove(buttonIndex);

                if (game.CheckForWinner())
                {
                    EndGame($"Player {game.CurrentPlayer} wins!");
                }
                else if (game.IsBoardFull())
                {
                    EndGame("It's a draw!");
                }
                else
                {
                    game.SwitchPlayer();
                    UpdateCurrentPlayerLabel();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void UpdateCurrentPlayerLabel()
        {
            label3.Text = $"Current Player: {game.CurrentPlayer}";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            game.ResetGame();
            foreach (Control control in Controls)
            {
                if (control is Button btn && btn != button10)
                {
                    btn.BackgroundImage = null;
                    btn.Enabled = true;
                }
            }
            UpdateCurrentPlayerLabel();
        }

        private void EndGame(string message)
        {
            game.IsGameOver = true;
            label3.Text = message;
            foreach (Control control in Controls)
            {
                if (control is Button btn && btn != button10)
                {
                    btn.Enabled = false;
                }
            }
        }
    }

    public class TicTacToeGame
    {
        public string CurrentPlayer { get; private set; }
        public Image PlayerXSymbol { get; private set; }
        public Image PlayerOSymbol { get; private set; }
        public bool IsGameOver { get; set; }
        private string[] board;

        public TicTacToeGame(Image playerXSymbol, Image playerOSymbol)
        {
            CurrentPlayer = "X";
            PlayerXSymbol = playerXSymbol;
            PlayerOSymbol = playerOSymbol;
            board = new string[9];
            IsGameOver = false;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
        }

        public Image GetPlayerSymbol()
        {
            return (CurrentPlayer == "X") ? PlayerXSymbol : PlayerOSymbol;
        }

        public void ResetGame()
        {
            CurrentPlayer = "X";
            board = new string[9];
            IsGameOver = false;
        }

        public void MakeMove(int position)
        {
            if (position >= 0 && position < 9 && string.IsNullOrEmpty(board[position]))
            {
                board[position] = CurrentPlayer;
            }
        }

        public bool CheckForWinner()
        {
            int[][] winningCombinations = new int[][]
            {
                new int[] {0, 1, 2}, new int[] {3, 4, 5}, new int[] {6, 7, 8}, // Rows
                new int[] {0, 3, 6}, new int[] {1, 4, 7}, new int[] {2, 5, 8}, // Columns
                new int[] {0, 4, 8}, new int[] {2, 4, 6} // Diagonals
            };

            foreach (var combination in winningCombinations)
            {
                if (board[combination[0]] == CurrentPlayer &&
                    board[combination[1]] == CurrentPlayer &&
                    board[combination[2]] == CurrentPlayer)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsBoardFull()
        {
            return board.All(cell => !string.IsNullOrEmpty(cell));
        }
    }
}