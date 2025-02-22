using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository {
    public interface IBottomGridRepository {
        Task<List<ResultBottomGridDto>> GetAllBottomGrids();
        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id);
    }
}
