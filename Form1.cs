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


            Image xSymbol = Image.FromFile("C:\\Users\\assas\\Desktop\\icons\\circleForTIcTacToe.png");
            Image oSymbol = Image.FromFile("C:\\Users\\assas\\Desktop\\icons\\xSymbol.pn.png");

            game = new TicTacToeGame(xSymbol, oSymbol);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {

           
        }
    }

    public class TicTacToeGame
    {

        public string CurrentPlayer { get; private set; }
        public Image PlayerXSymbol { get; private set; }
        public Image PlayerOSymbol { get; private set; }

        public TicTacToeGame(Image playerXSymbol, Image playerOSymbol) 
        {
            CurrentPlayer = "X"; //it will start X as default
            PlayerXSymbol = playerXSymbol;
            PlayerOSymbol = playerOSymbol;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == "X") ? "X" : "O";
        }

        public Image GetPlayerSymbol()
        {
            if (CurrentPlayer == "X") 
                return PlayerXSymbol;
            else 
                return PlayerOSymbol;
        }

    }
}
