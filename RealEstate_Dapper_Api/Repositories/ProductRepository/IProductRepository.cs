using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository {
    public interface IProductRepository {

        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();

        // void CreateCategory(CreateCategoryDto categoryDto);
        // void DeleteCategory(int id);
        // void UpdateCategory(UpdateCategoryDto categoryDto);
        // Task<GetByIdCategoryDto> GetCategoryById(int id);

    }
}