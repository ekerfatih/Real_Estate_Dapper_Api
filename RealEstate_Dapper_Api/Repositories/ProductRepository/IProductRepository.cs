using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository {
    public interface IProductRepository {

        Task<List<ResultProductDto>> GetAllProduct();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory();
        Task UpdateDealOfTheDayStatus(int id);
        Task<List<ResultLast5RentProductWithCategoryDto>> GetLast5RentedProduct();
        Task<List<ResultLast3RentProductWithCategoryDto>> GetLast3RentedProduct();
        Task<GetProductByProductIdDto> GetProductByProductId(int id);
        Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id);
        Task CreateProduct(CreateProductDto createProductDto);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategory();

        // void DeleteCategory(int id);
        // void UpdateCategory(UpdateCategoryDto categoryDto);
        // Task<GetByIdCategoryDto> GetCategoryById(int id);

    }
}
