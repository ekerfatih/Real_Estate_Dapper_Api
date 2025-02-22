using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository {
    public class BottomGridRepository : IBottomGridRepository {

        private readonly Context _context;

        public BottomGridRepository(Context context) {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto) {
            string query = "insert into BottomGrid (BottomGridIcon,BottomGridTitle,BottomGridDescription) values (@bottomGridIcon,@bottomGridTitle,@bottomGridDescription)";
            DynamicParameters parameters = new();
            parameters.Add("@bottomGridIcon", createBottomGridDto.BottomGridIcon);
            parameters.Add("@bottomGridTitle", createBottomGridDto.BottomGridTitle);
            parameters.Add("@bottomGridDescription", createBottomGridDto.BottomGridDescription);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id) {
            string query = "Delete from BottomGrid where BottomGridID = @bottomGridId";
            DynamicParameters parameters = new();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGrids() {
            string query = "Select * from BottomGrid";
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryAsync<ResultBottomGridDto>(query);
                return result.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id) {
            string query = "Select * from BottomGrid where BottomGridID = @bottomGridId";
            DynamicParameters parameters = new();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query,parameters);
                return result;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto) {
            string query = "Update BottomGrid Set BottomGridIcon = @bottomGridIcon, BottomGridTitle = @bottomGridTitle, BottomGridDescription = @bottomGridDescription where BottomGridID = @bottomGridId";
            DynamicParameters parameters = new();
            parameters.Add("@bottomGridIcon", updateBottomGridDto.BottomGridIcon);
            parameters.Add("@bottomGridTitle", updateBottomGridDto.BottomGridTitle);
            parameters.Add("@bottomGridDescription", updateBottomGridDto.BottomGridDescription);
            parameters.Add("@bottomGridId", updateBottomGridDto.BottomGridId);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
