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
        public StorebaeltCar(string licensePlate, DateTime date, bool brobizz) : base(licensePlate, date, brobizz)
        {
        }

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
