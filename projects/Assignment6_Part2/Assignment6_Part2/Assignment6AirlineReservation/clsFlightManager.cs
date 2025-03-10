using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class clsFlightManager
    {
        /// <summary>
        /// List of flights
        /// </summary>
        List<clsFlight> flights = new List<clsFlight>();

        /// <summary>
        /// Get Flights
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<clsFlight> GetFlights()
        {
            try
            {
                List<clsFlight> flights = new List<clsFlight>(); //Create a list of items
                string sSQL;                                    //Holds the SQL statement to get the items

                // Retrieve flights from the  database
                sSQL = clsSQL.GetFlights();

                // Execute SQL statement and get DataSet
                int rowCount = 0;
                DataSet ds = new clsDataAccess().ExecuteSQLStatement(sSQL, ref rowCount);


                // Loop through the DataTable and create clsFlight objects using a for loop
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    clsFlight flight = new clsFlight();
                    flight.FlightID = row["Flight_ID"].ToString();
                    flight.FlightNumber = row["Flight_Number"].ToString();
                    flight.AircraftType = row["Aircraft_Type"].ToString();

                    // Add List of Flights
                    flights.Add(flight);
                }

                return flights;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
