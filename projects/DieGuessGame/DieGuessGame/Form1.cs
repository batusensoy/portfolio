using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//Need to include to use threading
using System.Threading;

namespace DieGuessGame
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Number of times played
        /// </summary>
        private int NtimesPlayed = 0;

        /// <summary>
        /// Number of times won
        /// </summary>
        private int NtimesWon = 0;

        /// <summary>
        /// Number of times lost
        /// </summary>
        private int NtimesLost = 0;

        /// <summary>
        /// frequency that each number was rolled. Also used to calculate percentage 
        /// </summary>
        private int[] rollFrequency = new int[6];

        /// <summary>
        /// number of times the user guessed that number. 
        /// </summary>
        private int[] guessFrequency = new int[6];

        public Form1()
        {
            InitializeComponent();

            // Set the MaxLength property of the TextBox
            txtEnterGuess.MaxLength = 1;
        }

        /// <summary>
        /// This method simulates the dice roll. It also gets input from the user and calculates number of times played/won/lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRoll_Click(object sender, EventArgs e)
        {
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            if (int.TryParse(txtEnterGuess.Text, out int userGuess) && userGuess >= 1 && userGuess <= 6)
            {
                // Create a random number object
                Random random = new Random();
                // Using the random number object create random a number between 1 and 6
                int randomNumber = random.Next(1, 7);

                NtimesPlayed++;
                rollFrequency[randomNumber - 1]++;
                guessFrequency[userGuess - 1]++;

                lblNtimesPlayed.Text = "Number of Times Played: " + NtimesPlayed;

                for (int i = 1; i < 7; i++)
                {
                    int randomDieFace = random.Next(1, 7); // only to show a random dice image to simulate rolling
                    pbImage.Image = Image.FromFile("die" + randomDieFace.ToString() + ".gif");
                    pbImage.Refresh();
                    Thread.Sleep(200);
                }

                // Display the final rolled image based on the random number
                pbImage.Image = Image.FromFile("die" + randomNumber.ToString() + ".gif");

                if (userGuess == randomNumber)
                {
                    NtimesWon++;
                    lblNtimesWon.Text = "Number of Times Won: " + NtimesWon;
                    
                }
                else
                {
                    NtimesLost++;
                    lblNtimesLost.Text = "Number of Times Lost: " + NtimesLost;
                }
                UpdateLabels();

                //clear the txtEnterGuess after the cmdRoll is clicked
                txtEnterGuess.Text = "";

                // Hide the error label after getting correct input
                lblErrorMessage.Visible = false;
            }
            else
            {
                // Make the error label visible
                lblErrorMessage.Visible = true; 

                //clear the txtEnterGuess after the cmdRoll is clicked
                txtEnterGuess.Text = "";
            }
        }

        /// <summary>
        /// This method keeps track of the frequency and percentage that each number was rolled, and the number of times the user guessed that number. 
        /// </summary>
        private void UpdateLabels()
        {
            richTextBox1.Text = "FACE\tFREQUENCY\tPERCENTAGE\tNUMBER OF TIMES GUESSED\n";

            for (int i = 0; i < 6; i++)
            {
                double percentage = ((double)rollFrequency[i] / (double)NtimesPlayed) * 100;
                richTextBox1.Text += $"{i + 1}\t{rollFrequency[i]}\t\t{percentage:F2}%\t\t{guessFrequency[i]}\n";
            }
        }

        /// <summary>
        /// This method returns the game to its initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReset_Click(object sender, EventArgs e)
        {
            // Reset all variables
            NtimesPlayed = 0;
            NtimesWon = 0;
            NtimesLost = 0;
            
            txtEnterGuess.Text = "";
            lblNtimesPlayed.Text = "Number of Times Played: ";
            lblNtimesWon.Text = "Number of Times Won: ";
            lblNtimesLost.Text = "Number of Times Lost: ";

            // Code snippet from Internet (Searched how to clear an array in C#)
            Array.Clear(rollFrequency, 0, rollFrequency.Length);
            Array.Clear(guessFrequency, 0, guessFrequency.Length);

            // Clear image
            pbImage.Image = null;

            // Clear richTextBox
            richTextBox1.Clear();
        }
    }
}
