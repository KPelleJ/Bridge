using Bridge;

namespace _StoreBaeltTicketLibrary_
{
    /// <summary>
    /// Interface to be used for Vehicle ticket repositories
    /// </summary>
    public interface ITicketRepository
    {
        /// <summary>
        /// Adds a vehicle to the desired data source
        /// </summary>
        /// <param name="vehicleTicket">The vehicle to be added</param>
        /// <returns>The Vehicle that was added</returns>
        Vehicle Add(Vehicle vehicleTicket);
        /// <summary>
        /// Retrieves all data concerning all the Vehicle objects from the data source
        /// </summary>
        /// <returns>All Vehicles</returns>
        List<Vehicle> GetAll();
        /// <summary>
        /// Retrieves all tickets relating to a Vehicle with the given Licenseplate
        /// </summary>
        /// <param name="licensePlate">License plate of the Vehicle from which you want to retrieve tickets for</param>
        /// <returns>All Vehicle tickets related to the corresponding licenseplate</returns>
        List<Vehicle> GetByLicensePlate(string licensePlate);
    }
}