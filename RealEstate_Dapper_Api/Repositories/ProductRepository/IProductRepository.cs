using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository {
    public interface IProductRepository {

        Task<List<ResultProductDto>> GetAllProduct();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployee(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory();
        void UpdateDealOfTheDayStatus(int id);
        Task<List<ResultLast5RentProductWithCategoryDto>> GetLast5RentedProduct();

        // void CreateCategory(CreateCategoryDto categoryDto);
        // void DeleteCategory(int id);
        // void UpdateCategory(UpdateCategoryDto categoryDto);
        // Task<GetByIdCategoryDto> GetCategoryById(int id);

    }
}
