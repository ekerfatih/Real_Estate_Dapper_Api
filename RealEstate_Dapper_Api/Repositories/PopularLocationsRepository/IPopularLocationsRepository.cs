using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationsRepository {
    public interface IPopularLocationsRepository {
        Task<List<ResultPopularLocationDto>> PopularLocationsList();

        Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id);
        Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
    }
}
