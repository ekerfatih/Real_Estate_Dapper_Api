using System.Threading.Tasks;
using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository {
    public class ChartRepository : IChartRepository {
        private readonly Context _context;

        public ChartRepository(Context context) {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart() {
            string sql = "select top 5 City,Count(*) as 'CityCount' from product group by City order by CityCount desc";

            using (var connection = _context.CreateConnection()) {
                var results = await connection.QueryAsync<ResultChartDto>(sql);
                return results.ToList();
            }
        }
    }
}
