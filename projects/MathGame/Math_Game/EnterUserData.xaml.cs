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

namespace Math_Game
{
    /// <summary>
    /// Interaction logic for EnterUserData.xaml
    /// </summary>
    public partial class EnterUserData : Window
    {
        // Create a new instance of the SoundPlayer class and provide the path to the .wav file
        SoundPlayer mainGameSound = new SoundPlayer("PinkPantheress - Another life (feat. Rema) - Instrumental.wav");

        public EnterUserData()
        {
            InitializeComponent();
            mainGameSound.PlayLooping();
        }

        /// <summary>
        /// Button to close the user data form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cmdCloseUserDataForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide user data form
                this.Hide();
                lblUserAge.Content = string.Empty;
                lblUserName.Content = string.Empty;
                lblUserData.Content = string.Empty;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Close window
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
        /// Enter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                lblUserAge.Content = string.Empty;
                lblUserName.Content = string.Empty;
                lblUserData.Content = string.Empty;

                // Validate and store user data
                if (ValidateUserData())
                {
                    // Store name and age using the User class
                    clsUser.Name = txtName.Text.Trim();
                    clsUser.Age = int.Parse(txtAge.Text);

                    lblUserData.Visibility = Visibility.Visible;
                    lblUserData.Content = "User data has been stored successfully";
                    this.Hide();
                }

                txtAge.Text = string.Empty;
                txtName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Validates user data
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool ValidateUserData()
        {
            try
            {
                // Simple validation, ensuring name is not empty and does not contain integers
                if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Any(char.IsDigit))
                {
                    lblUserName.Visibility = Visibility.Visible;
                    lblUserName.Content = "Please enter a valid name.";
                    return false;
                }

                // Validate User's age
                if (!int.TryParse(txtAge.Text, out int age) || age < 3 || age > 10)
                {
                    lblUserAge.Visibility = Visibility.Visible;
                    lblUserAge.Content = "Please enter a valid age between 3 and 10";
                    return false;
                }

                return true;
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
