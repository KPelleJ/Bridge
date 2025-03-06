using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundBronTicketLibrary
{
    /// <summary>
    /// MC object specificly related to the Oresund ticketing system. Inherits from Vehicle super class.
    /// Main difference is the base price and discounted price with brobizz.
    /// </summary>
    public class OresundMC : Vehicle
    {
        public OresundMC(string licensePlate, DateTime date, bool brobizz) : base(licensePlate, date, 235, brobizz)
        {
        }

        public override double Price()
        {
            return Brobizz ? 92 : base.Price();
        }

        public override string VehicleType()
        {
            return "Oresund MC";
        }
    }
}
