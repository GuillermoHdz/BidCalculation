using BidCalculation.Common.Models;

namespace BidCalculation.Business.Factories
{
    public class BaseBidCalculation
    {
        private int _id;
        private decimal _minimum { get; set; }
        private decimal _maximum { get; set; }
        private int _special_Fee { get; set; }

        private decimal _vehicle_Price { get; set; }
        private string _vehicle_Type { get; set; }
        private decimal _storage { get { return 100; } }
        private decimal _basic
        {
            get
            {
                var basic = _vehicle_Price * 0.1m;
                return basic < _minimum ? _minimum : basic > _maximum ? _maximum : basic;
            }
        }
        private decimal _special { get { return _vehicle_Price * (_special_Fee/100m); } }
        private decimal _association
        {
            get
            {
                switch (_vehicle_Price)
                {
                    case decimal p when p < 500:
                        return 5;
                    case decimal p when p < 1000:
                        return 10;
                    case decimal p when p < 3000:
                        return 15;
                    default:
                        return 20;
                }
            }
        }

        protected BaseBidCalculation(decimal vehicle_Price, int id, string vehicle_Type, decimal minimum, decimal maximum, int special_Fee)
        {
            _id = id;
            _vehicle_Price = vehicle_Price;
            _vehicle_Type = vehicle_Type;
            _minimum = minimum;
            _maximum = maximum;
            _special_Fee = special_Fee;
        }

        public VehicleCalculation GetCalculation()
        {
            return new VehicleCalculation
            {
                Id = _id,
                Vehicle_Price = _vehicle_Price,
                Vehicle_Type = _vehicle_Type,
                Basic = _basic,
                Special = _special,
                Association = _association,
                Storage = _storage,
                Total = _vehicle_Price + _basic + _special + _association + _storage
            };
        }
    }
}
