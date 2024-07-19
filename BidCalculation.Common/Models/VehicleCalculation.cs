using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCalculation.Common.Models
{
    public class VehicleCalculation
    {
        public int Id { get; set; }
        public decimal Vehicle_Price { get; set; }
        public string Vehicle_Type { get; set; }
        public decimal Basic { get; set; }
        public decimal Special { get; set; }
        public decimal Association { get; set; }
        public decimal Storage { get; set; }
        public decimal Total { get; set; }
    }
}
