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
    public partial class Form1 : Form
    {
        private TicTacToeGame game;

        public Form1()
        {
            InitializeComponent();


            Image xSymbol = Image.FromFile(@"C:\Users\assas\Desktop\OOP class\assignment1rapid\Properties\xSymbol.pn.png");
            Image oSymbol = Image.FromFile(@"C:\Users\assas\Desktop\OOP class\assignment1rapid\Properties\circleForTIcTacToe.png");

            game = new TicTacToeGame(xSymbol, oSymbol);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

                if (clickedButton != null)//when the buttons are presed the current player is updated and the symbol then changes
                {
                    Image currentPlayerSymbol = game.GetPlayerSymbol();

                    clickedButton.BackgroundImage = currentPlayerSymbol;

                    clickedButton.Enabled = false;

                    game.SwitchPlayer();

                }

        }
    }

    public class TicTacToeGame
    {

        public string CurrentPlayer { get; private set; }
        public Image PlayerXSymbol { get; private set; }
        public Image PlayerOSymbol { get; private set; }

        private int turnCount = 0;

        public TicTacToeGame(Image playerXSymbol, Image playerOSymbol) 
        {
            CurrentPlayer = "X"; //it will start X as default
            PlayerXSymbol = playerXSymbol;
            PlayerOSymbol = playerOSymbol;
        }

        public void SwitchPlayer()
        {

            turnCount++;

            if(turnCount >= 9)//once the turn becomes a draw the game should reset 
            {
                MessageBox.Show("game is a draw");
                ResetGame();
            }

            if (CurrentPlayer == "X")
            {
                CurrentPlayer = "O";
                //MessageBox.Show("Player was switched");
            }
            else
            {
                CurrentPlayer = "X";
                
            }
            //MessageBox.Show(CurrentPlayer);
        }

        public Image GetPlayerSymbol()
        {
            if(CurrentPlayer == "X")
            {
                return PlayerXSymbol;
            }
            else
            {
                return PlayerOSymbol;
            }
                
        }

        public void ResetGame()//allows game to reset
        {
            CurrentPlayer = "X";
            turnCount = 0;
        }

    }
}
