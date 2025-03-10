using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsDataAccess clsData;
        /// <summary>
        /// Placeholder for wndAddPassenger
        /// </summary>
        wndAddPassenger wndAddPassenger;

        /// <summary>
        /// Placeholder for FlightManager
        /// </summary>
        clsFlightManager clsFlightManager;

        /// <summary>
        /// Placeholder for PassengerManager
        /// </summary>
        clsPassengerManager clsPassengerManager;


        /// <summary>
        /// Modes
        /// </summary>
        bool bAddPassengerMode;
        bool bChangeSeatMode;

        // shade of green that was used in color key
        private const string GREEN_COLOR_HEX = "#FF00FD00";
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                //**
                clsFlightManager = new clsFlightManager(); // Initialize clsFlightManager
                clsPassengerManager = new clsPassengerManager(); // Initialize clsPassengerManager
                cbChooseFlight.ItemsSource = clsFlightManager.GetFlights();


            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Choose Flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsFlight clsSelectedFlight = (clsFlight)cbChooseFlight.SelectedItem;
                List<clsPassenger> passengers = clsPassengerManager.GetPassengers(clsSelectedFlight.FlightID);
                cbChoosePassenger.ItemsSource = passengers;
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;
                lblPassengersSeatNumber.Content = "";

                // Determine which canvas to show based on the selected flightID
                //Flight ID = 1 display flight else display the other one
                if (clsSelectedFlight.FlightID == "1")
                {
                    CanvasA380.Visibility = Visibility.Visible;
                    Canvas767.Visibility = Visibility.Collapsed;
                }
                else if (clsSelectedFlight.FlightID == "2")
                {
                    CanvasA380.Visibility = Visibility.Collapsed;
                    Canvas767.Visibility = Visibility.Visible;
                }

                //FillPassengerSeats
                FillPassengerSeats(passengers);

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Choose Passenger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsFlight clsSelectedFlight = (clsFlight)cbChooseFlight.SelectedItem;
                List<clsPassenger> passengers = clsPassengerManager.GetPassengers(clsSelectedFlight.FlightID);
                
                FillPassengerSeats(passengers);
                
                if (cbChoosePassenger.SelectedItem != null)
                {
                    clsPassenger selectedPassenger = (clsPassenger)cbChoosePassenger.SelectedItem;
                    string selectedSeatNumber = selectedPassenger.SeatNumber;
                    HighlightSelectedPassengerSeat(selectedSeatNumber);
                    
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
        /// Highlight Selected Passenger Seat
        /// </summary>
        /// <param name="selectedSeatNumber"></param>
        /// <exception cref="Exception"></exception>
        private void HighlightSelectedPassengerSeat(string selectedSeatNumber)
        {
            try
            {
                // shade of green that was used in color key
                SolidColorBrush greenBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(GREEN_COLOR_HEX));

                foreach (var seat in c767_Seats.Children)
                {
                    if (seat is Label label && label.Content != null && label.Content.ToString() == selectedSeatNumber)
                    {
                        label.Background = greenBrush;
                        lblPassengersSeatNumber.Content = selectedSeatNumber;
                        break;
                    }
                }

                foreach (var seat in cA380_Seats.Children)
                {
                    if (seat is Label label && label.Content != null && label.Content.ToString() == selectedSeatNumber)
                    {
                        label.Background = greenBrush;
                        lblPassengersSeatNumber.Content = selectedSeatNumber;
                        break;
                    }
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
        /// Fill Passenger Seats
        /// </summary>
        /// <param name="passengers"></param>
        private void FillPassengerSeats(List<clsPassenger> passengers)
        {
            try
            {
                // Reset all seats to blue

                // Reset seats in c767_Seats canvas
                foreach (var seat in c767_Seats.Children)
                {
                    if (seat is Label label)
                    {
                        label.Background = Brushes.Blue;
                    }
                }

                // Reset seats in cA380_Seats canvas
                foreach (var seat in cA380_Seats.Children)
                {
                    if (seat is Label label)
                    {
                        label.Background = Brushes.Blue;
                    }
                }

                // Loop through each passenger and mark their seat with appropriate color
                foreach (var passenger in passengers)
                {
                    string seatNumber = passenger.SeatNumber;

                    // Check if the seat belongs to c767_Seats
                    foreach (var seat in c767_Seats.Children)
                    {
                        if (seat is Label label && label.Content != null && label.Content.ToString() == seatNumber)
                        {
                            // Set background color to red indicating a taken seat
                            label.Background = Brushes.Red;
                            break; 
                        }
                    }

                    // Check if the seat belongs to cA380_Seats
                    foreach (var seat in cA380_Seats.Children)
                    {
                        if (seat is Label label && label.Content != null && label.Content.ToString() == seatNumber)
                        {
                            // Set background color to red indicating a taken seat
                            label.Background = Brushes.Red;
                            break; 
                        }
                    }
                }

               
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Add Passenger button, opens the form to get passenger info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPassenger = new wndAddPassenger();
                wndAddPassenger.ShowDialog();

                if (wndAddPassenger.SaveClicked)
                {
                    gPassengerCommands.IsEnabled = false;
                    gbPassengerInformation.IsEnabled = false;
                    bAddPassengerMode = true;
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Delete Passenger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedItem != null)
                {
                    // Prompt the user with a message box to confirm deletion
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the passenger?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    // Check the user's response
                    if (result == MessageBoxResult.Yes)
                    {
                        // User confirmed deletion
                        clsPassenger selectedPassenger = (clsPassenger)cbChoosePassenger.SelectedItem;
                        clsFlight selectedFlight = (clsFlight)cbChooseFlight.SelectedItem;
                        clsPassengerManager.DeleteFlightPassengerLink(selectedFlight.FlightID, selectedPassenger.PassengerID);
                        clsPassengerManager.DeletePassenger(selectedPassenger.PassengerID);

                        RefreshPassengersList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a passenger first.");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Change the seat of the passenger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedItem != null)
                {
                    gPassengerCommands.IsEnabled = false;
                    gbPassengerInformation.IsEnabled = false;

                    bChangeSeatMode = true;
                }
                else
                {
                    MessageBox.Show("Please select a passenger first.");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }



        /// <summary>
        /// This method will get called when user clicks any seat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Seat_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label clickedSeat = (Label)sender;
                string seatNumber = clickedSeat.Content.ToString();

                if (bAddPassengerMode)
                {
                    clsFlight selectedFlight = (clsFlight)cbChooseFlight.SelectedItem;

                    // Check if the user has clicked "Save" in wndAddPassenger
                    if (wndAddPassenger.SaveClicked == true)
                    {
                        // Access the first name and last name properties from wndAddPassenger
                        string firstName = wndAddPassenger.FirstName;
                        string lastName = wndAddPassenger.LastName;

                        // Insert the new passenger into the database
                        clsPassengerManager.InsertPassenger(firstName, lastName);

                        // Get the newly created passenger's ID
                        string passengerID = clsPassengerManager.GetPassengerID(firstName, lastName);

                        // Insert a record into the link table with the flight ID, passenger ID, and selected seat number
                        clsPassengerManager.InsertFlightPassengerLink(selectedFlight.FlightID, passengerID, seatNumber);

                        // Exit add passenger mode and refresh the passengers list
                        ExitAddPassengerMode();
                        RefreshPassengersList();
                    }
                }
                else if (bChangeSeatMode)
                {
                    if (clickedSeat.Background == Brushes.Blue)
                    {
                        clsPassenger selectedPassenger = (clsPassenger)cbChoosePassenger.SelectedItem;
                        clsFlight selectedFlight = (clsFlight)cbChooseFlight.SelectedItem;
                        clsPassengerManager.UpdateSeatNumber(selectedFlight.FlightID, selectedPassenger.PassengerID, seatNumber);
                        ExitChangeSeatMode();
                        RefreshPassengersList();
                    }
                    else
                    {
                        MessageBox.Show("Seat is already taken.");
                    }
                }
                else
                {
                    if (clickedSeat.Background == Brushes.Red)
                    {
                        foreach (clsPassenger passenger in cbChoosePassenger.Items)
                        {
                            if (passenger.SeatNumber == seatNumber)
                            {
                                cbChoosePassenger.SelectedItem = passenger;
                                lblPassengersSeatNumber.Content = passenger.SeatNumber;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Exit AddPassenger mode
        /// </summary>
        private void ExitAddPassengerMode()
        {
            try
            {
                // Reset UI elements and variables after adding a passenger
                gPassengerCommands.IsEnabled = true;
                gbPassengerInformation.IsEnabled = true;
                bAddPassengerMode = false;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Exit ChangeSeat mode
        /// </summary>
        private void ExitChangeSeatMode()
        {
            try
            {
                // Reset UI elements and variables after changing a seat
                gPassengerCommands.IsEnabled = true;
                gbPassengerInformation.IsEnabled = true;
                bChangeSeatMode = false;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Refresh Passenger List
        /// </summary>
        private void RefreshPassengersList()
        {
            try
            {
                // Get the selected flight
                clsFlight selectedFlight = (clsFlight)cbChooseFlight.SelectedItem;

                // Retrieve the updated list of passengers for the selected flight from the database
                List<clsPassenger> passengers = clsPassengerManager.GetPassengers(selectedFlight.FlightID);

                // Update the combo box with the refreshed list of passengers
                cbChoosePassenger.ItemsSource = passengers;

                // Fill the passenger seats based on the updated list
                FillPassengerSeats(passengers);

                //Clear Passenger's seat label
                lblPassengersSeatNumber.Content = "";
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
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
