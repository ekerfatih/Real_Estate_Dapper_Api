using System.Threading.Tasks;
using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository {
    public class ServiceRepository : IServiceRepository {

        private readonly Context _context;

        public ServiceRepository(Context context) {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto) {
            string query = "Insert into Service (ServiceName,ServiceStatus) values (@serviceName,@serviceStatus)";
            DynamicParameters parameters = new();
            parameters.Add("@serviceName", createServiceDto.ServiceName);
            parameters.Add("@serviceStatus", createServiceDto.ServiceStatus);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id) {
            string query = "Delete from Service where ServiceID = @serviceId";
            DynamicParameters parameters = new();
            parameters.Add("@serviceId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServices() {
            string query = "Select * from Service";
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryAsync<ResultServiceDto>(query);
                return result.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetServiceById(int id) {
            string query = "Select * from Service where ServiceID = @serviceId";
            DynamicParameters parameters = new();
            parameters.Add("@serviceId", id);
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
                return result;
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto) {
            string query = "Update Service Set ServiceName = @serviceName, ServiceStatus = @serviceStatus where ServiceID = @serviceId ";
            DynamicParameters parameters = new();
            parameters.Add("@serviceId", updateServiceDto.ServiceId);
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
