using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _StoreBaeltTicketLibrary_
{
    public class StorebaeltTicketRepository : ITicketRepository
    {
        public static List<Vehicle> _tickets;

        public StorebaeltTicketRepository()
        {
            _tickets = new();

            _tickets.Add(new StorebaeltCar("AQZ4821", DateTime.Now, true));
            _tickets.Add(new StorebaeltCar("BRB4206", DateTime.Now, false));
            _tickets.Add(new StorebaeltCar("CR67222", DateTime.Now, true));
            _tickets.Add(new StorebaeltCar("CR67222", DateTime.Now, true));
            _tickets.Add(new StorebaeltCar("CR67222", DateTime.Now, true));
            _tickets.Add(new StorebaeltCar("KMS7623", DateTime.Now, false));
            _tickets.Add(new MC("BBPP221", DateTime.Now, true));
            _tickets.Add(new MC("WA21312", DateTime.Now, true));
            _tickets.Add(new MC("WA21312", DateTime.Now, false));
            _tickets.Add(new MC("GGKMS29", DateTime.Now, false));
        }

        public Vehicle Add(Vehicle vehicleTicket)
        {
            _tickets.Add(vehicleTicket);
            return vehicleTicket;
        }

        public List<Vehicle> GetAll()
        {
            return _tickets;
        }

        public List<Vehicle> GetByLicensePlate(string licensePlate)
        {
            var outputTickets = _tickets.FindAll(v => v.LicensePlate.Equals(licensePlate));
            return outputTickets;
        }
    }
}
