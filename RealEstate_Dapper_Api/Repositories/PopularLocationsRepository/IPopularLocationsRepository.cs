using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationsRepository {
    public interface IPopularLocationsRepository {
        Task<List<ResultPopularLocationDto>> PopularLocationsList();

        Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id);
        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
    }
}
