using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepository {
    public class AppUserReposityory : IAppUserRepository {

        private readonly Context _context;

        public AppUserReposityory(Context context) {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id) {
            string sql = @"Select * from AppUser where UserId = @appUserId";
            DynamicParameters parameters = new();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection()) {
                var value = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(sql, parameters);
                return value;
            }
        }
    }
}
