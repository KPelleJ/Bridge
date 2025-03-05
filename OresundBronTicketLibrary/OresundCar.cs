using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundBronTicketLibrary
{
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
