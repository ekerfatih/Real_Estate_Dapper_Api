using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository;

public class ToDoListRepository(Context context) : IToDoListRepository {

    private readonly Context _context = context;

    public async Task<List<ResultToDoListDto>> GetAllToDoList() {
        string query = "Select * from ToDoList";
        using (var connection = _context.CreateConnection()) {
            var values = await connection.QueryAsync<ResultToDoListDto>(query);
            return values.ToList();
        }
    }

    public Task CreateToDoList(CreateToDoListDto createToDoListDto) {
        throw new NotImplementedException();
    }

    public Task DeleteToDoList(int id) {
        throw new NotImplementedException();
    }

    public Task UpdateToDoList(UpdateToDoListDto updateToDoListDto) {
        throw new NotImplementedException();
    }

    public Task<GetByIdToDoListDto> GetToDoList(int id) {
        throw new NotImplementedException();
    }
}
