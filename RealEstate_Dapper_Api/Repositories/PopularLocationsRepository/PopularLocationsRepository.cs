using System.Threading.Tasks;
using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationsRepository {
    public class PopularLocationsRepository : IPopularLocationsRepository {

        private readonly Context _context;

        public PopularLocationsRepository(Context context) {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto) {
            string query = "insert into PopularLocations (CityName,ImageUrl) values (@cityName,@imageUrl)";
            DynamicParameters parameters = new();
            parameters.Add("@cityName", createPopularLocationDto.CityName);
            parameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id) {
            string query = "Delete from PopularLocations where LocationID = @LocationId";
            DynamicParameters parameters = new();
            parameters.Add("@LocationId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id) {
            string query = "Select * from PopularLocations where LocationID = @LocationId";
            DynamicParameters parameters = new();
            parameters.Add("@LocationId", id);
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
                return result;
            }
        }

        public async Task<List<ResultPopularLocationDto>> PopularLocationsList() {
            string query = "Select * from PopularLocations";
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return result.ToList();
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto) {
            string query = "Update PopularLocations Set CityName = @cityName, ImageUrl = @imageUrl where LocationID = @locationId";
            DynamicParameters parameters = new();
            parameters.Add("@locationId", updatePopularLocationDto.LocationId);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
