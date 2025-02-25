using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository {
    public class EmployeeRepository : IEmployeeRepository {

        private readonly Context _context;

        public EmployeeRepository(Context context) {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto) {
            string query = @"insert into Employee
            (EmployeeName,EmployeeTitle,EmployeeMail,PhoneNumber,ImageUrl,Status)
            values
            (@name,@title,@mail,@phoneNumber,@imageUrl,@status)";
            DynamicParameters parameters = new();
            parameters.Add("@name", createEmployeeDto.EmployeeName);
            parameters.Add("@title", createEmployeeDto.EmployeeTitle);
            parameters.Add("@mail", createEmployeeDto.EmployeeMail);
            parameters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@status", createEmployeeDto.Status);

            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteEmployee(int id) {
            string query = "Delete from Employee where EmployeeId = @employeeId";
            DynamicParameters parameters = new();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync() {
            string query = "Select * from Employee";
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryAsync<ResultEmployeeDto>(query);
                return result.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployeeById(int id) {
            string query = "Select * from Employee where EmployeeId = @employeeId";
            DynamicParameters parameter = new();
            parameter.Add("@employeeId", id);
            using (var connection = _context.CreateConnection()) {
                var result = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameter);
                return result;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto) {
            string query = @"
            Update Employee
            Set
            EmployeeName = @employeeName,
            EmployeeTitle = @employeeTitle,
            EmployeeMail = @employeeMail,
            PhoneNumber = @phoneNumber,
            ImageUrl = @imageUrl,
            Status = @status
            where EmployeeID = @employeeId";
            DynamicParameters parameters = new();
            parameters.Add("@employeeId", updateEmployeeDto.EmployeeId);
            parameters.Add("@employeeName", updateEmployeeDto.EmployeeName);
            parameters.Add("@employeeTitle", updateEmployeeDto.EmployeeTitle);
            parameters.Add("@employeeMail", updateEmployeeDto.EmployeeMail);
            parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@status", updateEmployeeDto.Status);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
