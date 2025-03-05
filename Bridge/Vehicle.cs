using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// Vehicle object to store data of the vehicles license plate and the date of the bridge passing
    /// </summary>
    public abstract class Vehicle
    {
        private string _licensePlate;

        public DateTime Date { get; set; }

        /// <summary>
        /// The vehicles identifier. Checks whether the license plate only contains numbers and alphabetic characters.
        /// </summary>
        public string LicensePlate
        {
            get => _licensePlate;
            set => _licensePlate = value.Length <= 7 && Regex.IsMatch(value, @"^[a-zA-Z0-9]+$") ? value :
                                   throw new ArgumentException("The license plate can only contain letters and numbers and must not be longer than 7 characters");
        }

        public Vehicle(string licensePlate, DateTime date)
        {
            LicensePlate = licensePlate;
            Date = date;
        }

        public abstract double Price();

        public abstract string VehicleType();
    }
}
