using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository {
    public class CategoryRepository : ICategoryRepository {
        private readonly Context _context;

        public CategoryRepository(Context context) {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto) {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id) {
            string query = "Delete from Category Where CategoryID = @categoryId ";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
                // await connection.ExecuteAsync(querry, new { id });
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync() {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategoryById(int id) {
            string query = "Select * from Category where CategoryID = @categoryId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection()) {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto) {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryID = @categoryId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryId", categoryDto.CategoryId);

            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}