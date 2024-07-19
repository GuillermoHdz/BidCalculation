using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCalculation.Business.Factories
{
    public class LuxuryBidCalculation : BaseBidCalculation
    {
        public LuxuryBidCalculation(decimal vehicle_Price, int id) : base(vehicle_Price, id, "Luxury", 25, 200, 4) { }
    }
}
