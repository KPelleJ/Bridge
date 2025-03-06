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

        public MC(string licensePlate, DateTime date, bool brobizz):base(licensePlate, date, 120, brobizz)
        {
        }

        /// <summary>
        /// The abstract method VehicleType is overridden to return "MC" as the correct type of the MC sub class.
        /// </summary>
        /// <returns>The MC type as a string</returns>
        public override string VehicleType()
        {
            return "MC";
        }
    }
}
