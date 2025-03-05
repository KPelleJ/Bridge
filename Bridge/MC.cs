using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// MC sub class that inherits from the Vehicle base class. Base ticket price of car is 120
    /// </summary>
    public class MC:Vehicle
    {

        public MC(string licensePlate, DateTime date):base(licensePlate, date, 120)
        {
        }

        public override string VehicleType()
        {
            return "MC";
        }
    }
}
