using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class clsPassenger
    {
        /// <summary>
        /// Holds PassengerID
        /// </summary>
        public string PassengerID { get; set; }

        /// <summary>
        /// Holds Passenger First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Holds Passenger Last Name
        /// </summary>
        public string LastName { get; set; }

        public string SeatNumber { get; set; }

        /// <summary>
        /// override ToString()
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override string ToString()
        {
            try
            {
                return FirstName + " " + LastName;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
