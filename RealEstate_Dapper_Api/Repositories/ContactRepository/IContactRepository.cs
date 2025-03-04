﻿using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public interface IContactRepository {
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task<List<Last4ContactResultDto>> GetLast4Contact();
    void CreateContact(CreateContactDto createContactDto);
    void DeleteContact(int id);
    Task<GetByIdContactDto> GetContactById(int id);
}
