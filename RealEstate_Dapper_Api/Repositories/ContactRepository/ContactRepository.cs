using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public class ContactRepository(Context context) : IContactRepository {

    private readonly Context _context = context;

    public Task<List<ResultContactDto>> GetAllContactAsync() {
        throw new NotImplementedException();
    }

    public async Task<List<Last4ContactResultDto>> GetLast4Contact() {
        string query = "Select top 4 * From Contact order by ContactId desc";
        using (var connection = _context.CreateConnection()) {
            var result = await connection.QueryAsync<Last4ContactResultDto>(query);
            return result.ToList();
        }
    }

    public void CreateContact(CreateContactDto createContactDto) {
        throw new NotImplementedException();
    }

    public void DeleteContact(int id) {
        throw new NotImplementedException();
    }

    public Task<GetByIdContactDto> GetContactById(int id) {
        throw new NotImplementedException();
    }
}
