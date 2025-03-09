using System.Media;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Math_Game.clsGame;

namespace Math_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Class that holds the high scores.
        /// </summary>
        HighScores wndHighScoresForm;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
        EnterUserData wndEnterUserDataForm;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        Game wndGameForm;

        // Create a new instance of the SoundPlayer class and provide the path to the .wav file
        SoundPlayer mainGameSound = new SoundPlayer("PinkPantheress - Another life (feat. Rema) - Instrumental.wav");

        public MainWindow()
        {
            InitializeComponent();
            //MAKE SURE TO INCLUDE THIS LINE OR THE APPLICATION WILL NOT CLOSE
            //BECAUSE THE WINDOWS ARE STILL IN MEMORY
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            wndHighScoresForm = new HighScores();
            wndEnterUserDataForm = new EnterUserData();
            wndGameForm = new Game();

            mainGameSound.PlayLooping();


            //Pass the high scores form to the game form.  This way the high scores form may be displayed via the game form.
            wndGameForm.CopyHighScores = wndHighScoresForm;

            // Initially, disable the Play Game button until the user enters their data
            cmdPlayGame.IsEnabled = false;
        }

        /// <summary>
        /// Play game button to take user to the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdPlayGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblGameType.Content = string.Empty;
                lblUserDataInvalid.Content = string.Empty;

                // Validate User's name and age
                // Set user's data info using the static variable in the class clsUser
                if (string.IsNullOrEmpty(clsUser.Name) || clsUser.Age < 3 || clsUser.Age > 10)
                {
                    lblUserDataInvalid.Visibility = Visibility.Visible;
                    lblUserDataInvalid.Content = "Please enter a valid name and age.";
                    return;
                }

                // Validate that a game is selected
                if (!(rbAddition.IsChecked == true || rbSubtraction.IsChecked == true || rbMultiplication.IsChecked == true || rbDivision.IsChecked == true))
                {
                    lblGameType.Visibility = Visibility.Visible;
                    lblGameType.Content = "Please select a game type. ";
                    return;
                }
               
                // Set game type using the static variable in the class clsGame
                if (rbAddition.IsChecked == true)
                    clsGame.CurrentGameType = GameType.Add;
                else if (rbSubtraction.IsChecked == true)
                    clsGame.CurrentGameType = GameType.Subtract;
                else if (rbMultiplication.IsChecked == true)
                    clsGame.CurrentGameType = GameType.Mult;
                else if (rbDivision.IsChecked == true)
                    clsGame.CurrentGameType = GameType.Divide;

                // If valid, show the game window
                wndGameForm.ShowDialog();

                // Disable the Play Game button when a new game starts
                cmdPlayGame.IsEnabled = false;

                //Hide the menu
                this.Hide();
                //Show the game form
                wndGameForm.ShowDialog();
                //Show the main form
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
        /// High scores button that takes the user to the high scores window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                //Hide the menu
                this.Hide();
                //Show the high scores screen
                wndHighScoresForm.ShowDialog();
                //Show the main form
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
        /// Enables user to enter their name and age
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdEnterUserData_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                //Hide the menu
                this.Hide();
                //Show the user data form
                wndEnterUserDataForm.ShowDialog();
                //Show the main form
                this.Show();

                // Enable the Play Game button when the user enters their data
                cmdPlayGame.IsEnabled = true;
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

    }
}