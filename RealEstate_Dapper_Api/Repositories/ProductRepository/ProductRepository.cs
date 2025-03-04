using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository {
    public class ProductRepository : IProductRepository {
        private readonly Context _context;

        public ProductRepository(Context context) {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProduct() {
            string query = "Select * from Product";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployee(int id) {
            string query =
                "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryId where EmployeeId = @employeeId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory() {
            string query =
                "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryId";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateDealOfTheDayStatus(int id) {
            string query =
                "UPDATE Product SET DealOfTheDay = CASE WHEN DealOfTheDay = 1 THEN 0 ELSE 1 END WHERE ProductID = @ProductId;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLast5RentProductWithCategoryDto>> GetLast5RentedProduct() {
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
                where type = 'Rent'
                order by ProductId desc";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultLast5RentProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
