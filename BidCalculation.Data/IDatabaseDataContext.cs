using System.Data;

namespace BidCalculation.Data
{
    public interface IDatabaseDataContext
    {
        IDbConnection CreateConnection();
    }
}
