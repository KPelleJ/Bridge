using Bridge;

namespace _StoreBaeltTicketLibrary_
{
    public interface ITicketRepository
    {
        Vehicle Add(Vehicle vehicleTicket);
        List<Vehicle> GetAll();
        List<Vehicle> GetByLicensePlate(string licensePlate);
    }
}