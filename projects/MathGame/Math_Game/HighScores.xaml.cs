using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace Math_Game
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        List<Score> lstHighScores = new List<Score>();
        // Create a new instance of the SoundPlayer class and provide the path to the .wav file
        SoundPlayer mainGameSound = new SoundPlayer("PinkPantheress - Another life (feat. Rema) - Instrumental.wav");

        public HighScores()
        {
            InitializeComponent();
            mainGameSound.PlayLooping();
        }

        /// <summary>
        /// Close high score button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdCloseHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        /// <summary>
        /// Window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            

        }

        /// <summary>
        /// Displays the scores to the user
        /// </summary>
        /// <param name="correctAnswers"></param>
        /// <param name="incorrectAnswers"></param>
        /// <param name="time"></param>
        public void DisplayUserScore(int correctAnswers, int incorrectAnswers, int time)
        {
            try
            {
                string userName = clsUser.Name;
                int userAge = clsUser.Age;
                int userScore = correctAnswers;
                int userIncorrect = incorrectAnswers;
                int userTime = time;

                Score currentUserScore = new Score { Name = userName, iScore = userScore, iTime = userTime, Age = userAge, iIncorrect = userIncorrect };

                bool scoreAdded = false;

                // Loop through the top 10 high scores
                for (int i = 0; i < lstHighScores.Count; i++)
                {
                    if (userScore > lstHighScores[i].iScore || (userScore == lstHighScores[i].iScore && userTime < lstHighScores[i].iTime))
                    {
                        lstHighScores.Insert(i, currentUserScore);
                        scoreAdded = true;
                        break;
                    }
                }

                // If the score was not added, add it to the end
                if (!scoreAdded)
                {
                    lstHighScores.Add(currentUserScore);
                }

                // Remove the last score in the list if the count exceeds 10
                if (lstHighScores.Count > 10)
                {
                    lstHighScores.RemoveAt(10);
                }

                DisplayTopScores();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Finds the top scores and displays them
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void DisplayTopScores()
        {

            try
            {
                // Clear the existing content in the TextBox
                txtHighScores.Text = "";

                // Loop through the top 10 high scores and display them
                for (int i = 0; i < Math.Min(10, lstHighScores.Count); i++)
                {
                    //display score
                    txtHighScores.Text += $"{(i + 1)}. {lstHighScores[i].Name}\tAge: {lstHighScores[i].Age}\tCorrect: {lstHighScores[i].iScore}  Incorrect: {lstHighScores[i].iIncorrect}  Time: {lstHighScores[i].iTime}\n";
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Score class
        /// </summary>
        public class Score
        {
            public int iScore { get; set; } 
            public int iTime { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int iIncorrect { get; set; }
        }
    }
}
