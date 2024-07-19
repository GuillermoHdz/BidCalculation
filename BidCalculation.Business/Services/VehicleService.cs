using BidCalculation.Business.Factories;
using BidCalculation.Common.Models;
using BidCalculation.Data.Repository;

namespace BidCalculation.Business.Services
{
    public interface IVehicleService
    {
        Task<VehicleCalculation> AddVehicleAsync(Vehicle vehicle);
        Task<IEnumerable<VehicleCalculation>> GetVehiclesAsync();
        Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();
    }

    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICalculationFactory _calculationFactory;

        public VehicleService(IVehicleRepository vehicleRepository, ICalculationFactory calculationFactory)
        {
            _vehicleRepository = vehicleRepository;
            _calculationFactory = calculationFactory;
        }

        public async Task<VehicleCalculation> AddVehicleAsync(Vehicle vehicle) 
        {
            if (vehicle != null)
            {
                await _vehicleRepository.AddAsync(vehicle);
                var bidCalculation = _calculationFactory.Build(vehicle);
                return bidCalculation.GetCalculation();
            }

            return null;
        }

        public async Task<IEnumerable<VehicleCalculation>> GetVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAsync();
            var _vehicles = new List<VehicleCalculation>();
            foreach(var vehicle in vehicles)
            {
                var bidCalculation = _calculationFactory.Build(vehicle);
                _vehicles.Add(bidCalculation.GetCalculation());
            }

            return _vehicles;
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        {
            return await _vehicleRepository.GetTypesAsync();
        }
    }
}
