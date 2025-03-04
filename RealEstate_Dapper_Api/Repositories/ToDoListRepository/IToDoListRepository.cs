using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository;

public interface IToDoListRepository {
    Task<List<ResultToDoListDto>> GetAllToDoList();
    void CreateToDoList(CreateToDoListDto createToDoListDto);
    void DeleteToDoList(int id);
    void UpdateToDoList(UpdateToDoListDto updateToDoListDto);
    Task<GetByIdToDoListDto> GetToDoList(int id);
}
