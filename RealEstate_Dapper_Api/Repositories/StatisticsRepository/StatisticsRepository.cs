using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository {
    public class StatisticsRepository(Context context) : IStatisticsRepository {
        private readonly Context _context = context;

        public async Task<int> CategoryCount() {
            string sql = "SELECT COUNT(Distinct(CategoryName)) FROM Category ";

            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<int> ActiveCategoryCount() {
            string sql = "Select COUNT(*) from Category where CategoryStatus = 1";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<int> PassiveCategoryCount() {
            string sql = "Select COUNT(*) from Category where CategoryStatus = 0";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }


        public async Task<int> ProductCount() {
            var sql = "Select COUNT(*) from Product";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<int> ApartmentCount() {
            var sql = "Select COUNT(*) from Product where Title like '%Daire%'";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<string> CategoryNameByMaxProductCount() {
            var sql =
                @" SELECT TOP 1 CategoryName FROM Product
     JOIN Category ON Product.ProductCategory = Category.CategoryID
                           GROUP BY CategoryName
                           ORDER BY count(*) DESC";
            using (var connection = _context.CreateConnection()) {
                string result = (await connection.QueryFirstOrDefaultAsync<string>(sql))!;
                return result;
            }
        }

        public async Task<string> EmployeeNameByMaxProductCount() {
            var sql =
                @"Select top 1 EmployeeName from Product
    inner join Employee on Product.AppUserId = Employee.EmployeeId
                          group by EmployeeName
                          order by count(*) desc";
            using (var connection = _context.CreateConnection()) {
                string result = (await connection.QueryFirstOrDefaultAsync<string>(sql))!;
                return result;
            }
        }

        public async Task<decimal> AverageProductPriceByRent() {
            string sql = "Select AVG(Price) from Product where Type='Rent'";
            using (var connection = _context.CreateConnection()) {
                decimal result = await connection.QueryFirstOrDefaultAsync<decimal>(sql);
                return result;
            }
        }

        public async Task<decimal> AverageProductPriceBySale() {
            string sql = "Select AVG(Price) from Product where Type='Sale'";
            using (var connection = _context.CreateConnection()) {
                decimal result = await connection.QueryFirstOrDefaultAsync<decimal>(sql);
                return result;
            }
        }

        public async Task<string> CityNameByMaxProductCount() {
            string sql = "select top 1 City  from Product group by City order by count(city) desc";
            using (var connection = _context.CreateConnection()) {
                string result = (await connection.QueryFirstOrDefaultAsync<string>(sql))!;
                return result;
            }
        }

        public async Task<int> DifferentCityCount() {
            string sql = "select count(distinct(City)) from Product";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<decimal> LastProductPrice() {
            string sql = "select  top 1 Price from Product order by ProductId desc";
            using (var connection = _context.CreateConnection()) {
                decimal result = await connection.QueryFirstOrDefaultAsync<decimal>(sql);
                return result;
            }
        }

        public async Task<string> NewestBuildingYear() {
            string sql = "select Max(BuildYear) from ProductDetails";
            using (var connection = _context.CreateConnection()) {
                string result = (await connection.QueryFirstOrDefaultAsync<string>(sql))!;
                return result;
            }
        }

        public async Task<string> OldestBuildingYear() {
            string sql = "select MIN(BuildYear) from ProductDetails";
            using (var connection = _context.CreateConnection()) {
                string result = (await connection.QueryFirstOrDefaultAsync<string>(sql))!;
                return result;
            }
        }

        public async Task<int> AverageRoomCount() {
            string sql = "Select AVG(RoomCount) from ProductDetails";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<int> ActiveEmployeeCount() {
            string sql = "Select COUNT(*) from Employee where Status = 1";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }
    }
}
