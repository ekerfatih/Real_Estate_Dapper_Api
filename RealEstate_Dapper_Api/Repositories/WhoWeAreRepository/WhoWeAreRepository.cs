using System.Threading.Tasks;
using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository {
    public class WhoWeAreRepository : IWhoWeAreRepository {

        private readonly Context _context;

        public WhoWeAreRepository(Context context) {
            _context = context;
        }
        public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto) {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteWhoWeAreDetail(int id) {
            string query = "Delete from WhoWeAreDetail where WhoWeAreDetailId = @whoWeAreDetailId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetail() {
            string query = "Select * from WhoWeAreDetail";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailById(int id) {
            string query = "Select * from WhoWeAreDetail where WhoWeAreDetailId = @whoWeAreDetailId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailId", id);
            using (var connection = _context.CreateConnection()) {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto) {
            string query = @"Update WhoWeAreDetail Set
            Title = @title,
            SubTitle = @subtitle,
            Description1 = @description1,
            Description2 = @description2
                                  where WhoWeAreDetailId=@whoWeAreDetailId";

            DynamicParameters parameters = new();
            parameters.Add("@whoWeAreDetailId", updateWhoWeAreDetailDto.WhoWeAreDetailId);
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
