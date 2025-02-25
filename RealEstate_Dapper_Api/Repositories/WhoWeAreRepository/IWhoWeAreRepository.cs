using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository {
    public interface IWhoWeAreRepository {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetail();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailById(int id);
    }
}
