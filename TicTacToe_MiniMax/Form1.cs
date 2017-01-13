using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_MiniMax
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool XsTurn = true;
        private bool gameOver = false;
        private const int XWINS = 1;
        private const int OWINS = -1;
        private const int DRAW = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttonClick(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gameOver = false;
            XsTurn = true;
            Button[] buttonChoice = new Button[] { button1, button2, button3, 
                                                   button4, button5, button6,
                                                   button7, button8, button9};
            for (int i = 0; i < buttonChoice.Length; i++)
                buttonChoice[i].Text = "";
            label1.Text = "It is X's turn!";
        }
        
        private void buttonClick(object sender, EventArgs e)
        {    
            Button srcButton = sender as Button;
            if (srcButton.Text == "" && XsTurn)
            {
                if (gameOver)
                    return;
                srcButton.Text = "X";
                XsTurn = false;
                if(isWon("X"))
                {
                    gameOver = true;
                    label1.Text = "X wins!";
                    return;
                }
                label1.Text = "Waiting for O...";
            }
            if (!gameOver)
            {
                if (button1.Text != "" && button2.Text != "" && button3.Text != "" &&
                    button4.Text != "" && button5.Text != "" && button6.Text != "" &&
                    button7.Text != "" && button8.Text != "" && button9.Text != "")
                {
                    label1.Text = "It was a tie!";
                    gameOver = true;
                }
            }
            if (!gameOver && !XsTurn)
                computerMakeMove();
            if (!gameOver)
            {
                if (button1.Text != "" && button2.Text != "" && button3.Text != "" &&
                    button4.Text != "" && button5.Text != "" && button6.Text != "" &&
                    button7.Text != "" && button8.Text != "" && button9.Text != "")
                {
                    label1.Text = "It was a tie!";
                    gameOver = true;
                }
            }
        }

        private void computerMakeMove()
        {
            Button[] buttonChoice = new Button[] { button1, button2, button3, 
                                                   button4, button5, button6,
                                                   button7, button8, button9};
            int choice = minimaxTicTacToeDecision();
            Console.WriteLine("O's choice = " + choice);
            buttonChoice[choice].Text = "O";
            if (isWon("O"))
            {
                gameOver = true;
                label1.Text = "O wins!";
                return;
            }
            XsTurn = true;
            label1.Text = "It is X's turn!";
        }

        private bool isWon(string token)
        {
            Button[,] cell = new Button[3, 3] { { button1, button2, button3 }, 
                                                { button4, button5, button6 }, 
                                                { button7, button8, button9 } };
            //Rows
            for (int i = 0; i < 3; i++)
                if ((cell[i, 0].Text == token)
                    && (cell[i, 1].Text == token)
                    && (cell[i, 2].Text == token))
                    return true;
            //Columns
            for (int j = 0; j < 3; j++)
                if ((cell[0, j].Text == token)
                    && (cell[1, j].Text == token)
                    && (cell[2, j].Text == token))
                    return true;
            //Diagonal
            if ((cell[0, 0].Text == token)
                && (cell[1, 1].Text == token)
                && (cell[2, 2].Text == token))
                return true;
            //Other diagonal
            if ((cell[0, 2].Text == token)
                && (cell[1, 1].Text == token)
                && (cell[2, 0].Text == token))
                return true;
            //No winner
            return false;
        }

        private int stateOutcome(int[] currentState)
        {
            int[,] currentState3x3 = new int[3, 3];
            int currentStateNumber = 0;
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                {
                    currentState3x3[i, j] = currentState[currentStateNumber];
                    currentStateNumber++;
                }
            int NOWINNER = 2;
            bool isDraw = true;
            //Rows for X
            for (int i = 0; i < 3; i++)
                if ((currentState3x3[i, 0] == 1)
                    && (currentState3x3[i, 1] == 1)
                    && (currentState3x3[i, 2] == 1))
                    return XWINS;
            //Columns for X
            for (int j = 0; j < 3; j++)
                if ((currentState3x3[0, j] == 1)
                    && (currentState3x3[1, j] == 1)
                    && (currentState3x3[2, j] == 1))
                    return XWINS;
            //Diagonal for X
            if ((currentState3x3[0, 0] == 1)
                && (currentState3x3[1, 1] == 1)
                && (currentState3x3[2, 2] == 1))
                return XWINS;
            //Other diagonal for X
            if ((currentState3x3[0, 2] == 1)
                && (currentState3x3[1, 1] == 1)
                && (currentState3x3[2, 0] == 1))
                return XWINS;
            //Rows for O
            for (int i = 0; i < 3; i++)
                if ((currentState3x3[i, 0] == -1)
                    && (currentState3x3[i, 1] == -1)
                    && (currentState3x3[i, 2] == -1))
                    return OWINS;
            //Columns for O
            for (int j = 0; j < 3; j++)
                if ((currentState3x3[0, j] == -1)
                    && (currentState3x3[1, j] == -1)
                    && (currentState3x3[2, j] == -1))
                    return OWINS;
            //Diagonal for O
            if ((currentState3x3[0, 0] == -1)
                && (currentState3x3[1, 1] == -1)
                && (currentState3x3[2, 2] == -1))
                return OWINS;
            //Other diagonal for O
            if ((currentState3x3[0, 2] == -1)
                && (currentState3x3[1, 1] == -1)
                && (currentState3x3[2, 0] == -1))
                return OWINS;
            //tie
            for (int k = 0; k < 3; k++)
                for (int n = 0; n < 3; n++)
                    if (currentState3x3[k, n] == 0)
                        isDraw = false;
            if (isDraw)
                return DRAW;
            //No winner
            return NOWINNER;
        }

        private int[] getInitialState()
        {
            int[] options = new int[9];
            Button[] buttonChoice = new Button[] { button1, button2, button3, 
                                                   button4, button5, button6,
                                                   button7, button8, button9};
            for (int i = 0; i < 9; i++)
            {
                if (buttonChoice[i].Text == "X")
                    options[i] = 1;
                else if (buttonChoice[i].Text == "O")
                    options[i] = -1;
                else
                    options[i] = 0;
            }
           return options;
        }

        private int minOfArray(int[] array)
        {
            int smallest = int.MaxValue;
            int smallestElementNumber = 0;//arbitrary
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < smallest)
                {
                    smallest = array[i];
                    smallestElementNumber = i;
                }
            }
            Console.WriteLine(smallestElementNumber + " " + smallest);
            return smallestElementNumber;
        }

        private int minimaxTicTacToeDecision()
        {
            int[] state = getInitialState();
            int decision = int.MaxValue;
            int[] choiceList = new int[9];
            for(int option = 0; option < state.Length; option++)
            {
                int[] prospectiveState = getInitialState();
                if (state[option] == 0)
                {
                    prospectiveState[option] = -1;
                    decision = minimum(decision, maxFunction(prospectiveState));
                    choiceList[option] = decision;
                }
                else
                    choiceList[option] = int.MaxValue;
            }
           return minOfArray(choiceList);
        }

        private int minFunction(int[] currentState)
        {
            if (terminalTest(currentState))
                return utilityFunction(currentState);
            int best = int.MaxValue;
            int[] prospectiveState = new int[9];
            for (int newChoice = 0; newChoice < prospectiveState.Length; newChoice++)
            {
                for (int i = 0; i < prospectiveState.Length; i++)
                    prospectiveState[i] = currentState[i];
                if (currentState[newChoice] == 0)
                {
                    prospectiveState[newChoice] = -1;
                    int move = maxFunction(prospectiveState);
                    if (move < best)
                        best = move;
                }
            }
            return best;
        }

        private int maxFunction(int[] currentState)
        {
            if (terminalTest(currentState))
                return utilityFunction(currentState);
            int best = int.MinValue;
            int[] prospectiveState = new int[9];
            for (int newChoice = 0; newChoice < prospectiveState.Length; newChoice++)
            {
                for (int i = 0; i < prospectiveState.Length; i++)
                    prospectiveState[i] = currentState[i];
                if (currentState[newChoice] == 0)
                {
                    prospectiveState[newChoice] = 1;
                    int move = minFunction(prospectiveState);
                    if (move > best)
                        best = move;
                }
            }
            return best;
        }

        private bool terminalTest(int[] currentState)
        {
            if (stateOutcome(currentState) != 2)
                return true;
            else
                return false;
        }

        private int utilityFunction(int[] currentState)
        {
            if (stateOutcome(currentState) == XWINS)
                return XWINS;
            else if (stateOutcome(currentState) == OWINS)
                return OWINS;
            else if (stateOutcome(currentState) == DRAW)
                return DRAW;
            else
                return 10;//ERROR - should not make it here
        }

        private int minimum(int x1, int x2)
        {
            if (x1 > x2)
                return x2;
            else
                return x1;//doesn't matter which if equal
        }

        private int maximum(int y1, int y2)
        {
            if (y1 < y2)
                return y2;
            else
                return y1;//doesn't matter which if equal
        }
    }
}
