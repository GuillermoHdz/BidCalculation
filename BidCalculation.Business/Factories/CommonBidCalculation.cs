using BidCalculation.Common.Models;

namespace BidCalculation.Business.Factories
{
    public class CommonBidCalculation : BaseBidCalculation
    {
        public CommonBidCalculation(decimal vehicle_Price, int id) : base(vehicle_Price, id, "Common", 10, 50, 2) { }
    }
}
