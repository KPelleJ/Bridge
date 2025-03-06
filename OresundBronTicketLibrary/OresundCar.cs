using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundBronTicketLibrary
{
    /// <summary>
    /// Car object specificly related to the Oresund ticketing system. Inherits from Vehicle super class.
    /// Main difference is the base price and discounted price with brobizz.
    /// </summary>
    public class OresundCar : Vehicle
    {
        public OresundCar(string licenseplate, DateTime date, bool brobizz):base(licenseplate, date, 460, brobizz)
        {
        }

        public override double Price()
        {
            return Brobizz ? 178 : base.Price();
        }

        public override string VehicleType()
        {
            return "Oresund Car";
        }
    }
}
