using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class clsSQL
    {
        /// <summary>
        /// GetFlights() SQL
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetFlights()
        {
            try
            {
                string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetPassengers() SQL
        /// </summary>
        /// <param name="sFlightID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetPassengers(string sFlightID)
        {
            try
            {
                string sSQL = "SELECT Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number " +
                              "FROM Passenger, Flight_Passenger_Link FPL " +
                              "WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND " +
                              "Flight_ID = " + sFlightID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// UpdateSeatNumber() SQL
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="newSeatNumber"></param>
        /// <returns></returns>
        public static string UpdateSeatNumber(string flightID, string passengerID, string newSeatNumber)
        {
            try
            {
                string sSQL = "UPDATE FLIGHT_PASSENGER_LINK " +
                              "SET Seat_Number = '" + newSeatNumber + "' " +
                              "WHERE FLIGHT_ID = " + flightID + " AND PASSENGER_ID = " + passengerID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// InsertPassenger() SQL
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string InsertPassenger(string firstName, string lastName)
        {
            try
            {
                string sSQL = "INSERT INTO PASSENGER(First_Name, Last_Name) VALUES('" + firstName + "', '" + lastName + "')";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// InsertFlightPassengerLink() SQL
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="seatNumber"></param>
        /// <returns></returns>
        public static string InsertFlightPassengerLink(string flightID, string passengerID, string seatNumber)
        {
            try
            {
                string sSQL = "INSERT INTO Flight_Passenger_Link(Flight_ID, Passenger_ID, Seat_Number) " +
                              "VALUES(" + flightID + ", " + passengerID + ", '" + seatNumber + "')";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// DeleteFlightPassengerLink() SQL
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <returns></returns>
        public static string DeleteFlightPassengerLink(string flightID, string passengerID)
        {
            try
            {
                string sSQL = "DELETE FROM FLIGHT_PASSENGER_LINK " +
                              "WHERE FLIGHT_ID = " + flightID + " AND PASSENGER_ID = " + passengerID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// DeletePassenger() SQL
        /// </summary>
        /// <param name="passengerID"></param>
        /// <returns></returns>
        public static string DeletePassenger(string passengerID)
        {
            try
            {
                string sSQL = "DELETE FROM PASSENGER WHERE PASSENGER_ID = " + passengerID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// GetPassengerID() SQL
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string GetPassengerID(string firstName, string lastName)
        {
            try
            {
                string sSQL = "SELECT Passenger_ID FROM PASSENGER WHERE First_Name = '" + firstName + "' AND Last_Name = '" + lastName + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
