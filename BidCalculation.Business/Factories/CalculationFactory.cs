using BidCalculation.Common.Models;

namespace BidCalculation.Business.Factories
{
    public interface ICalculationFactory
    {
        BaseBidCalculation Build(Vehicle vehicle);
    }

    public class CalculationFactory : ICalculationFactory
    {
        public BaseBidCalculation Build(Vehicle vehicle)
        {
            switch (vehicle.Vehicle_Type)
            {
                case 1:
                    return new CommonBidCalculation(vehicle.Vehicle_Price, vehicle.Id);
                case 2:
                    return new LuxuryBidCalculation(vehicle.Vehicle_Price, vehicle.Id);
                default:
                    throw new NotImplementedException("Invalid vehicle type");
            }
        }
    }
}
