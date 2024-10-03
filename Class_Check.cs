using System;

public class Check
{
    // Open constructor
    public Check()
    {

    }

	public Check()
	{
		if(button1.Text == "X" && button2.Text == "X" && button3.Text == "X" || // Checks horizontal
           button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
           button7.Text == "X" && button8.Text == "X" && button9.Text == "X" || 
           button1.Text == "X" && button4.Text == "X" && button7.Text == "X" || // Checks vertical
           button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
           button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
           button1.Text == "X" && button5.Text == "X" && button9.Text == "X" || // Checks diagonal
           button3.Text == "X" && button5.Text == "X" && button7.Text == "X" ||)
        {
            if (CurrentPlayer == "X")
            {
                Console.WriteLine("Player X WINS!");
            }
            else
            {
                SwitchPlayer();
            }
        }

        else if(button1.Text == "O" && button2.Text == "O" && button3.Text == "O" || // Checks horizontal
                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
                button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button4.Text == "O" && button7.Text == "O" || // Checks vertical
                button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
                button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button5.Text == "O" && button9.Text == "O" || // Checks diagonal
                button3.Text == "O" && button5.Text == "O" && button7.Text == "O" ||)
        {
            if (CurrentPlayer == "O")
            {
                Console.WriteLine("Player O WINS!");
            }
            else
            {
                ResetGame();
            }
        }
    }
}
