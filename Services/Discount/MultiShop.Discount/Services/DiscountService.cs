using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using System.Data;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
    {
        string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@code", createDiscountCouponDto.Code);
        parameters.Add("@rate", createDiscountCouponDto.Rate);
        parameters.Add("@isActive", createDiscountCouponDto.IsActive);
        parameters.Add("@validDate", createDiscountCouponDto.ValidDate);

        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = "delete from Coupons where Id=@id";
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", id);

        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }

    }

    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = "Select * from Coupons";

        using(IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultDiscountCouponDto> values = await connection.QueryAsync<ResultDiscountCouponDto>(query);

            return values.ToList();
        }
    }

    public async Task<ResultDiscountCouponDto> GetByCodeDiscountCouponAsync(string code)
    {
        string query = "Select * from Coupons Where Code = @code";
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@code", code);

        using (IDbConnection connection = _context.CreateConnection())
        {
            ResultDiscountCouponDto value = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);

            return value;
        }
    }

    public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
    {
        string query = "Select * from Coupons where Id=@id";
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", id);

        using(IDbConnection connection = _context.CreateConnection())
        {
            GetByIdDiscountCouponDto value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);

            return value;
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
    {
        string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where Id=@id";
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", updateCouponDto.Id);
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);

        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
