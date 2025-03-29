using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class clsFlight
    {
        /// <summary>
        /// Holds FlightID
        /// </summary>
        public string FlightID { get; set; }

        /// <summary>
        /// Holds Flight number
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// Holds Aircraft type
        /// </summary>
        public string AircraftType { get; set; }

        /// <summary>
        /// Override the ToString method because this is what is displayed in the combo box when bound to it.
        /// </summary>
        /// <returns>String to display</returns>
        public override string ToString()
        {
            try
            {
                return FlightNumber + " " + AircraftType;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
