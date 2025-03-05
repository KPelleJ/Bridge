using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _StoreBaeltTicketLibrary_
{
    public class StorebaeltCar : Car
    {
        public StorebaeltCar(string licensePlate, DateTime date) : base(licensePlate, date)
        {

        }

        public override double Price(bool brobizz)
        {
            double outputPrice = _basePrice;

            if(Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                outputPrice *= 0.85;
            }

            if(brobizz)
            {
                outputPrice *= 0.9;
            }

            return outputPrice;
        }
    }
}
