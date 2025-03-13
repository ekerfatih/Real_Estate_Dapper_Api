using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByTrue(int id) {
            string query =
                "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryId where EmployeeId = @employeeId and ProductStatus = 1";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByFalse(int id) {
            string query =
                "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryId where EmployeeId = @employeeId and ProductStatus = 0";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory() {
            string query =
                "Select ProductID,Title,Price,City,District,CategoryName,SlugUrl,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryId";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateDealOfTheDayStatus(int id) {
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

        public async Task CreateProduct(CreateProductDto createProductDto) {
            string query = @"Insert into Product (Title,Price,City,District,CoverImage,Address,Type,Description,AdvertisementDate,ProductStatus,DealOfTheDay,ProductCategory,EmployeeId)
            values (@title,@price,@city,@district,@coverImage,@address,@type,@description,@advertisementDate,@productStatus,@dealOfTheDay,@productCategory,@employeeId)";
            DynamicParameters parameters = new();
            parameters.Add("@title", createProductDto.Title);
            parameters.Add("@price", createProductDto.Price);
            parameters.Add("@city", createProductDto.City);
            parameters.Add("@district", createProductDto.District);
            parameters.Add("@coverImage", createProductDto.CoverImage);
            parameters.Add("@address", createProductDto.Address);
            parameters.Add("@type", createProductDto.Type);
            parameters.Add("@description", createProductDto.Description);
            parameters.Add("@advertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@productStatus", createProductDto.ProductStatus);
            parameters.Add("@dealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@productCategory", createProductDto.ProductCategory);
            parameters.Add("@employeeId", createProductDto.EmployeeId);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id) {
            string query =
                "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,SlugUrl,AppUserId,Address,DealOfTheDay,AdvertisementDate,Description from Product inner join Category on Product.ProductCategory = Category.CategoryId where ProductId = @productId";
            DynamicParameters parameters = new();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection()) {
                var value = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                return value.FirstOrDefault()!;
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id) {
            string query =
                "Select * from ProductDetails where ProductId = @productId";

            DynamicParameters parameters = new();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection()) {
                var value = await connection.QueryAsync<GetProductDetailByIdDto>(query,parameters);
                return value.FirstOrDefault()!;
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city) {
            string query =
                "Select * from Product where Title like @searchKeyValue and ProductCategory=@propertyCategoryId and City = @city";
            DynamicParameters parameters = new();
            parameters.Add("@searchKeyValue","%"+ searchKeyValue+"%" );
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection()) {
                var value = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return value.ToList()!;
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategory() {
            string query =
                @"Select
                    ProductID,
                    Title,
                    Price,
                    City,
                    District
                    ,CategoryName,
                    CoverImage,
                    Type,
                    Address,
                    DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryId where DealOfTheDay=1";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3RentProductWithCategoryDto>> GetLast3RentedProduct() {
            string query = @"SELECT top 3
                Product.ProductId,
                Product.CoverImage,
                Product.Title,
                Product.Description,
                Product.Price,
                Product.City,
                Product.District,
                Product.ProductCategory,
                Category.CategoryName,
                Product.AdvertisementDate
                FROM Product
                INNER JOIN Category ON Category.CategoryID = Product.ProductCategory
                order by ProductId desc";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultLast3RentProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
