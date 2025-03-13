using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository {
    public class StatisticRepository : IStatisticRepository {
        private readonly Context _context;

        public StatisticRepository(Context context) {
            _context = context;
        }

        public async Task<int> AllProductCount() {
            var sql = "Select COUNT(*) from Product";
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return result;
            }
        }

        public async Task<int> ProductCountByEmployeeId(int id) {
            var sql = "Select COUNT(*) from Product where EmployeeID = @employeeId";
            DynamicParameters parameters = new();
            parameters.Add("@employeeId",id);
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql,parameters);
                return result;
            }
        }

        public async Task<int> ProductCountByStatusFalse(int id) {
            var sql = "Select COUNT(*) from Product where EmployeeID = @employeeId and ProductStatus=0";
            DynamicParameters parameters = new();
            parameters.Add("@employeeId",id);
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql,parameters);
                return result;
            }
        }

        public async Task<int> ProductCountByStatusTrue(int id) {
            var sql = "Select COUNT(*) from Product where EmployeeID = @employeeId and ProductStatus=1";
            DynamicParameters parameters = new();
            parameters.Add("@employeeId",id);
            using (var connection = _context.CreateConnection()) {
                int result = await connection.QueryFirstOrDefaultAsync<int>(sql,parameters);
                return result;
            }
        }
    }
}
