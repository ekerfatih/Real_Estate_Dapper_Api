﻿namespace RealEstate_Dapper_Api.Dtos.ContactDtos;

public class ResultContactDto {
    public int ContactId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime SendDate { get; set; }
}
