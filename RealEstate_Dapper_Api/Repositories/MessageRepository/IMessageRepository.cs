using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository {
    public interface IMessageRepository {
        Task<List<ResultInboxMessageDto>> GetInboxLast3MessageListByReciever(int id);
    }
}
