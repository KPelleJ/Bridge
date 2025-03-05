using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// Represents a car that has a licenseplate as identifier and a Date for when it is registered in the ticket system.
    /// </summary>
    public class Car:Vehicle
    {
        public Car(string licensePlate, DateTime date):base(licensePlate, date)
        {
        }

        /// <summary>
        /// Determines the ticket price for the car
        /// </summary>
        /// <returns>The determined price</returns>
        public override double Price()
        {
            return 230;
        }

        /// <summary>
        /// Determines the type of the vehicle for the ticket.
        /// </summary>
        /// <returns>The determined vehicle type</returns>
        public override string VehicleType()
        {
            return "Car";
        }
    }
}
