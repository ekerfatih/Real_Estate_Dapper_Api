using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository {
    public class Last5ProductRepository : ILast5ProductRepository {
        private Context _context;

        public Last5ProductRepository(Context context) {
            _context = context;
        }

        public async Task<List<ResultLast5RentProductWithCategoryDto>> GetLast5RentedProduct(int id) {
            string query = @"SELECT top 5
                Product.ProductId,
                Product.Title,
                Product.Price,
                Product.City,
                Product.District,
                Product.ProductCategory,
                Category.CategoryName,
                Product.AdvertisementDate
                FROM Product
                INNER JOIN Category ON Category.CategoryID = Product.ProductCategory
                where AppUserId = @employeeId
                order by ProductId desc";
            DynamicParameters parameters = new();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultLast5RentProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
