using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _StoreBaeltTicketLibrary_
{
    /// <summary>
    /// Car class specific to the Storebaelt ticket system. Inherits from the Car (Vehicle) superclass. Main difference
    /// is an added weekend discount that is calculated in the price.
    /// </summary>
    public class StorebaeltCar : Car
    {
        public StorebaeltCar(string licensePlate, DateTime date, bool brobizz) : base(licensePlate, date, brobizz)
        {
        }

        /// <summary>
        /// Added logic to handle whether or not the price is to be given a weekend discount if the day is
        /// saturday or sunday.
        /// </summary>
        /// <returns>The price after discount parameters are considered</returns>
        public override double Price()
        {
            double outputPrice = _basePrice;

            if(Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                outputPrice *= 0.85;
            }

            if(Brobizz)
            {
                outputPrice *= 0.9;
            }

            return outputPrice;
        }
    }
}
