using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace Math_Game
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private clsGame mathGame;
        private MathGameQuestion currentQuestion;
        private int iNumberCorrect;
        private int iNumberIncorrect;

        int iCurrentGameQuestion; // which question is user on 1 to 10
        int iSeconds;             // how many seconds have elapsed in the game
        DispatcherTimer MyTimer;

        /// <summary>
        /// Variable to hold the high scores form.
        /// </summary>
        private HighScores wndCopyHighScores;

        /// <summary>
        /// Property to get and set the high scores.
        /// </summary>
        public HighScores CopyHighScores
        {
            get { return wndCopyHighScores; }
            set { wndCopyHighScores = value; }
        }

        // Create a new instance of the SoundPlayer class and provide the path to the .wav file
        SoundPlayer mainGameSound = new SoundPlayer("PinkPantheress - Another life (feat. Rema) - Instrumental.wav");
        SoundPlayer WrongAnswerSound = new SoundPlayer("FX [Flatbed].wav");
        SoundPlayer CorrectAnswerSound = new SoundPlayer("Nextel.wav");

        public Game()
        {
            InitializeComponent();

            mathGame = new clsGame();
            iCurrentGameQuestion = 1;
            iSeconds = 0;
            MyTimer = new DispatcherTimer();
            MyTimer.Interval = TimeSpan.FromSeconds(1);
            MyTimer.Tick += Timer_Tick;

            // Initially disable the "End Game" button
            cmdEndGame.IsEnabled = false;

            // Disable high scores button
            cmdHighScores.IsEnabled = false;

            // Disable the text box
            txtUserGuess.IsEnabled = false;


        }

        /// <summary>
        /// Start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iNumberCorrect = 0;
                iNumberIncorrect = 0;
                iSeconds = 0;
                iCurrentGameQuestion = 1;

                // Clear UI elements
                ResetUI();

                // Reset timer
                MyTimer.Stop();
                lblTimer.Content = "Time: 0 s";

                // Restart timer
                MyTimer.Start();

                // Enable the "End Game" button when the game starts
                cmdEndGame.IsEnabled = true;

                // Enable the text box for user input
                txtUserGuess.IsEnabled = true;

                DisplayQuestion();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Displays the seconds elapsed to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTimer.Content = "Time: " + iSeconds + " s";
                iSeconds++;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Dsiplays the question 
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void DisplayQuestion()
        {
            try
            {
                // Clear previous user's guess
                txtUserGuess.Text = "";

                currentQuestion = mathGame.GenerateQuestion();
                lblQuestion.Content = $"{currentQuestion.LeftNumber} {GetOperationSymbol()} {currentQuestion.RightNumber} = ";
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        /// <summary>
        /// Get operation symbol
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        private char GetOperationSymbol()
        {
            try
            {
                switch (clsGame.CurrentGameType)
                {
                    case clsGame.GameType.Add:
                        return '+';
                    case clsGame.GameType.Subtract:
                        return '-';
                    case clsGame.GameType.Mult:
                        return '*';
                    case clsGame.GameType.Divide:
                        return '/';
                    default:
                        throw new ArgumentOutOfRangeException();
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
        /// The user submits the answer, it shows if the answer is correct or wrong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userGuess;
                if (int.TryParse(txtUserGuess.Text, out userGuess))
                {
                    bool isCorrect = mathGame.ValidateUserGuess(userGuess);

                    // Play the correct or wrong sound on a separate thread
                    System.Threading.ThreadPool.QueueUserWorkItem(state =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            if (isCorrect)
                            {
                                CorrectAnswerSound.PlaySync(); // Play correct sound
                                iNumberCorrect++;
                                lblAnswer.Content = "Correct!";
                                lblAnswer.Foreground = Brushes.LightGreen;
                            }
                            else
                            {
                                WrongAnswerSound.PlaySync(); // Play wrong sound
                                iNumberIncorrect++;
                                lblAnswer.Content = "Wrong!";
                                lblAnswer.Foreground = Brushes.Red;
                            }

                            lblAnswer.Visibility = Visibility.Visible;
                            lblValidAnswer.Content = "";

                            iCurrentGameQuestion++;
                            if (iCurrentGameQuestion <= 10)
                            {
                                DisplayQuestion();
                            }
                            else
                            {
                                EndGame();
                            }
                        });
                    });

                    // Play the main game sound in the background
                    System.Threading.ThreadPool.QueueUserWorkItem(state =>
                    {
                        mainGameSound.PlayLooping();
                    });
                }
                else
                {
                    lblValidAnswer.Content = "Please enter a valid number. ";
                }
            }
            catch (Exception ex)
            {
                // This is the top-level method, so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Ends the game and stops the timer
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void EndGame()
        {
            try
            {
                MyTimer.Stop();

                // Disable the "End Game" button after the game ends
                cmdEndGame.IsEnabled = false;

                // Enable high scores button
                cmdHighScores.IsEnabled = true;

                wndCopyHighScores.DisplayUserScore(iNumberCorrect, iNumberIncorrect, iSeconds);
                wndCopyHighScores.ShowDialog();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// End game button for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdEndGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EndGame();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }  
        }

        /// <summary>
        /// Shows the high scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide the game form
                this.Hide();
                //Show the high scores
                wndCopyHighScores.ShowDialog();

                // Reset variables and UI elements when coming back from high scores
                iNumberCorrect = 0;
                iSeconds = 0;
                iCurrentGameQuestion = 1;

                txtUserGuess.Text = "";  // Clear user's previous guesses
                lblQuestion.Content = ""; // Clear previous question

                this.Show();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        /// <summary>
        /// Resets the user interface
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void ResetUI()
        {
            try
            {
                txtUserGuess.Text = "";
                lblQuestion.Content = "";
                lblAnswer.Content = "";
                lblValidAnswer.Content = "";
                lblAnswer.Visibility = Visibility.Hidden;
                lblTimer.Content = "Time: 0s";
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
        /// Returns the user to the main menu, can start a new game, change the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Reset variables
                iNumberCorrect = 0;
                iNumberIncorrect = 0;
                iCurrentGameQuestion = 1;
                iSeconds = 0;

                // Reset UI elements
                ResetUI();

                // Close the current game window
                this.Hide();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
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

    }
}
