using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bridge
{
    public class MC
    {
        private string _licensePlate;

        public DateTime Date { get; set; }

        public string LicensePlate
        {
            get => _licensePlate;
            set => _licensePlate = Regex.IsMatch(value, @"^[a-zA-Z0-9]+$") ? value:
                                   throw new ArgumentException("The license plate can only contain letters and numbers");
        }

        public MC(string licensePlate, DateTime date)
        {
            LicensePlate = licensePlate;
            Date = date;
        }

        public double Price()
        {
            return 120;
        }

        public string VehicleType()
        {
            return "MC";
        }
    }
}
