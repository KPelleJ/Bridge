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
    public class Car
    {
        private string _licensePlate;

        public DateTime Date { get; set; }

        /// <summary>
        /// The cars identifier. Checks whether the license plate only contains numbers and alphabetic characters.
        /// </summary>
        public string LicensePlate
        {
            get => _licensePlate; 
            set => _licensePlate = Regex.IsMatch(value, @"^[a-zA-Z0-9]+$") ? value: 
                                   throw new ArgumentException("The license plate can only contain letters and numbers");
        }

        public Car(string licensePlate, DateTime date)
        {
            LicensePlate = licensePlate;
            Date = date;
        }

        /// <summary>
        /// Determines the ticket price for the car
        /// </summary>
        /// <returns>The determined price</returns>
        public double Price()
        {
            return 230;
        }

        /// <summary>
        /// Determines the type of the vehicle for the ticket.
        /// </summary>
        /// <returns>The determined vehicle type</returns>
        public string VehicleType()
        {
            return "Car";
        }
    }
}
