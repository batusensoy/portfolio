using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class clsPassengerManager
    {
        /// <summary>
        /// GetPassengers(string sFlightID)
        /// </summary>
        /// <param name="sFlightID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<clsPassenger> GetPassengers(string sFlightID)
        {
            try
            {
                List<clsPassenger> passengers = new List<clsPassenger>(); // Create a list to store passengers
                string sSQL = clsSQL.GetPassengers(sFlightID); // Retrieve SQL query to get passengers for the given flight ID

                // Execute SQL statement and get DataSet
                int rowCount = 0;
                DataSet ds = new clsDataAccess().ExecuteSQLStatement(sSQL, ref rowCount);

                // Loop through the DataTable using a for loop and create clsPassenger objects
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    clsPassenger passenger = new clsPassenger();
                    passenger.PassengerID = row["Passenger_ID"].ToString();
                    passenger.FirstName = row["First_Name"].ToString();
                    passenger.LastName = row["Last_Name"].ToString();
                    passenger.SeatNumber = row["Seat_Number"].ToString();

                    // Add the passenger to the list
                    passengers.Add(passenger);
                }

                return passengers; // Return the list of passengers
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Update Seat Number
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="newSeatNumber"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateSeatNumber(string flightID, string passengerID, string newSeatNumber)
        {
            try
            {
                string sSQL = clsSQL.UpdateSeatNumber(flightID, passengerID, newSeatNumber);
                int rowCount = 0; // Initialize rowCount
                new clsDataAccess().ExecuteNonQuery(sSQL, ref rowCount); // Pass rowCount
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Insert Passenger
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <exception cref="Exception"></exception>
        public static void InsertPassenger(string firstName, string lastName)
        {
            try
            {
                string sSQL = clsSQL.InsertPassenger(firstName, lastName);
                int rowCount = 0; // Initialize rowCount
                new clsDataAccess().ExecuteNonQuery(sSQL, ref rowCount); // Pass rowCount
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Insert Flight Passenger Link
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="seatNumber"></param>
        /// <exception cref="Exception"></exception>
        public static void InsertFlightPassengerLink(string flightID, string passengerID, string seatNumber)
        {
            try
            {
                string sSQL = clsSQL.InsertFlightPassengerLink(flightID, passengerID, seatNumber);
                int rowCount = 0; // Initialize rowCount
                new clsDataAccess().ExecuteNonQuery(sSQL, ref rowCount); // Pass rowCount
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Passenger
        /// </summary>
        /// <param name="passengerID"></param>
        /// <exception cref="Exception"></exception>
        public static void DeletePassenger(string passengerID)
        {
            try
            {
                string sSQL = clsSQL.DeletePassenger(passengerID);
                int rowCount = 0; // Initialize rowCount
                new clsDataAccess().ExecuteNonQuery(sSQL, ref rowCount); // Pass rowCount
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Flight Passenger Link
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteFlightPassengerLink(string flightID, string passengerID)
        {
            try
            {
                string sSQL = clsSQL.DeleteFlightPassengerLink(flightID, passengerID);
                int rowCount = 0; // Initialize rowCount
                new clsDataAccess().ExecuteNonQuery(sSQL, ref rowCount); // Pass rowCount
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get PassengerID
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetPassengerID(string firstName, string lastName)
        {
            try
            {
                string sSQL = clsSQL.GetPassengerID(firstName, lastName);
                int rowCount = 0; // Initialize rowCount
                DataSet ds = new clsDataAccess().ExecuteSQLStatement(sSQL, ref rowCount); // Pass rowCount

                if (rowCount > 0)
                {
                    return ds.Tables[0].Rows[0]["Passenger_ID"].ToString();
                }
                else
                {
                    throw new Exception("Passenger not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }




    }
}
