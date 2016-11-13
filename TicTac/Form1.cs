using System;
using System.Windows.Forms;

namespace TicTac
{
    public partial class Form1 : Form
    {

        public bool turn = true; //true = X , false = O;
        public int turn_count;

        public Form1()
        {
            InitializeComponent();
        }
        // about 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Rovshan", "Tic Tac Toe");
        }
        //exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
             

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;  
            b.Enabled = false; //disable the clicked button
            turn_count++; // counts till  turn_count's value = 9

    
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool findWinner = false;

            //horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))

                findWinner = true;


            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))

                findWinner = true;

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))

                findWinner = true;
            //vertical checks
           else  if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))

                findWinner = true;


            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))

                findWinner = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))

                findWinner = true;
            //diagonal checks
       
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))

                findWinner = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))

                findWinner = true;

            if (findWinner)
            {
                disableButtons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    MessageBox.Show(winner + " won");
                }
                else
                {
                    winner = "X";
                    MessageBox.Show(winner + " won");
                }
            }else if (turn_count == 9)
            {
                MessageBox.Show("There is no winner");
            }

        }

        private void disableButtons()
        {
            
                foreach (var c in Controls)
                {
                    if (c is Button)
                    {
                    Button b = (Button)c;
                    b.Enabled = false;
                }

                   
                }
           
                
            
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn_count = 0;
            turn = true;

            try
            {
                foreach (var c in Controls)
                {
                    Button b = (Button) c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {
                
            }
        }
    }
    
}
