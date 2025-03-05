using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OresundBronTicketLibrary
{
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
