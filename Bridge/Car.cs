using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bridge
{
    public class Car:Vehicle
    {
        public Car(string licensePlate, DateTime date):base(licensePlate, date, 230)
        {
        }

        public override string VehicleType()
        {
            return "Car";
        }
    }
}
