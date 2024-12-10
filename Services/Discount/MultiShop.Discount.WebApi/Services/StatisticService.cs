
using Dapper;
using MultiShop.Discount.WebApi.Context;
using System.Data;

namespace MultiShop.Discount.WebApi.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly DapperContext _context;

        public StatisticService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";

            using (IDbConnection connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);

                return value;
            }
        }
    }
}
