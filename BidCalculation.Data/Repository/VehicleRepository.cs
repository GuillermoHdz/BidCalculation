using BidCalculation.Common.Models;
using Dapper;

namespace BidCalculation.Data.Repository
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAsync();
        Task<IEnumerable<VehicleType>> GetTypesAsync();
    }

    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDatabaseDataContext _dataContext;

        public VehicleRepository(IDatabaseDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            using var connection = _dataContext.CreateConnection();
            var sql = "SELECT id, vehicle_price, vehicle_type FROM dbo.Vehicles";
            return await connection.QueryAsync<Vehicle>(sql);
        }

        public async Task<IEnumerable<VehicleType>> GetTypesAsync()
        {
            using var connection = _dataContext.CreateConnection();
            var sql = "SELECT id, type FROM dbo.VehicleTypes";
            return await connection.QueryAsync<VehicleType>(sql);
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            using var connection = _dataContext.CreateConnection();
            var sql = "INSERT INTO Vehicles (vehicle_price, vehicle_type) VALUES(@vehicle_price, @vehicle_type)";
            await connection.ExecuteAsync(sql, vehicle);
        }
    }
}
